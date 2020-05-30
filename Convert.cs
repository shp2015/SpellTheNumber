using System;
using System.Collections.Generic;

namespace SpellTheNumber
{
    class Convert
    {
        private Dictionary<long, string> uniqueNameDictionary = new Dictionary<long, string>();
        private Dictionary<int, int> NumberToDivAndModDictionary = new Dictionary<int, int>();
        public Convert()
        {
            InitializeDictionaryObjects();
        }
        //Initialize the dictionary objects at the time of initializing the class
        private void InitializeDictionaryObjects()
        {
            InitializeUniqueNameDictionary();
            InitializeNumberToDivAndModDictionary();
        }
        private void InitializeUniqueNameDictionary()
        {
            uniqueNameDictionary.Add(0, "Zero");
            uniqueNameDictionary.Add(1, "One");
            uniqueNameDictionary.Add(2, "Two");
            uniqueNameDictionary.Add(3, "Three");
            uniqueNameDictionary.Add(4, "Four");
            uniqueNameDictionary.Add(5, "Five");
            uniqueNameDictionary.Add(6, "Six");
            uniqueNameDictionary.Add(7, "Seven");
            uniqueNameDictionary.Add(8, "Eight");
            uniqueNameDictionary.Add(9, "Nine");
            uniqueNameDictionary.Add(10, "Ten");
            uniqueNameDictionary.Add(11, "Eleven");
            uniqueNameDictionary.Add(12, "Twelve");
            uniqueNameDictionary.Add(13, "Thirteen");
            uniqueNameDictionary.Add(14, "Fourteen");
            uniqueNameDictionary.Add(15, "Fifteen");
            uniqueNameDictionary.Add(16, "Sixteen");
            uniqueNameDictionary.Add(17, "Seventeen");
            uniqueNameDictionary.Add(18, "Eighteen");
            uniqueNameDictionary.Add(19, "Nineteen");
            uniqueNameDictionary.Add(20, "Twenty");
            uniqueNameDictionary.Add(30, "Thirty");
            uniqueNameDictionary.Add(40, "Forty");
            uniqueNameDictionary.Add(50, "Fifty");
            uniqueNameDictionary.Add(60, "Sixty");
            uniqueNameDictionary.Add(70, "Seventy");
            uniqueNameDictionary.Add(80, "Eighty");
            uniqueNameDictionary.Add(90, "Ninty");
            uniqueNameDictionary.Add(100, "Hundrad");
            uniqueNameDictionary.Add(1000, "Thousand");
            uniqueNameDictionary.Add(100000, "Lakh");
            uniqueNameDictionary.Add(10000000, "Crore");
            uniqueNameDictionary.Add(1000000000, "Arab");
        }
        private void InitializeNumberToDivAndModDictionary()
        {
            NumberToDivAndModDictionary.Add(2, 10);
            NumberToDivAndModDictionary.Add(3, 100);
            NumberToDivAndModDictionary.Add(4, 1000);
            NumberToDivAndModDictionary.Add(5, 1000);
            NumberToDivAndModDictionary.Add(6, 100000);
            NumberToDivAndModDictionary.Add(7, 100000);
            NumberToDivAndModDictionary.Add(8, 10000000);
            NumberToDivAndModDictionary.Add(9, 10000000);
            NumberToDivAndModDictionary.Add(10, 1000000000);
            NumberToDivAndModDictionary.Add(11, 1000000000);
            NumberToDivAndModDictionary.Add(12, 10000000);
            NumberToDivAndModDictionary.Add(13, 10000000);
            NumberToDivAndModDictionary.Add(14, 10000000);
            NumberToDivAndModDictionary.Add(15, 10000000);
            NumberToDivAndModDictionary.Add(16, 10000000);
            NumberToDivAndModDictionary.Add(17, 10000000);
        }
        /// <summary>
        /// Function to pass word format for numbers
        /// </summary>
        /// <param name="numericFormat"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public string ConvertNumericToWordFormat(long numericFormat, int length)
        {
            string wordFormat = "";
            //If number is between 0 to 20, Get the word format directly from switch case
            if (numericFormat >= 0 && numericFormat <= 20)
            {
                wordFormat = GetUniqueNamesForNumbers(numericFormat);
            }
            else
            {
                //Retrieve the number to use for calculating remainder and division
                long valueForDivAndMod = GetValueForDivAndMod(length);
                //Calculate remainder and its length for future use
                long remainder = numericFormat % valueForDivAndMod;
                int remainderLength = remainder.ToString().Length;
                //Calculate division and its length for future use
                long division = numericFormat / valueForDivAndMod;
                int divisionLength = division.ToString().Length;
                //For Numbers 21 to 99, special if condition (Can try to remove this and combine with below to if condition)
                if (numericFormat >= 21 && numericFormat <= 99)
                {
                    wordFormat = String.Format("{0}{1}", GetUniqueNamesForNumbers(division * valueForDivAndMod), remainder != 0 ? " " + GetUniqueNamesForNumbers(remainder) : "");
                }
                //If the division is between 1 to 9, then this case will be used (i.e. for 1000, 5999, 1,00,000 etc.)
                else if (division >= 1 && division <= 9)
                {
                    return String.Format("{0} {1}{2}", GetUniqueNamesForNumbers(division), GetUniqueNamesForNumbers(valueForDivAndMod), remainder != 0 ? " " + ConvertNumericToWordFormat(remainder, remainderLength) : "");
                }
                //If the division is greater than 10, then this case will be used (i.e. for 10000, 59999, 10,00,000 etc.)
                else if (division >= 10)
                {
                    return String.Format("{0} {1}{2}", ConvertNumericToWordFormat(division, divisionLength), GetUniqueNamesForNumbers(valueForDivAndMod), remainder != 0 ? " " + ConvertNumericToWordFormat(remainder, remainderLength) : "");
                }
            }
            return wordFormat;
        }
        /// <summary>
        /// This functions is used to get the unique word representation for each values
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string GetUniqueNamesForNumbers(long number)
        {
            return uniqueNameDictionary[number];
        }
        /// <summary>
        /// This functions returns the number with which division number and remainder number needs to be calculated
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private long GetValueForDivAndMod(int length)
        {
            return NumberToDivAndModDictionary[length];
        }
    }
}
