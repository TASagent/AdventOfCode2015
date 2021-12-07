using System.Text;
using System.Security.Cryptography;

const string inputFile = @"../../../../input04.txt";

Console.WriteLine("Day 04 - The Ideal Stocking Stuffer");
Console.WriteLine("Star 1");
Console.WriteLine();

string input = File.ReadAllText(inputFile);

using MD5 md5 = MD5.Create();

long modifier = 1;
while (true)
{
    string hash = GetMd5Hash(md5, $"{input}{modifier.ToString()}");
    if (hash.StartsWith("00000"))
    {
        break;
    }
    modifier++;
}

Console.WriteLine($"The answer is: {modifier}");

Console.WriteLine();
Console.WriteLine("Star 2");
Console.WriteLine();

while (true)
{
    string hash = GetMd5Hash(md5, $"{input}{modifier.ToString()}");
    if (hash.StartsWith("000000"))
    {
        break;
    }
    modifier++;
}

Console.WriteLine($"The answer is: {modifier}");

Console.WriteLine();
Console.ReadKey();


static string GetMd5Hash(MD5 md5Hash, string input)
{
    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

    StringBuilder sBuilder = new StringBuilder();

    for (int i = 0; i < data.Length; i++)
    {
        sBuilder.Append(data[i].ToString("x2"));
    }

    return sBuilder.ToString();
}
