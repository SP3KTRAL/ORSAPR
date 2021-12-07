namespace Cover
{
    static class Validator
    {
        private static bool ValidatorParameters(double minValue, double maxValue, double value)
        {
            if (minValue < value && maxValue > value)
            {
                return true;
            }

            return false;
        }
    }
}
