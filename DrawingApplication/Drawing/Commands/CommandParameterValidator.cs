using System;

namespace DrawingApplication.Drawing.Commands
{
	public static class CommandParameterValidator
	{
		public static void ValidateParameterCount(int expectedCount, params string[] parameters)
		{
			if (parameters.Length != expectedCount)
			{
				throw new ArgumentException($"please provider {expectedCount} parameters");
			}
		}

		public static void ValidateXaxisValueRange(Canvas canvas, int value)
		{
			if (value <= 0)
			{
				throw new ArgumentException("index value should be a positive integer");
			}
			if (!canvas.IsValidRangeInXAxis(value))
			{
				throw new ArgumentOutOfRangeException($"{value} is out of range in X axis");
			}
		}

		public static void ValidateYaxisValueRange(Canvas canvas, int value)
		{
			if (value <= 0)
			{
				throw new ArgumentException("index value should be a positive integer");
			}
			if (!canvas.IsValidRangeInYAxis(value))
			{
				throw new ArgumentOutOfRangeException($"{value} is out of range in Y axis");
			}
		}
	}
}
