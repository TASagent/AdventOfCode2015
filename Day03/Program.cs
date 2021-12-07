using AoCTools;

const string inputFile = @"../../../../input03.txt";

Console.WriteLine("Day 03 - Perfectly Spherical Houses in a Vacuum");
Console.WriteLine("Star 1");
Console.WriteLine();

{
    Dictionary<Point2D, int> visitDict = new Dictionary<Point2D, int>();

    Point2D position = (0, 0);

    string file = File.ReadAllText(inputFile);
    visitDict[position] = 1;

    foreach (char c in file)
    {
        switch (c)
        {
            case '^':
                position += Point2D.YAxis;
                break;

            case 'v':
                position -= Point2D.YAxis;
                break;

            case '<':
                position -= Point2D.XAxis;
                break;

            case '>':
                position += Point2D.XAxis;
                break;

            default:
                throw new Exception();
        }

        if (visitDict.ContainsKey(position))
        {
            visitDict[position]++;
        }
        else
        {
            visitDict[position] = 1;
        }
    }

    Console.WriteLine($"The number of houses that receive at least one present is: {visitDict.Count}");
}

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

{
    Dictionary<Point2D, int> visitDict = new Dictionary<Point2D, int>();

    Point2D santaPos = (0, 0);
    Point2D robotPos = (0, 0);

    string file = File.ReadAllText(inputFile);
    visitDict[santaPos] = 2;

    bool santaMove = true;

    foreach (char c in file)
    {
        switch (c)
        {
            case '^':
                if (santaMove)
                {
                    santaPos += Point2D.YAxis;
                }
                else
                {
                    robotPos += Point2D.YAxis;
                }
                break;

            case 'v':
                if (santaMove)
                {
                    santaPos -= Point2D.YAxis;
                }
                else
                {
                    robotPos -= Point2D.YAxis;
                }
                break;

            case '<':
                if (santaMove)
                {
                    santaPos -= Point2D.XAxis;
                }
                else
                {
                    robotPos -= Point2D.XAxis;
                }
                break;

            case '>':
                if (santaMove)
                {
                    santaPos += Point2D.XAxis;
                }
                else
                {
                    robotPos += Point2D.XAxis;
                }
                break;

            default:
                throw new Exception();
        }

        Point2D newPoint2D = santaMove ? santaPos : robotPos;
        if (visitDict.ContainsKey(newPoint2D))
        {
            visitDict[newPoint2D]++;
        }
        else
        {
            visitDict[newPoint2D] = 1;
        }

        santaMove = !santaMove;
    }

    Console.WriteLine($"The number of houses that receive at least one present is: {visitDict.Count}");
}

Console.WriteLine();
Console.ReadKey();
