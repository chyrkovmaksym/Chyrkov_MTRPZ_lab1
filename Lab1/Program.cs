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

void main()
{
    List<double> coeff = GetValuesFromFile(filePath);
    for(int i = 0; i < coeff.Count; i++)
    {
        Console.WriteLine(coeff[i]);
    }
}

main();