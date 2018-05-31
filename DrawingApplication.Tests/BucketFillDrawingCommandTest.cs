using DrawingApplication.Drawing.Commands;
using NUnit.Framework;

namespace DrawingApplication.Tests
{
	[TestFixture]
	class BucketFillDrawingCommandTest
	{
		[Test]
		public void ShouldFillArea()
		{
			var canvasDrawingCommand = new CanvasDrawingCommand();
			canvasDrawingCommand.Draw("20", "4");
			var canvas = canvasDrawingCommand.Canvas;

			var lineDrawingCommand = new LineDrawingCommand(canvas);
			lineDrawingCommand.Draw("1", "2", "6", "2");
			lineDrawingCommand.Draw("6", "3", "6", "4");

			var rectangleDrawingCommand = new RectangleDrawingCommand(canvas);
			rectangleDrawingCommand.Draw("14", "1", "18", "3");

			var bucketFillDrawingCommand = new BucketFillDrawingCommand(canvas);
			bucketFillDrawingCommand.Draw("10", "3", "o");

			var elements = canvas.Elements;
			var filledCount = 0;
			var emptyCount = 0;
			for (var x = 0; x < elements.GetUpperBound(0); x++)
			{
				for (var y = 0; y < elements.GetUpperBound(1); y++)
				{
					if (elements[x,y] == null)
					{
						emptyCount++;
					}
					else if (elements[x, y].Value.Equals("o"))
					{
						filledCount++;
					}
				}
			}

			Assert.AreEqual(13, emptyCount);
			Assert.AreEqual(47, filledCount);
		}
	}
}
