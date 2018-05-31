using System;

namespace DrawingApplication.Drawing.Commands
{
	public class CanvasDrawingCommand : IDrawingCommand
	{
		public Canvas Canvas { get; private set; }

		public void Draw(params string[] parameters)
		{
			if (!int.TryParse(parameters[0], out int width)){
				throw new ArgumentException("width should be an integer");
			}
			if (!int.TryParse(parameters[1], out int height)){
				throw new ArgumentException("height should be an integer");
			}
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
