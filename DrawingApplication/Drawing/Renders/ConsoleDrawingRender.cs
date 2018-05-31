using System;

namespace DrawingApplication.Drawing.Renders
{
	public class ConsoleDrawingRender : IDrawingRender
	{
		public void Render(Canvas canvas)
		{
			var points = canvas.Elements;

			for (int y = 0; y <= points.GetUpperBound(1); y++)
			{
				for (int x = 0; x <= points.GetUpperBound(0); x++)
				{
					Console.Write(points[x, y]?.Value ?? " ");
				}
				Console.WriteLine();
			}
		}
	}
}
