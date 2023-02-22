namespace HomeWork1;

static class Helper
{
    public static double V(List<double> nums, List<double> probs, int k)
    {
        var s = 0.0;
        for (int i = 0; i < nums.Count; i++)
        {
            s += Math.Pow(nums[i], k) * probs[i];
        }
        return s;
    }
    public static double M(List<double> nums, List<double> probs)
    {
        return V(nums, probs, 1);
    }
    public static double D(List<double> nums, List<double> probs)
    {
        var v1 = V(nums, probs, 1);
        var v2 = V(nums, probs, 2);
        var result = v2 - v1 * v1;
        return result;
    }

    public static double As(List<double> nums, List<double> probs, double O)
    {
        var v1 = V(nums, probs, 1);
        var v2 = V(nums, probs, 2);
        var v3 = V(nums, probs, 3);
        var result = v3 - 3 * v2 * v1 + 2 * v1 * v1 * v1;
        result /= Math.Pow(O, 3);
        return result;
    }
    public static double Es(List<double> nums, List<double> probs, double O)
    {
        var v1 = V(nums, probs, 1);
        var v2 = V(nums, probs, 2);
        var v3 = V(nums, probs, 3);
        var v4 = V(nums, probs, 4);
        var result = v4 - 4 * v3 * v1 + 6 * v2 * v1 * v1 - 3 * v1 * v1 * v1 * v1;
        result /= Math.Pow(O, 4);
        result -= 3;
        return result;
    }
    public static double Mediana(List<double> values)
    {
        var ordered = values.Order().ToList();
        return (ordered[ordered.Count / 2] + ordered[ordered.Count / 2 + 1]) / 2;
    }
    public static double[] EmpiricalDistributionFunction(double[] data)
    {
        Array.Sort(data);

        double[] edf = new double[data.Length + 1];
        edf[0] = 0;

        for (int i = 1; i <= data.Length; i++)
        {
            edf[i] = Math.Round(i * 1.0 / data.Length, 3);
        }
        return edf;
    }
}