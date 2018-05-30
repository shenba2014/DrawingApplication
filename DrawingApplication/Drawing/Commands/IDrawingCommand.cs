using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Drawing.Commands
{
	public interface IDrawingCommand
	{
		void Draw(params string[] parameters);
	}
}
