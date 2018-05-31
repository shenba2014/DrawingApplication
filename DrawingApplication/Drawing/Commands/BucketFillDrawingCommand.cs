using System;

namespace DrawingApplication.Drawing.Commands
{
	public class BucketFillDrawingCommand : IDrawingCommand
	{
		private readonly Canvas _canvas;

		private static readonly int[] xPositions = { 0, 0, 1, -1 };
		private static readonly int[] yPositions = { 1, -1, 0, 0 };

		public BucketFillDrawingCommand(Canvas canvas)
		{
			_canvas = canvas;
		}

		public void Draw(params string[] parameters)
		{
			CommandParameterValidator.ValidateParameterCount(3, parameters);

			int.TryParse(parameters[0], out int x1);
			int.TryParse(parameters[1], out int y1);

			CommandParameterValidator.ValidateXaxisValueRange(_canvas, x1);
			CommandParameterValidator.ValidateYaxisValueRange(_canvas, y1);

			var color = parameters[2];
			validateColor(color);

			bucketFill(x1, y1, color);
		}

		private void validateColor(string color)
		{
			if (string.IsNullOrWhiteSpace(color))
			{
				throw new ArgumentException("color cannot be empty");
			}
		}

		private void bucketFill(int x, int y, string color)
		{
			var elements = _canvas.Elements;
			elements[x, y] = new Element(x, y) { Value = color };
			for (int i = 0; i < 4; i++)
			{
				var nextX = x + xPositions[i];
				var nextY = y + yPositions[i];
				var nextElement = elements[nextX, nextY];
				if (nextElement == null)
				{
					bucketFill(nextX, nextY, color);	
				}
			}
		}
	}
}
