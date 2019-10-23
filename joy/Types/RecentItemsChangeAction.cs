namespace Joy.Types
{
	public enum RecentItemsChangeAction
	{
		/// <summary>
		/// A new item has been added to the collection (possibly bumping out older items).
		/// </summary>
		Add,

		/// <summary>
		/// Many new items have been added to the collection (possibly bumping out older items).
		/// </summary>
		AddRange,

		/// <summary>
		/// An item in the collection has been reordered (and possibly de-duped).
		/// </summary>
		Reorder,

		/// <summary>
		/// An item in the collection has been removed.
		/// </summary>
		Remove,

		/// <summary>
		/// The entire collection has been cleared.
		/// </summary>
		Clear,
	}
}