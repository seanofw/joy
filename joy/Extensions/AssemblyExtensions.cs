using System.Drawing;
using System.IO;
using System.Reflection;

namespace Joy.Extensions
{
	public static class AssemblyExtensions
	{
		public static Image LoadEmbeddedImage(this Assembly assembly, string name)
		{
			Stream stream = assembly.GetManifestResourceStream(@"Joy." + name.Replace('/', '.').Replace('\\', '.'));
			Image image = Image.FromStream(stream);
			return image;
		}
	}
}
