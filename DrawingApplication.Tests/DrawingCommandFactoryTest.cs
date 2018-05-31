using DrawingApplication.Drawing.Commands;
using NUnit.Framework;
using System;

namespace DrawingApplication.Tests
{
	[TestFixture]
	class DrawingCommandFactoryTest
	{
		[Test]
		public void ShouldThrowExceptionWhenCommandNameNotExists()
		{
			Assert.That(() => {
				DrawingCommandFactory.CreateCommand("invalid command");
			}, Throws.InstanceOf<NotSupportedException>());
		}

		[Test]
		public void ShouldCreateDrawCanvasCommand()
		{
			var command = DrawingCommandFactory.CreateCommand(CommandNames.CANVAS);
			Assert.IsInstanceOf<CanvasDrawingCommand>(command);
		}

		[Test]
		public void ShouldCreateDrawLineCommand()
		{
			var command = DrawingCommandFactory.CreateCommand(CommandNames.LINE, new Drawing.Canvas(1, 2));
			Assert.IsInstanceOf<LineDrawingCommand>(command);
		}

		[Test]
		public void ShouldThrowExceptionWhenCreateDrawLineCommandWithoutCanvas()
		{
			Assert.That(() => {
				DrawingCommandFactory.CreateCommand(CommandNames.LINE);
			}, Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void ShouldCreateDrawRetangleCommand()
		{
			var command = DrawingCommandFactory.CreateCommand(CommandNames.RECTANGLE, new Drawing.Canvas(1, 2));
			Assert.IsInstanceOf<RectangleDrawingCommand>(command);
		}

		[Test]
		public void ShouldThrowExceptionWhenCreateDrawRetangleCommandWithoutCanvas()
		{
			Assert.That(() => {
				DrawingCommandFactory.CreateCommand(CommandNames.RECTANGLE);
			}, Throws.InstanceOf<ArgumentException>());
		}

		[Test]
		public void ShouldCreateBucketFillCommand()
		{
			var command = DrawingCommandFactory.CreateCommand(CommandNames.BUCKET_FILL, new Drawing.Canvas(1, 2));
			Assert.IsInstanceOf<BucketFillDrawingCommand>(command);
		}

		[Test]
		public void ShouldThrowExceptionWhenCreateBucketFillCommandWithoutCanvas()
		{
			Assert.That(() => {
				DrawingCommandFactory.CreateCommand(CommandNames.BUCKET_FILL);
			}, Throws.InstanceOf<ArgumentException>());
		}
	}
}
