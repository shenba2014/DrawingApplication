using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Drawing.Commands
{
	public static class DrawingCommandFactory
	{
		public static IDrawingCommand CreateCommand(string commandName, Canvas canvas = null)
		{
			switch (commandName)
			{
				case CommandNames.CANVAS:
					return new CanvasDrawingCommand();
				case CommandNames.LINE:
					checkCanvas(canvas);
					return new LineDrawingCommand(canvas);
				case CommandNames.RECTANGLE:
					checkCanvas(canvas);
					return new RectangleDrawingCommand(canvas);
				case CommandNames.BUCKET_FILL:
					checkCanvas(canvas);
					return new BucketFillDrawingCommand(canvas);
				default:
					break;
			}
			throw new NotSupportedException();
		}

		private static void checkCanvas(Canvas canvas)
		{
			if (canvas == null) throw new ArgumentException("please create a canvas to do it");
		}
	}
}
