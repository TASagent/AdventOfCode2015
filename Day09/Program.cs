const string inputFile = @"../../../../input09.txt";

Console.WriteLine("Day 09 - All in a Single Night");
Console.WriteLine("Star 1");
Console.WriteLine();

Dictionary<(string, string), int> distanceMap = new Dictionary<(string, string), int>();

//LOL
//Traveling salesman problem

HashSet<string> cities = new HashSet<string>();
string[] lines = File.ReadAllLines(inputFile);

foreach (string line in lines)
{
    string[] splitLine = line.Split(' ');
    string city1 = splitLine[0];
    string city2 = splitLine[2];
    int distance = int.Parse(splitLine[4]);

    cities.Add(city1);
    cities.Add(city2);

    distanceMap[(city1, city2)] = distance;
    distanceMap[(city2, city1)] = distance;
}

int minDistance = FindMinPathStart(cities);

Console.WriteLine($"The answer is: {minDistance}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

int maxDistance = FindMaxPathStart(cities);

Console.WriteLine($"The answer is: {maxDistance}");

Console.WriteLine();
Console.ReadKey();


int FindMinPathStart(IEnumerable<string> cities)
{
    string[] citiesCopy = cities.ToArray();

    int minDistance = int.MaxValue;

    //The list is reversible.
    //That means I can cut **1** element off the initial element check
    for (int i = 0; i < citiesCopy.Length - 1; i++)
    {
        minDistance = Math.Min(minDistance, FindMinPath(
            lastCity: citiesCopy[i],
            remainingCities: citiesCopy.Take(i).Concat(citiesCopy.Skip(i + 1))));
    }

    return minDistance;
}

int FindMinPath(string lastCity, IEnumerable<string> remainingCities)
{
    if (remainingCities.Count() == 1)
    {
        return distanceMap[(lastCity, remainingCities.First())];
    }

    int minDistance = int.MaxValue;

    foreach (string city in remainingCities)
    {
        minDistance = Math.Min(minDistance, distanceMap[(lastCity, city)] + FindMinPath(
            lastCity: city,
            remainingCities: remainingCities.Where(x => x != city)));
    }

    return minDistance;
}

int FindMaxPathStart(IEnumerable<string> cities)
{
    string[] citiesCopy = cities.ToArray();

    int maxDistance = 0;

    //The list is reversible.
    //That means I can cut **1** element off the initial element check
    for (int i = 0; i < citiesCopy.Length - 1; i++)
    {
        maxDistance = Math.Max(maxDistance, FindMaxPath(
            lastCity: citiesCopy[i],
            remainingCities: citiesCopy.Take(i).Concat(citiesCopy.Skip(i + 1))));
    }

    return maxDistance;
}

int FindMaxPath(string lastCity, IEnumerable<string> remainingCities)
{
    if (remainingCities.Count() == 1)
    {
        return distanceMap[(lastCity, remainingCities.First())];
    }

    int maxDistance = 0;

    foreach (string city in remainingCities)
    {
        maxDistance = Math.Max(maxDistance, distanceMap[(lastCity, city)] + FindMaxPath(
            lastCity: city,
            remainingCities: remainingCities.Where(x => x != city)));
    }

    return maxDistance;
}
