using System;

namespace XmlParser
{
    class Word {
        public int Long;
    }

    class WordList
    {
        public Word[] Words;
    }
    class Program
    {
        static void Main(string[] args)
        {
            String currentLocation = System.Reflection.Assembly.GetEntryAssembly().Location;
            Console.WriteLine(currentLocation);
        }
    }
}
