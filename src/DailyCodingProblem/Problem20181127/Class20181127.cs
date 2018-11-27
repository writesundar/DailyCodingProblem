using System;

namespace DailyCodingProblem.Problem20181127
{
    public class Class20181127
    {
        public static int[] TransformUsingDivision(int[] input)
        {
            var transformed = new int[input.Length];
            long allMultiplied = 1;
            foreach (var i in input)
            {
                allMultiplied *= i;
            }

            for (int i = 0; i < input.Length; i++)
            {
                transformed[i] = (int)(allMultiplied / input[i]);
            }

            return transformed;
        }
    }
}