using System;

namespace SpellTheNumber
{
    class Convert
    {
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
            switch (number)
            {
                case 0:
                    return "Zero";
                case 1:
                    return "One";
                case 2:
                    return "Two";
                case 3:
                    return "Three";
                case 4:
                    return "Four";
                case 5:
                    return "Five";
                case 6:
                    return "Six";
                case 7:
                    return "Seven";
                case 8:
                    return "Eight";
                case 9:
                    return "Nine";
                case 10:
                    return "Ten";
                case 11:
                    return "Eleven";
                case 12:
                    return "Twelve";
                case 13:
                    return "Thirteen";
                case 14:
                    return "Fourteen";
                case 15:
                    return "Fifteen";
                case 16:
                    return "Sixteen";
                case 17:
                    return "Seventeen";
                case 18:
                    return "Eighteen";
                case 19:
                    return "Nineteen";
                case 20:
                    return "Twenty";
                case 30:
                    return "Thirty";
                case 40:
                    return "Forty";
                case 50:
                    return "Fifty";
                case 60:
                    return "Sixty";
                case 70:
                    return "Seventy";
                case 80:
                    return "Eighty";
                case 90:
                    return "Ninty";
                case 100:
                    return "Hundrad";
                case 1000:
                    return "Thousand";
                case 100000:
                    return "Lakh";
                case 10000000:
                    return "Crore";
                case 1000000000:
                    return "Arab";
            }
            return "";
        }
        /// <summary>
        /// This functions returns the number with which division number and remainder number needs to be calculated
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private long GetValueForDivAndMod(int length)
        {
            switch (length)
            {
                case 2:
                    return 10;
                case 3:
                    return 100;
                case 4:
                case 5:
                    return 1000;
                case 6:
                case 7:
                    return 100000;
                case 8:
                case 9:
                    return 10000000;
                case 10:
                case 11:
                    return 1000000000;
                default:
                    return 10000000;
            }
            return 0;
        }
    }
}
