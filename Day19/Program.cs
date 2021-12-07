using System.Text.RegularExpressions;

const string inputFile = @"../../../../input19.txt";

Console.WriteLine("Day 19 - Medicine for Rudolph");
Console.WriteLine("Star 1");
Console.WriteLine();


HashSet<string> outputs = new HashSet<string>();

string[] lines = File.ReadAllLines(inputFile);

List<Replacement> replacements = lines.Where(x => x.Contains(" => ")).Select(x => new Replacement(x)).ToList();

string input = lines.Last();

foreach (Replacement rep in replacements)
{
    foreach (string output in rep.GetOutputs(input))
    {
        outputs.Add(output);
    }
}

Console.WriteLine($"Number of unique outputs: {outputs.Count}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

//Calculation in "input19_2.txt"

Console.WriteLine($"Number of steps: {207}");

Console.WriteLine();
Console.ReadKey();


readonly struct Replacement
{
    private readonly string input;
    private readonly string output;

    private readonly Regex regex;
    private readonly Regex reverseRegex;

    public Replacement(string line)
    {
        string[] splitLines = line.Split(" => ");

        input = splitLines[0];
        output = splitLines[1];

        regex = new Regex($@"({input})");
        reverseRegex = new Regex($@"({output})");
    }

    public IEnumerable<string> GetOutputs(string input)
    {
        MatchCollection matches = regex.Matches(input);

        foreach (Match m in matches)
        {
            yield return regex.Replace(input, output, 1, m.Index);
        }
    }

    public IEnumerable<string> GetReverseInputs(string output)
    {
        MatchCollection matches = reverseRegex.Matches(output);

        foreach (Match m in matches)
        {
            yield return reverseRegex.Replace(output, input, 1, m.Index);
        }
    }
}
