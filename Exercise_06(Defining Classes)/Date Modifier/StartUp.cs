using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main()
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            int diffIndays = DateModifier.DiffBtweenTwoDate(firstDate, secondDate);

            Console.WriteLine(diffIndays);
        }
    }
}
