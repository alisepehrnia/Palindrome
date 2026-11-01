using System;
using System.Collections.Generic;
using System.Linq;

namespace Palindrome
{
    class Program
    {
        public static List<string> list = new List<string>(); //A list to save generated chars combinations 

        static void CharsCombinationGenerator(List<char> chars, int count, string prefix = "")
        {
            if (string.IsNullOrEmpty(prefix)) //Clear output list if this is first recursive run of function
                list.Clear();

            if(count <= 0) //If remained chars is zero or less add it to list and exit function 
            {
                list.Add(prefix);
                return;
            }

            for (int i = 0; i < chars.Count; i++) //Recursive run
            {
                CharsCombinationGenerator(chars.Except(chars[i].ToString()).ToList(), count - 1, prefix + chars[i]); //Run this function again without a used character in previous run
            }
        }
        static string MakeStringPalindrome(string s)
        {
            string trail = s.Replace(s.Last().ToString(), ""); //Remove last character of string and save it to trail

            return s + new string(trail.Reverse().ToArray()); //Return combination of input string and reverse trail
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Palindrome - Programmed By Ali Sepehrnia (96121038)"); //Project Author Information
            Console.WriteLine("Enter an string that contains all of your characters:"); //A Massage For Program Client
            string input = Console.ReadLine(); //Read an String From Input
            input = input.Replace(" ", ""); //Replace All Space Characters With Null
            input = input.ToLower(); //Convert All Characters To Lowercase
            input = new string(input.ToHashSet().ToArray()); //Remove all duplicate characters
            CharsCombinationGenerator(input.ToList(), input.Length); //Add all possible combinations of input chars into list
            List<string> palindromes = new List<string>(); //Make new list to add palindromes to
            foreach(string s in list) //Make every string in list palindrome and add it to palindromes list
            {
                palindromes.Add(MakeStringPalindrome(s));
            }
            Console.WriteLine("Result:"); //A Massage For Program Client
            foreach (string s in palindromes) //Print all of palindromes
            {
                Console.WriteLine(s);
            }
            Console.ReadKey(); //A wrapper to prevent cmd window to close
        }
    }
}
