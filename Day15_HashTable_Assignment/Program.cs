using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day15_HashTable_Assignment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hash Table Assignment");

            string paragraph = "Paranoids are not paranoid because they are paranoid but because they keep putting themselves deliberately into paranoid avoidable situations";
            string[] words = paragraph.Split(' ');

            FrequencyCounter counter = new FrequencyCounter(words.Length);

            foreach (string word in words)
            {
                counter.AddWord(word.ToLower());
            }

            counter.DisplayFrequency();

            Console.ReadLine();
        }
    }
}
