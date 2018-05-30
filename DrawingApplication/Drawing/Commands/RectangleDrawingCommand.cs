using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Drawing.Commands
{
	public class RectangleDrawingCommand : IDrawingCommand
	{
		private Canvas _canvas;

		public RectangleDrawingCommand(Canvas canvas)
		{
			_canvas = canvas;
		}

		public void Draw(params string[] parameters)
		{
			CommandParameterValidator.ValidateParameterCount(4, parameters);

			int.TryParse(parameters[0], out int x1);
			int.TryParse(parameters[1], out int y1);
			int.TryParse(parameters[2], out int x2);
			int.TryParse(parameters[3], out int y2);

			CommandParameterValidator.ValidateXaxisValueRange(_canvas, x1);
			CommandParameterValidator.ValidateYaxisValueRange(_canvas, y1);
			CommandParameterValidator.ValidateXaxisValueRange(_canvas, x2);
			CommandParameterValidator.ValidateYaxisValueRange(_canvas, y2);

			drawRectangle(x1, y1, x2, y2);
		}

		private void drawRectangle(int x1, int y1, int x2, int  y2)
		{
			var elements = _canvas.Elements;
			for (var x = x1; x <= x2; x++)
			{
				elements[x, y1] = new Element(x, y1) { Value = "x" };
				elements[x, y2] = new Element(x, y2) { Value = "x" };
			}

			for (var y = y1; y <= y2; y++)
			{
				elements[x1, y] = new Element(x1, y) { Value = "x" };
				elements[x2, y] = new Element(x2, y) { Value = "x" };
			}
		}
	}
}
