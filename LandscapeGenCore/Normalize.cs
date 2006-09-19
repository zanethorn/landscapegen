using System;

namespace LandscapeGenCore
{
	/// <summary>
	/// Summary description for Normalize.
	/// </summary>
	public class Normalize : IPostProcessor
	{
		#region PostProcessor Members

		public void Free() {
			// TODO:  Add Normalize.Free implementation
		}

		public float[,] Process(float[,] input) {
			float[,] ret = new float[input.GetLength(0), input.GetLength(1)];

			double minValue = float.MaxValue;
			double maxValue = float.MinValue;
			double scale = 1;
			double range;
			double newVal;

			// Find Min and max
			for (int i=0; i<input.GetLength(0); i++) {
				for (int j=0; j<input.GetLength(1); j++) {
					if (input[i,j] > maxValue) { maxValue = input[i,j]; }
					if (input[i,j] < minValue) { minValue = input[i,j]; }
				}
			}

			// Calc Range
			range = maxValue -  minValue;

			//Calculate scale
			scale = (float.MaxValue-float.MinValue) / range;

			//Normalize values
			for (int i=0; i<input.GetLength(0); i++) {
				for (int j=0; j<input.GetLength(1); j++) {
					newVal = input[i,j] -minValue;	// Offset values to zero
					newVal = newVal * scale;		// Scale to max, note that teh min value has been taken into account
					ret[i,j] = (float)newVal;
				}
			}

			return ret;
		}

		#endregion
	}
}
