using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Drawing
{
	public class Element
	{
		public int X { get; private set; }

		public int Y { get; private set; }

		public string Value { get; set; }

		public Element(int x, int y)
		{
			X = x;
			Y = y;
		}
	}
}
