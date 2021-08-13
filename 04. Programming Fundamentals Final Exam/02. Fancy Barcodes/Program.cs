using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _02._Fancy_Barcodes
{
    class Program
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(@"@#+[A-Z][A-Za-z0-9]{4,}[A-Z]@#+");

            int n = int.Parse(Console.ReadLine());

            List<string> barcodes = new List<string>();

            for (int i = 0; i < n; i++)
            {
                barcodes.Add(Console.ReadLine());
            }

            foreach (var barcode in barcodes)
            {
                if (!regex.IsMatch(barcode))
                {
                    Console.WriteLine("Invalid barcode");
                }
                else
                {
                    string defaultGroup = "00";
                    string productGroup = String.Empty;

                    foreach (var character in barcode)
                    {
                        if (char.IsDigit(character))
                        {
                            productGroup += character;
                        }
                    }

                    if (productGroup != "")
                    {
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                    else
                    {
                        Console.WriteLine($"Product group: {defaultGroup}");
                    }
                }
            }
        }
    }
}
