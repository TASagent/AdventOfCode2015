const string inputFile = @"../../../../input05.txt";

Console.WriteLine("Day 05 - Doesn't He Have Intern-Elves For This?");
Console.WriteLine("Star 1");
Console.WriteLine();


string[] lines = File.ReadAllLines(inputFile);

Console.WriteLine($"The answer is: {lines.Count(IsNice)}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

Console.WriteLine($"The answer is: {lines.Count(IsNice2)}");

Console.WriteLine();
Console.ReadKey();


static bool IsNice(string line)
{
    if (line.Contains("ab") || line.Contains("cd") || line.Contains("pq") || line.Contains("xy"))
    {
        return false;
    }

    if (line.Count(x => x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u') < 3)
    {
        return false;
    }

    for (int i = 0; i < line.Length - 1; i++)
    {
        if (line[i] == line[i + 1])
        {
            return true;
        }
    }

    return false;
}

static bool IsNice2(string line)
{
    bool foundAXA = false;
    for (int i = 0; i < line.Length - 2; i++)
    {
        if (line[i] == line[i + 2])
        {
            foundAXA = true;
            break;
        }
    }

    if (!foundAXA)
    {
        return false;
    }

    for (int i = 0; i < line.Length - 3; i++)
    {
        for (int j = i + 2; j < line.Length - 1; j++)
        {
            if (line[i] == line[j] && line[i + 1] == line[j + 1])
            {
                return true;
            }
        }
    }

    return false;
}
