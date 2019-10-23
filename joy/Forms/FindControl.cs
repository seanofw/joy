using System;
using System.Windows.Forms;
using Joy.Config;
using Joy.Types;

namespace Joy.Forms
{
	public partial class FindControl : Form
	{
		private Dispatcher Dispatcher { get; }
		private Configurator Configurator { get; }

		public FindControl(FindInfo findInfo, Configurator configurator, Dispatcher dispatcher)
		{
			Configurator = configurator;
			Dispatcher = dispatcher;

			InitializeComponent();

			findInfo = findInfo ?? new FindInfo();

			TextComboBox.Text = findInfo.Pattern;
			CaseSensitiveCheckBox.Checked = findInfo.CaseSensitive;
			WholeWordCheckbox.Checked = findInfo.WholeWord;
			RegexCheckBox.Checked = findInfo.UseRegex;
		}

		public class FindControlEventArgs : EventArgs
		{
			public FindInfo FindInfo { get; }

			public FindControlEventArgs(FindInfo findInfo)
			{
				FindInfo = findInfo;
			}
		}

		public event EventHandler<FindControlEventArgs> Changed;

		protected void NotifyChanged()
		{
			EventHandler<FindControlEventArgs> changed = Changed;

			if (changed != null)
			{
				changed.Invoke(this, new FindControlEventArgs(new FindInfo(
					pattern: TextComboBox.Text,
					caseSensitive: CaseSensitiveCheckBox.Checked,
					wholeWord: WholeWordCheckbox.Checked,
					useRegex: RegexCheckBox.Checked
				)));
			}
		}

		private void TextComboBox_TextChanged(object sender, EventArgs e) => NotifyChanged();
		private void CaseSensitiveCheckBox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();
		private void WholeWordCheckbox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();
		private void RegexCheckBox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();
		private void FindButton_Click(object sender, EventArgs e) => Dispatcher.FindNextCommand();
		private void FindPreviousButton_Click(object sender, EventArgs e) => Dispatcher.FindPreviousCommand();

		private void TextComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			TextComboBox.Text = (string)TextComboBox.Items[TextComboBox.SelectedIndex];
			NotifyChanged();
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Return:
					Dispatcher.FindNextCommand();
					return true;

				case Keys.Escape:
					Close();
					return true;

				default:
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		private void TextComboBox_DropDown(object sender, EventArgs e) => PopulateDropdown();
		private void TextComboBox_Enter(object sender, EventArgs e) => PopulateDropdown();

		public void PopulateDropdown()
		{
			TextComboBox.Items.Clear();
			foreach (string item in Configurator.RecentFindPatterns)
			{
				TextComboBox.Items.Add(item);
			}
		}
	}
}
