using DrawingApplication.Drawing.Commands;
using NUnit.Framework;
using System;

namespace DrawingApplication.Tests
{
	[TestFixture]
	class RectangleDrawingCommandTest
	{
		[Test]
		public void ShouldDrawRectangle()
		{
			var canvasDrawingCommand = new CanvasDrawingCommand();
			canvasDrawingCommand.Draw("20", "4");
			var canvas = canvasDrawingCommand.Canvas;

			var rectangleDrawingCommand = new RectangleDrawingCommand(canvas);
			rectangleDrawingCommand.Draw("14", "1", "18", "3");

			var elements = canvas.Elements;
			for (var i = 14; i <= 18; i++)
			{
				Assert.AreEqual("x", elements[i, 1].Value);
				Assert.AreEqual("x", elements[i, 3].Value);
			}

			for (var i = 1; i <= 3; i++)
			{
				Assert.AreEqual("x", elements[14, i].Value);
				Assert.AreEqual("x", elements[18, i].Value);
			}
		}

		[Test]
		public void CanNotDrawRectangleOutOfCanvas()
		{
			var canvasDrawingCommand = new CanvasDrawingCommand();
			canvasDrawingCommand.Draw("20", "4");
			var canvas = canvasDrawingCommand.Canvas;

			Assert.That(() => {
				var rectangleDrawingCommand = new RectangleDrawingCommand(canvas);
				rectangleDrawingCommand.Draw("14", "1", "18", "5");
			}, Throws.InstanceOf<ArgumentOutOfRangeException>());
		}
	}
}
