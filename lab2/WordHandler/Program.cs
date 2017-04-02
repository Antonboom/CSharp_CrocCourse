using System;
using System.Collections.Generic;

namespace WordHandler
{
    class WordBuilder {
        public static bool CouldBuild(string longWord, string smallWord) {
            if (smallWord.Length > longWord.Length) {
                return false;
            }

            foreach (char symbol in smallWord) {
                if (!longWord.Contains(symbol.ToString())) {
                    return false;
                }

                longWord.Remove(longWord.IndexOf(symbol), 1);
            }

            return true;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<string> mylist = new List<string>(new string[] { "element1", "element2", "element3" });
            
            Console.WriteLine("Hello World!");
            WordBuilder.CouldBuild("lol", "asdasdasdasd");
        }
    }
}
