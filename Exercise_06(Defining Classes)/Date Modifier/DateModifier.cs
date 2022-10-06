using System;
using System.Collections.Generic;
using System.Text;

namespace DateModifier
{
    public static class DateModifier
    {
        public static int DiffBtweenTwoDate(string firstDate, string secondDate) 
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);

            TimeSpan diffInDays = dateTwo - dateOne;

            return Math.Abs(diffInDays.Days);
        }
    }
}
