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
	class CanvasDrawingCommandTest
	{
		[Test]
		public void ShouldCreateCanvas()
		{
			var command = new CanvasDrawingCommand();
			command.Draw("20", "4");

			Assert.NotNull(command.Canvas);
		}

		[Test]
		public void ShouldThrowExceptionWhenParameterIsNotANumber()
		{
			Assert.That(() => {
				var command = new CanvasDrawingCommand();
				command.Draw("xxx", "yyy");
			}, Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void ShouldThrowExceptionWhenParameterIsNotAPositiveInteger()
		{
			Assert.That(() => {
				var command = new CanvasDrawingCommand();
				command.Draw("-2", "-9");
			}, Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void ShouldCreateCanvasWithWidthAndHeight()
		{
			var command = new CanvasDrawingCommand();
			command.Draw("20", "4");
			var canvas = command.Canvas;

			Assert.IsNotNull(canvas.Elements);
			Assert.AreEqual(21, canvas.Elements.GetUpperBound(0));
			Assert.AreEqual(5, canvas.Elements.GetUpperBound(1));
		}

		[Test]
		public void ShouldCreateCanvasWithBoundaryElementsCreated()
		{
			var command = new CanvasDrawingCommand();
			command.Draw("20", "4");
			var canvas = command.Canvas;
			var points = canvas.Elements;

			for (int x = 0; x < 22; x++)
			{
				Assert.AreEqual("-", points[x, 0].Value);
				Assert.AreEqual("-", points[x, 5].Value);
			}

			for (int y = 1; y < 5; y++)
			{
				Assert.AreEqual("|", points[0, y].Value);
				Assert.AreEqual("|", points[21, y].Value);
			}
		}
	}
}
