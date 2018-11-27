namespace DailyCodingProblem.Problem20181126
{
    public class Class20181126
    {
        public static bool DoesTwoNumbersAddUp(int[] array, int number)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] + array[j] == number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}