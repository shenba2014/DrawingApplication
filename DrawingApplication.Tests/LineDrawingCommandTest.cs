using DrawingApplication.Drawing.Commands;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Tests
{
	[TestFixture]
	public class LineDrawingCommandTest
	{
		[Test]
		public void ShouldDrawLineInCanvas()
		{
			var canvasDrawingCommand = new CanvasDrawingCommand();
			canvasDrawingCommand.Draw("20", "4");
			var canvas = canvasDrawingCommand.Canvas;

			var lineDrawingCommand = new LineDrawingCommand(canvas);
			lineDrawingCommand.Draw("1", "2", "6", "2");

			var elements = canvas.Elements;
			for (int i = 1; i <= 6; i++)
			{
				Assert.AreEqual("x", elements[i, 2].Value);
			}
		}

		[Test]
		public void CanNotDrawLineOutOfCanvas()
		{
			var canvasDrawingCommand = new CanvasDrawingCommand();
			canvasDrawingCommand.Draw("20", "4");
			var canvas = canvasDrawingCommand.Canvas;

			Assert.That(() => {
				var lineDrawingCommand = new LineDrawingCommand(canvas);
				lineDrawingCommand.Draw("1", "5", "6", "5");
			}, Throws.InstanceOf<ArgumentOutOfRangeException>());
			
		}
	}
}
