using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    public static void FillArray(int size, List<int> list)
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string fileName = "array.txt";
        string fullPath = Path.Combine(desktopPath, fileName);
        Random rnd = new Random();
        using (StreamWriter writer = new StreamWriter(fullPath))
        {
            for (int i = 0; i < size * 2; i += 2)
            {
                int randomNumber = rnd.Next(0, Int16.MaxValue);
                list.Add(randomNumber);
                writer.WriteLine("MOV WORD PTR [BX+{0}], {1}D", i, randomNumber);
            }
        }
    }
    public static void SortArray(List<int> list, StreamWriter writer)
    {
        list.Sort();
        foreach (int i in list)
        {
            writer.WriteLine(i);
        }
    }
    static void Main(string[] args)
    {
        try
        {
            List<int> intList = new List<int>();
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "sorted_array.txt";
            string fullPath = Path.Combine(desktopPath, fileName);
            using (StreamWriter writer = new StreamWriter(fullPath))
            {
                Console.Write("How many elements to add?: ");
                int size = Convert.ToInt32(Console.ReadLine());
                FillArray(size, intList);
                SortArray(intList, writer);

            }
            Console.WriteLine("SUCCESS");
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }

        Console.ReadLine();
    }
}