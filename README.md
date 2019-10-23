# Joy

---------------------------------------------------------------------------------
**Joy is currently a work-in-progress, and should be considered ALPHA software.**
**USE AT YOUR OWN RISK.**
---------------------------------------------------------------------------------

Joy is an IDE for the Smile Programming Language.  It supports most common text-editing
operations, has smart syntax and error highlighting by being directly integrated with
the Smile runtime itself, and is designed to provide a better Smile development experience
than a standard text-editor (or even a fairly customizable text editor) would allow.

Joy is written in C# using WinForms for .NET Framework 4.6.  Yes, I know it's not very
portable.  If you want a portable IDE, make one yourself :P

To build Joy, you will need Visual Studio.  I use VS2019.  The `vendor/` folder should
always have a suitable copy of the Smile runtime in it; anything else that's needed
can be pulled from Nuget.

Joy uses a number of third-party Nuget packages:

- **Scintilla.NET** - Text editor core
- **DockPanelSuite** - Theme-able drag-and-drop tabbed document UI
- **Cyotek ColorPicker** - Nice color-picker control for the config UI
- **JSON.NET** - Of course
- **System.Collections.Immutable** - Nice immutable collections from Microsoft

TreeViewAdv is listed as a dependency but is not used and will soon be removed.

Joy also includes the **BetterControls** library, which contains a number of nicer
UI controls than WinForms provides out of the box.  These are all open-source and
freely steal-able, just like Joy's own code.

Joy is covered under the MIT License.  Steal-it/mutate-it/do-with-it-as-you-please,
but don't complain if it doesn't work.
