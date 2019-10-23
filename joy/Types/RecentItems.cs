using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Joy.Types
{
	/// <summary>
	/// This maintains a collection of recently-accessed items, in LRU order.
	/// </summary>
	/// <typeparam name="T">The type of items stored in this list.</typeparam>
	public class RecentItems<T> : IList<T>
	{
		#region Private internals

		private readonly List<T> _items;
		private readonly int _limit;
		private readonly Func<T, T, bool> _equals;

		#endregion

		#region Events

		public event EventHandler<RecentItemsChangedEventArgs> Changed;

		protected void OnChanged(RecentItemsChangeAction action)
		{
			Changed?.Invoke(this, new RecentItemsChangedEventArgs(action));
		}

		#endregion

		#region Construction

		/// <summary>
		/// Create a new RecentItems list from the given items, limited to contain
		/// at most the given count of items (where old items will be removed to
		/// keep the size under the limit).
		/// </summary>
		/// <param name="limit">The maximum number of items this list may contain.
		/// This must be 1 or greater.</param>
		/// <param name="items">Optional items to add to the new RecentItems list.
		/// These will *not* be automatically deduplicated, so don't include duplicates
		/// unless you want unpredictable behavior.  This may be null to start with
		/// an empty list.</param>
		/// <param name="equals">An optional equality-testing method; if null, this
		/// will use T's implementation of IEquatable{T} or IComparable{T}, if either
		/// are implemented, or T.Equals(object) if neither are implemented.</param>
		public RecentItems(int limit, IEnumerable<T> items, Func<T, T, bool> equals = null)
		{
			if (limit <= 1)
				throw new ArgumentException("RecentItems limit cannot be 0 or negative.");

			_items = items != null ? new List<T>(items) : new List<T>();
			_limit = limit;

			if (equals != null)
			{
				// If they gave us a comparison operator, use it.
				_equals = equals;
			}
			else if (typeof(IEquatable<T>).IsAssignableFrom(typeof(T)))
			{
				// Otherwise, if we have a good, provided equality operator, use it.
				_equals = (T a, T b) => ((IEquatable<T>)a).Equals(b);
			}
			else if (typeof(IComparable<T>).IsAssignableFrom(typeof(T)))
			{
				// Otherwise, maybe it implements IComparable<T>?
				_equals = (T a, T b) => ((IComparable<T>)a).CompareTo(b) == 0;
			}
			else
			{
				// Failing all else, use the standard Equals() operator.
				_equals = (T a, T b) => ((object)a).Equals((object)b);
			}
		}

		/// <summary>
		/// Create a new RecentItems list from the given items, limited to contain
		/// at most the given count of items (where old items will be removed to
		/// keep the size under the limit).  This will use IEquatable{T}, or
		/// IComparable{T}, as the comparator, if either are implemented; or
		/// T.Equals(object) if neither are implemented.
		/// </summary>
		/// <param name="limit">The maximum number of items this list may contain.
		/// This must be 1 or greater.</param>
		/// <param name="items">Optional items to add to the new RecentItems list.
		/// These will *not* be automatically deduplicated, so don't include duplicates
		/// unless you want unpredictable behavior.</param>
		public RecentItems(int limit, params T[] items)
			: this(limit, (IEnumerable<T>)items)
		{
		}

		#endregion

		#region Primary public methods

		/// <summary>
		/// Add many items to the top of the recent items list, bumping them up
		/// if they exists anywhere else in the list already, or adding them new
		/// if they don't yet exist.  This bumps out old items if the list
		/// exceeds its limit.
		/// </summary>
		/// <param name="items">The items to add or bump.</param>
		public void AddRange(IEnumerable<T> items)
		{
			// This code is O(n^2), but slightly faster than repeated calls to Add().
			int numRemoved = 0;
			int numAdded = 0;
			foreach (T item in items)
			{
				numRemoved += _items.RemoveAll(recentItem => _equals(recentItem, item));
				_items.Insert(0, item);
				numAdded++;
			}
			if (_items.Count > _limit)
				_items.RemoveRange(_limit, _items.Count - _limit);

			if (numAdded + numRemoved > 0)
				OnChanged(RecentItemsChangeAction.AddRange);
		}

		/// <summary>
		/// Add an item to the top of the recent items list, bumping it up
		/// if it exists anywhere else in the list already, or adding it new
		/// if it doesn't yet exist.  This bumps out old items if the list
		/// exceeds its limit.  This is most likely the method you want when
		/// manipulating the RecentItems list.
		/// </summary>
		/// <param name="item">The item to add or bump.</param>
		public void Add(T item)
		{
			// Common case of updating the most recent thing:  Do nothing.
			if (_items.Count > 0 && _equals(_items[0], item)) return;

			// This code is lame, but it works for small n.
			int numRemoved = _items.RemoveAll(recentItem => _equals(recentItem, item));
			_items.Insert(0, item);
			if (_items.Count > _limit)
				_items.RemoveRange(_limit, _items.Count - _limit);

			OnChanged(numRemoved > 0 ? RecentItemsChangeAction.Reorder : RecentItemsChangeAction.Add);
		}

		/// <summary>
		/// Bump a preexisting item to the top of the recent items list.
		/// Does nothing if the item doesn't already exist.
		/// </summary>
		/// <param name="item">The item to bump to the top.</param>
		/// <returns>True if the item existed (and was thus bumped up), or false
		/// if the item didn't already exist.</returns>
		public bool Bump(T item)
		{
			// Common case of bumping the most recent thing:  Do nothing.
			if (_items.Count > 0 && _equals(_items[0], item)) return true;

			// This code is lame, but it works for small n.
			if (_items.RemoveAll(recentItem => _equals(recentItem, item)) > 0)
			{
				_items.Insert(0, item);
				OnChanged(RecentItemsChangeAction.Reorder);
				return true;
			}
			else return false;
		}

		#endregion

		#region IList<T>, ICollection<T>, and IEnumerable<T> support (implemented as proxies).

		public bool Remove(T item)
		{
			int numRemoved = _items.RemoveAll(recentItem => _equals(recentItem, item));
			if (numRemoved > 0)
				OnChanged(RecentItemsChangeAction.Remove);
			return numRemoved > 0;
		}

		public void Clear()
		{
			int numItems = _items.Count;
			_items.Clear();
			if (numItems > 0)
				OnChanged(RecentItemsChangeAction.Clear);
		}

		public bool Contains(T item)
			=> _items.Any(recentItem => _equals(recentItem, item));

		public int Count
			=> _items.Count;

		public bool IsReadOnly
			=> false;

		public T this[int index]
		{
			get => _items[index];
			set => throw new NotSupportedException("Cannot directly replace items in a RecentItems list.");
		}

		public void CopyTo(T[] items, int arrayIndex)
			=> _items.CopyTo(items, arrayIndex);

		public IEnumerator<T> GetEnumerator()
			=> _items.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator()
			=> _items.GetEnumerator();

		public int IndexOf(T item)
			=> _items.IndexOf(item);

		public void Insert(int index, T item)
			=> throw new NotSupportedException("Cannot directly insert at a specific position in a RecentItems list.");

		public void RemoveAt(int index)
			=> throw new NotSupportedException("Cannot directly remove at a specific position in a RecentItems list.");

		#endregion

		#region Registry storage

		/// <summary>
		/// This regex matches all of the counting numbers (integers > 0) as strings.
		/// </summary>
		private static Regex _numberRegex = new Regex("^[1-9][0-9]*$", RegexOptions.None);

		/// <summary>
		/// Save the contents of this list to a registry key.  Each item {T}
		/// must be serializable by JSON.NET.
		/// </summary>
		/// <param name="registryKey">The registry key at which to save this list.
		/// Existing numeric-named values for this key will be deleted, but any other
		/// subkeys and unrelated values will be untouched.  New values will be created
		/// with names starting at "1", "2", "3", and so on, and they will contain
		/// JSON-serialized data for each item.</param>
		/// <returns>True if the data was successfully saved, false if there was an
		/// error (such as the registry key not being opened for writing/deleting, or
		/// not having sufficient permissions).</returns>
		public bool SaveToRegistry(RegistryKey registryKey)
		{
			string[] valueNames = registryKey.GetValueNames();

			foreach (string name in valueNames.Where(n => _numberRegex.IsMatch(n)))
			{
				try
				{
					registryKey.DeleteValue(name);
				}
				catch
				{
					// Ignore errors.
				}
			}

			bool succeeded = true;
			for (int i = 0; i < _items.Count; i++)
			{
				T item = _items[i];

				// Strings are stored as-is; everything else is serialized as JSON.
				string registryText = typeof(T) == typeof(string)
					? item.ToString()
					: JsonConvert.SerializeObject(item, Formatting.None);

				try
				{
					registryKey.SetValue($"{i + 1}", registryText, RegistryValueKind.String);
				}
				catch
				{
					succeeded = false;
				}
			}

			return succeeded;
		}

		/// <summary>
		/// Load the contents of this list from a registry key.  Each item {T}
		/// must be deserializable by JSON.NET.
		/// </summary>
		/// <param name="registryKey">The registry key from which to load this list.
		/// Values for the items must have names starting with "1", "2", "3", and
		/// so on, and must contain JSON-serialized data for each item.  If there
		/// are gaps between numbers, those gaps will be ignored, and the items
		/// will be shifted down to fill the gaps.</param>
		/// <param name="limit">The maximum number of items to keep.  Older items
		/// (higher-numbered items) will be discarded to meet this limit.</param>
		/// <param name="equals">An optional equality-testing function that
		/// will be passed to the RecentItems{T} constructor.</param>
		public static RecentItems<T> LoadFromRegistry(RegistryKey registryKey, int limit, Func<T, T, bool> equals = null)
		{
			const int MaxDigits = 50;
			string[] valueNames = registryKey.GetValueNames();

			// Find the length of the longest name in the set.  Any name longer
			// than MaxDigits is assumed to be just plain garbage.
			int nameMaxLength = valueNames.Where(n => n.Length < MaxDigits).Select(n => n.Length).Max();

			// Sort all of the names numerically, using a padding trick so we don't actually
			// have to convert them to real numbers, and then chop that off at the maximum
			// number of things we'll allow.
			string[] sortedNames = valueNames
				.Where(n => n.Length < MaxDigits && _numberRegex.IsMatch(n))
				.OrderBy(k => k.PadLeft(nameMaxLength, '0'))
				.Take(limit)
				.ToArray();

			// Pull out only those values we care about.
			List<T> orderedItems = new List<T>();
			foreach (string name in sortedNames)
			{
				try
				{
					string registryText = registryKey.GetValue(name).ToString();
					T item = typeof(T) == typeof(string)
						? (T)(object)registryText
						: JsonConvert.DeserializeObject<T>(registryText);
					orderedItems.Add(item);
				}
				catch
				{
					// Ignore this item if it errors either in reading or in deserializing.
				}
			}

			// Finally, make the deserialized collection.
			return new RecentItems<T>(limit, orderedItems, equals);
		}

		#endregion
	}
}
