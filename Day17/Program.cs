const string inputFile = @"../../../../input17.txt";

Console.WriteLine("Day 17 - No Such Thing as Too Much");
Console.WriteLine("Star 1");
Console.WriteLine();

//How many ways are there to store 150 liters of eggnog in the input containers.
//Any used container must be filled entirely.

int[] containers = File.ReadAllLines(inputFile).Select(int.Parse).OrderByDescending(x => x).ToArray();

int output1 = CountCombinations(150, 0);

Console.WriteLine($"The number of combinations is: {output1}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

int minContainers = MinContainers(150, 0);

int combinations = CountCombinationsContainers(150, minContainers, 0);

Console.WriteLine($"The number of possible solutions is: {combinations}");

Console.WriteLine();
Console.ReadKey();


int CountCombinations(int remainingNog, int currentIndex)
{
    if (remainingNog == 0)
    {
        //Good base condition
        return 1;
    }

    if (currentIndex == containers.Length)
    {
        //Invalid base condition
        return 0;
    }

    int combinations = 0;
    for (int i = currentIndex; i < containers.Length; i++)
    {
        if (containers[i] <= remainingNog)
        {
            combinations += CountCombinations(remainingNog - containers[i], i + 1);
        }
    }

    return combinations;
}

int CountCombinationsContainers(int remainingNog, int remainingContainers, int currentIndex)
{
    if (remainingNog == 0)
    {
        //Good base condition
        return 1;
    }

    if (currentIndex == containers.Length || remainingContainers == 0)
    {
        //Invalid base condition
        return 0;
    }

    int combinations = 0;
    for (int i = currentIndex; i < containers.Length; i++)
    {
        if (containers[i] <= remainingNog)
        {
            combinations += CountCombinationsContainers(remainingNog - containers[i], remainingContainers - 1, i + 1);
        }
    }

    return combinations;
}

int MinContainers(int remainingNog, int currentIndex)
{
    if (remainingNog == 0)
    {
        //Good base condition
        return 0;
    }

    if (currentIndex == containers.Length)
    {
        //Invalid base condition
        return containers.Length;
    }

    int containerCount = containers.Length;
    for (int i = currentIndex; i < containers.Length; i++)
    {
        if (containers[i] <= remainingNog)
        {
            containerCount = Math.Min(containerCount, 1 + MinContainers(remainingNog - containers[i], i + 1));
        }
    }

    return containerCount;
}
