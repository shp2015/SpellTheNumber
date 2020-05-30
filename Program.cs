using System;

namespace SpellTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter the Number to Read :- ");

                string numberToRead = Console.ReadLine();
                long number = 0;
                if (Int64.TryParse(numberToRead, out number))
                {
                    Convert c = new Convert();
                    Console.WriteLine("Here is the Word Format :- ");
                    //Get word representation and write it
                    Console.WriteLine(c.ConvertNumericToWordFormat(number, numberToRead.Length));
                }
                else
                {
                    Console.WriteLine("Please enter valid Numeric Value, Try again.");
                }
            }
        }
    }
}
