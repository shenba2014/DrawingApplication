using DrawingApplication.Drawing;
using DrawingApplication.Drawing.Commands;
using DrawingApplication.Drawing.Renders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "DrawingApplication";
			var commandLine = string.Empty;
			var painter = new Painter(new ConsoleDrawingRender());

			Console.WriteLine("Please input a command, type H for help");
			while (true)
			{
				commandLine = Console.ReadLine();

				if (commandLine.Equals(CommandNames.QUIT, StringComparison.OrdinalIgnoreCase))
					break;

				if (commandLine.Equals(CommandNames.HELP, StringComparison.OrdinalIgnoreCase))
				{
					showHelp();
					continue;
				}

				var tokens = commandLine.Split(' ');
				var commandName = tokens[0];

				try
				{
					painter.Execute(commandName, tokens.Skip(1).ToArray());
				}
				catch(Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
		}

		static void showHelp()
		{
			Console.WriteLine(@"Command\tDescription");
			Console.WriteLine("C w h\t\tCreate a new canvas of width w and height h.");
			Console.WriteLine("L x1 y1 x2 y2\tCreate a new line from (x1,y1) to (x2,y2).");
			Console.WriteLine("R x1 y1 x2 y2\tCreate a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2).");
			Console.WriteLine("B x y c\t\tFill the entire area connected to (x,y) with colour c");
			Console.WriteLine("Q\t\tQuit the program.");
		}
	}
}
