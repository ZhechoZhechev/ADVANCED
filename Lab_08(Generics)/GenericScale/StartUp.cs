using System;

namespace GenericScale
{
    class StartUp
    {
        static void Main()
        {
            EqualityScale<string> demo = new EqualityScale<string>("Muncho", "Muncho");
            Console.WriteLine(demo.AreEqual());
        }
    }
}
