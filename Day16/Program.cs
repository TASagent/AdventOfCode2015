const string inputFile = @"../../../../input16.txt";

Console.WriteLine("Day 16 - Aunt Sue");
Console.WriteLine("Star 1");
Console.WriteLine();

string[] lines = File.ReadAllLines(inputFile);

List<Sue> sues = lines.Select(x => new Sue(x)).ToList();


HashSet<string> features = new HashSet<string>()
{
    "children: 3",
    "cats: 7",
    "samoyeds: 2",
    "pomeranians: 3",
    "akitas: 0",
    "vizslas: 0",
    "goldfish: 5",
    "trees: 3",
    "cars: 2",
    "perfumes: 1"
};

foreach (Sue sue in sues)
{
    if (features.Contains(sue.featureA) &&
        features.Contains(sue.featureB) &&
        features.Contains(sue.featureC))
    {
        Console.WriteLine($"Candidate Sue: {sue.number}");
    }
}

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

List<Sue2> newSues = lines.Select(x => new Sue2(x)).ToList();

List<(Feature, int)> measurements = new List<(Feature, int)>()
{
    (Feature.Children, 3),
    (Feature.Cats, 7),
    (Feature.Samoyeds, 2),
    (Feature.Pomeranians, 3),
    (Feature.Akitas, 0),
    (Feature.Vizslas, 0),
    (Feature.Goldfish, 5),
    (Feature.Trees, 3),
    (Feature.Cars, 2),
    (Feature.Perfumes, 1)
};

foreach (Sue2 sue in newSues)
{
    if (measurements.Select(x => sue.IsConsistentWith(x.Item1, x.Item2)).All(x => x))
    {
        Console.WriteLine($"Candidate Sue: {sue.number}");
    }
}

Console.WriteLine();
Console.ReadLine();


readonly struct Sue
{
    public readonly int number;
    public readonly string featureA;
    public readonly string featureB;
    public readonly string featureC;

    private static readonly char[] separators = new char[] { ' ', ':', ',' };

    public Sue(string line)
    {
        string[] splitLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        number = int.Parse(splitLine[1]);
        featureA = $"{splitLine[2]}: {splitLine[3]}";
        featureB = $"{splitLine[4]}: {splitLine[5]}";
        featureC = $"{splitLine[6]}: {splitLine[7]}";
    }
}

enum Feature
{
    Children,
    Cats,
    Samoyeds,
    Pomeranians,
    Akitas,
    Vizslas,
    Goldfish,
    Trees,
    Cars,
    Perfumes
}

readonly struct Sue2
{
    public readonly int number;
    public readonly Feature featureA;
    public readonly int countA;
    public readonly Feature featureB;
    public readonly int countB;
    public readonly Feature featureC;
    public readonly int countC;

    private static readonly char[] separators = new char[] { ' ', ':', ',' };

    public Sue2(string line)
    {
        string[] splitLine = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        number = int.Parse(splitLine[1]);
        featureA = ParseFeature(splitLine[2]);
        countA = int.Parse(splitLine[3]);
        featureB = ParseFeature(splitLine[4]);
        countB = int.Parse(splitLine[5]);
        featureC = ParseFeature(splitLine[6]);
        countC = int.Parse(splitLine[7]);
    }

    public bool IsConsistentWith(Feature feature, int count)
    {
        int sueCount;
        if (feature == featureA)
        {
            sueCount = countA;
        }
        else if (feature == featureB)
        {
            sueCount = countB;
        }
        else if (feature == featureC)
        {
            sueCount = countC;
        }
        else
        {
            return true;
        }

        return feature switch
        {
            Feature.Cats or Feature.Trees => sueCount > count,

            Feature.Pomeranians or Feature.Goldfish => sueCount < count,

            Feature.Children or Feature.Samoyeds or Feature.Akitas or
            Feature.Vizslas or Feature.Cars or Feature.Perfumes => sueCount == count,

            _ => throw new Exception(),
        };
    }

    private static Feature ParseFeature(string feature) => feature switch
    {
        "children" => Feature.Children,
        "cats" => Feature.Cats,
        "samoyeds" => Feature.Samoyeds,
        "pomeranians" => Feature.Pomeranians,
        "akitas" => Feature.Akitas,
        "vizslas" => Feature.Vizslas,
        "goldfish" => Feature.Goldfish,
        "trees" => Feature.Trees,
        "cars" => Feature.Cars,
        "perfumes" => Feature.Perfumes,
        _ => throw new Exception(),
    };
}
