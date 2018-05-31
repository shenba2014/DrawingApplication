using DrawingApplication.Drawing;
using DrawingApplication.Drawing.Commands;
using DrawingApplication.Drawing.Renders;

namespace DrawingApplication
{
	public class Painter
	{
		private Canvas _canvas;
		private readonly IDrawingRender _drawingRender;
	
		public Painter(IDrawingRender drawingRender)
		{
			_drawingRender = drawingRender;
		}

		public void Execute(string commandName, params string[] parameters)
		{
			var command = DrawingCommandFactory.CreateCommand(commandName, _canvas);
			command.Draw(parameters);
			if (commandName == CommandNames.CANVAS)
			{
				_canvas = ((CanvasDrawingCommand)command).Canvas;
			}
			_drawingRender.Render(_canvas);
		}
	}
}
