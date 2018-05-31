using System;

namespace DrawingApplication.Drawing.Commands
{
	public class CanvasDrawingCommand : IDrawingCommand
	{
		public Canvas Canvas { get; private set; }

		public void Draw(params string[] parameters)
		{
			CommandParameterValidator.ValidateParameterCount(2, parameters);

			int.TryParse(parameters[0], out var width);
			int.TryParse(parameters[1], out var height);
			if (width <= 0)
			{
				throw new ArgumentException("width should be a positive integer");
			}
			if (height <= 0)
			{
				throw new ArgumentException("height should be a positive integer");
			}
			Canvas = new Canvas(width, height);
		}
	}
}
