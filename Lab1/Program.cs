using System;
using System.IO;

string filePath = "file.txt";

List<double> GetValuesFromFile(string path)
{
    List<double> values = new List<double>();
    try
    {
        using (StreamReader reader = new StreamReader(path))
        {
            var fileContent = reader.ReadLine();
            if (fileContent != null)
            {
                foreach (string s in fileContent.Split(" "))
                {
                    double value = 0;
                    if (!Double.TryParse(s, out value))
                    {
                        Console.WriteLine("Invalid input");
                        return null;
                    }
                    values.Add(value);
                }
            }
        }
    }
    catch (IOException e)
    {
        Console.WriteLine($"An error occurred while reading the file: {e.Message}");
    }
    return values;
}

List<double> GetValuesFromConsole()
{
    List<double> values = new List<double>();
    char[] coeff = { 'a', 'b', 'c' };
    foreach (char symb in coeff)
    {
        double value;
        Console.Write($"{symb} = ");
        Console.ForegroundColor = ConsoleColor.Green;
        string input = Console.ReadLine();
        while (!Double.TryParse(input, out value))
        {
            Console.ResetColor();
            Console.WriteLine($"Error. Expected a valid real number, got {input} instead");
            Console.Write($"{symb} = ");
            Console.ForegroundColor = ConsoleColor.Green;
            input = Console.ReadLine();
        }
        values.Add(value);
        Console.ResetColor();
    }
    return values;
}

string GetEquasion(double a, double b, double c)
{
    return $"Equation is: ({a.ToString("0.0")}) x^2 + ({b.ToString("0.0")}) x + ({c.ToString("0.0")}) = 0";
}

void SolveQuadraticEquation(double a, double b, double c)
{
    double discriminant = b * b - 4 * a * c;

    if (a == 0)
    {
        Console.WriteLine("a cannot be 0");
    }
    else if (discriminant < 0)
    {
        Console.WriteLine("No real roots");
    }
    else
    {
        double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
        double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);

        int roots = discriminant == 0 ? 1 : 2;
        if (discriminant == 0)
        {
            Console.WriteLine($"There is 1 root: ");
            Console.WriteLine($"x1: {root1}");
        }
        else
        {
            Console.WriteLine($"There are 2 roots: ");
            Console.WriteLine($"x1: {root1}");
            Console.WriteLine($"x2: {root2}");
        }
    }
}

void main()
{
    List<double> coeff;
    Console.WriteLine("Choose application mode: 1 - interactive, 2 - not interactive (file mode)");
    switch (Console.ReadLine())
    {
        case "1": { coeff = GetValuesFromConsole(); break; }
        case "2": { coeff = GetValuesFromFile(filePath); break; }
        default:
            {
                main();
                return;
            }
    }
    if (coeff == null)
    {
        Console.WriteLine("Check your file");
        return;
    }
    double a = coeff[0], b = coeff[1], c = coeff[2];
    Console.WriteLine(GetEquasion(a, b, c));
    SolveQuadraticEquation(a, b, c);
    Console.WriteLine("\nClick 'Enter' to restart, any other key to end");
    if (Console.ReadKey().Key == ConsoleKey.Enter)
    {
        Console.Write("\n\n");
        main();
    }
}

main();