using System;
using System.Windows.Forms;
using Joy.Forms;

namespace Joy
{
	static class Program
	{
		internal static bool ShouldRestart = false;

		[STAThread]
		static void Main()
		{
			SmileLibInterop.Smile.Init();

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());

			if (ShouldRestart)
				Application.Restart();
		}
	}
}
