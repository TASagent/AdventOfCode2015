const string inputFile = @"../../../../input01.txt";


Console.WriteLine("Day 01 - Not Quite Lisp");
Console.WriteLine("Star 1");
Console.WriteLine();

string input = File.ReadAllText(inputFile);

int floor = 0;
int firstBasement = int.MaxValue;
for (int i = 0; i < input.Length; i++)
{
    switch (input[i])
    {
        case '(':
            floor++;
            break;

        case ')':
            floor--;
            break;

        default:
            throw new Exception();
    }


    if (floor == -1 && i < firstBasement)
    {
        firstBasement = i + 1;
    }
}

Console.WriteLine($"Ending Floor: {floor}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

Console.WriteLine($"First Basement: {firstBasement}");

Console.WriteLine();
Console.ReadKey();
