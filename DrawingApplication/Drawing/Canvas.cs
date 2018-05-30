using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApplication.Drawing
{
	public class Canvas
	{
		public Element[,] Elements { get; private set; }

		public Canvas(int width, int height)
		{
			initElements(width, height);
		}

		public bool IsValidRangeInXAxis(int x)
		{
			return x <= Elements.GetUpperBound(0) - 1;
		}

		public bool IsValidRangeInYAxis(int y)
		{
			return y <= Elements.GetUpperBound(1) - 1;
		}

		private void initElements(int width, int height)
		{
			width = width + 2;
			height = height + 2;
			Elements = new Element[width, height];
			fillHorizontalBoundaryElements();
			fillVerticalBoundaryElements();
		}

		private void fillHorizontalBoundaryElements()
		{
			var horizontalUpperBound = Elements.GetUpperBound(0);
			var verticalUppperBound = Elements.GetUpperBound(1);
			for (var x = 0; x <= horizontalUpperBound; x++)
			{
				Elements[x, 0] = new Element(x, 0)
				{
					Value = "-"
				};

				Elements[x, verticalUppperBound] = new Element(x, verticalUppperBound)
				{
					Value = "-"
				};
			}
		}

		private void fillVerticalBoundaryElements()
		{
			var horizontalUpperBound = Elements.GetUpperBound(0);
			var verticalUppperBound = Elements.GetUpperBound(1);
			for (var y = 1; y < verticalUppperBound; y++)
			{
				Elements[0, y] = new Element(0, y)
				{
					Value = "|"
				};

				Elements[horizontalUpperBound, y] = new Element(horizontalUpperBound, y)
				{
					Value = "|"
				};
			}
		}
	}
}
