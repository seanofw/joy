using System;
using System.Windows.Forms;
using Joy.Config;
using Joy.Types;

namespace Joy.Forms
{
	public partial class ReplaceControl : Form
	{
		private Configurator Configurator { get; }
		private Dispatcher Dispatcher { get; }

		public ReplaceControl(ReplaceInfo replaceInfo, Configurator configurator, Dispatcher dispatcher)
		{
			Configurator = configurator;
			Dispatcher = dispatcher;

			InitializeComponent();

			replaceInfo = replaceInfo ?? new ReplaceInfo();

			PatternComboBox.Text = replaceInfo.Pattern;
			ReplacementComboBox.Text = replaceInfo.Replacement;
			CaseSensitiveCheckBox.Checked = replaceInfo.CaseSensitive;
			WholeWordCheckbox.Checked = replaceInfo.WholeWord;
			RegexCheckBox.Checked = replaceInfo.UseRegex;
		}

		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			switch (keyData)
			{
				case Keys.Return:
					Dispatcher.ReplaceNextCommand();
					return true;

				case Keys.Escape:
					Close();
					return true;

				default:
					return base.ProcessCmdKey(ref msg, keyData);
			}
		}

		public class ReplaceControlEventArgs : EventArgs
		{
			public ReplaceInfo ReplaceInfo { get; }

			public ReplaceControlEventArgs(ReplaceInfo replaceInfo)
			{
				ReplaceInfo = replaceInfo;
			}
		}

		public event EventHandler<ReplaceControlEventArgs> Changed;

		protected void NotifyChanged()
		{
			EventHandler<ReplaceControlEventArgs> changed = Changed;

			if (changed != null)
			{
				changed.Invoke(this, new ReplaceControlEventArgs(new ReplaceInfo(
					pattern: PatternComboBox.Text,
					replacement: ReplacementComboBox.Text,
					caseSensitive: CaseSensitiveCheckBox.Checked,
					wholeWord: WholeWordCheckbox.Checked,
					useRegex: RegexCheckBox.Checked
				)));
			}
		}

		private void ReplaceNextButton_Click(object sender, System.EventArgs e) => Dispatcher.ReplaceNextCommand();
		private void ReplaceAllButton_Click(object sender, System.EventArgs e) => Dispatcher.ReplaceAllCommand();
		private void PatternComboBox_TextChanged(object sender, EventArgs e) => NotifyChanged();
		private void ReplacementComboBox_TextChanged(object sender, EventArgs e) => NotifyChanged();
		private void CaseSensitiveCheckBox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();
		private void WholeWordCheckbox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();
		private void RegexCheckBox_CheckedChanged(object sender, EventArgs e) => NotifyChanged();

		private void PatternComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			PatternComboBox.Text = (string)PatternComboBox.Items[PatternComboBox.SelectedIndex];
			NotifyChanged();
		}

		private void ReplacementComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ReplacementComboBox.Text = (string)ReplacementComboBox.Items[ReplacementComboBox.SelectedIndex];
			NotifyChanged();
		}

		private void PatternComboBox_DropDown(object sender, EventArgs e) => PopulatePatternComboBoxDropdown();
		private void PatternComboBox_Enter(object sender, EventArgs e) => PopulatePatternComboBoxDropdown();

		public void PopulatePatternComboBoxDropdown()
		{
			PatternComboBox.Items.Clear();
			foreach (string item in Configurator.RecentReplacePatterns)
			{
				PatternComboBox.Items.Add(item);
			}
		}

		private void ReplacementComboBox_DropDown(object sender, EventArgs e) => PopulateReplacementComboBoxDropdown();
		private void ReplacementComboBox_Enter(object sender, EventArgs e) => PopulateReplacementComboBoxDropdown();

		public void PopulateReplacementComboBoxDropdown()
		{
			ReplacementComboBox.Items.Clear();
			foreach (string item in Configurator.RecentReplacements)
			{
				ReplacementComboBox.Items.Add(item);
			}
		}
	}
}