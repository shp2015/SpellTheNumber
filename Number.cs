﻿using System.Numerics;

namespace SpellTheNumber
{
    class Convert
    {
        public string ConvertNumericToWordFormat(long numericFormat, int length)
        {
            if(numericFormat >= 0 && numericFormat <= 20)
            {
                return GetUniqueNamesForNumbers(numericFormat);
            }
            return "Word Format";
        }

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
    }
}
