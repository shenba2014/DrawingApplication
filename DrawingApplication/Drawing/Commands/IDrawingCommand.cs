namespace DrawingApplication.Drawing.Commands
{
	public interface IDrawingCommand
	{
		void Draw(params string[] parameters);
	}
}
