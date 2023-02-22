using static HomeWork1.Helper;

var givenValues = new List<int>()
{
    59, 55, 60, 46, 57, 54, 57, 54, 55, 46,
    57, 59, 57, 46, 54, 55, 57, 59, 54, 54,
    46, 55, 57, 60, 55, 54, 46, 55, 57, 54
};

var orderedGiven = givenValues.Order();
var orderedDistinct = orderedGiven.Distinct().ToList(); // x for i
var counts = orderedDistinct.Select(n => givenValues.Count(i => i == n))
                            .ToList(); // n for i

var probs = counts.Select(c => (double)c / givenValues.Count)
                  .ToList();

var edf = EmpiricalDistributionFunction(orderedDistinct.ToArray());

Console.WriteLine("Write different values of variation, that appeared in selection: (value - number)");
Console.WriteLine(string.Join("\n", givenValues.Distinct().Select(n => $"\t{n} - {orderedDistinct.IndexOf(n) + 1}")));

Console.WriteLine("1) Variation sequence:\n");
Console.WriteLine("\t" + string.Join(", ", orderedDistinct));

Console.WriteLine("2) Statistic of selection: \n");
Console.WriteLine("\t" + string.Join("|", orderedDistinct));
Console.WriteLine("\t" + string.Join(" |", counts));

Console.WriteLine("3) Grouped variational sequence: \n");
Console.WriteLine("\t" + string.Join(", ", orderedGiven));

Console.WriteLine("4) Percentage of values\n");
Console.WriteLine("\t" + string.Join("   |", orderedDistinct));
Console.WriteLine("\t" + string.Join("|", probs.Select(d => Math.Round(d, 3).ToString().PadRight(5))));

Console.WriteLine("5) Камулята та огіва:\n");
int sum = 0;
Console.WriteLine("Select\tCount\tDiff count");
for (int i = 0; i < orderedDistinct.Count; i++)
{
    sum += counts[i];
    Console.WriteLine($"{orderedDistinct[i]}\t{counts[i]}\t{sum}");
}

Console.WriteLine("\n7) EDF values\n");
for (int i = 0; i < edf.Length; i++)
{
    Console.Write(edf[i].ToString().PadLeft(5) + " when ");
    if (i == 0)
        Console.WriteLine($"x <= {orderedDistinct[i]}");
    else if (i == edf.Length - 1)
        Console.WriteLine($"x > {orderedDistinct[i - 1]}");
    else
        Console.WriteLine($"{orderedDistinct[i - 1]} < x <= {orderedDistinct[i]}");
}
Console.WriteLine("8) ");
Console.WriteLine($"\tMode: {orderedDistinct[counts.IndexOf(counts.Max())]}");
Console.WriteLine($"\tMedian: {Mediana(givenValues)}");

var nums = orderedDistinct.Select(i => (double)i).ToList();
var m = M(nums, probs);
var d = D(nums, probs);
var o = Math.Sqrt(d);
var ass = As(nums, probs, o);
var es = Es(nums, probs, o);
Console.WriteLine("9) ");
Console.WriteLine($"\tM[x] = {m:#.###}");
Console.WriteLine($"\tD[x] = {d:#.###}");
Console.WriteLine($"\to(x) = {o:#.#####}");
Console.WriteLine($"\tAs(x) = {ass:#.#####}");
Console.WriteLine($"\tEs(x) = {es:#.#####}");

Console.ReadLine();
