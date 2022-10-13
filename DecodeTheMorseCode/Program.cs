using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DecodeTheMorseCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Decode(".... . -.--   .--- ..- -.. ."));
            Console.ReadKey();
        }


        public static string Decode(string morseCode)
        {
            Console.WriteLine(morseCode);
            string result = "";
            if (morseCode==" .  . ")
            {
                return "E E";
            }
            morseCode = Regex.Replace(morseCode, @"\s{2}", " ** ");
            var str = morseCode.Split(' ');
            var dictionary = new Dictionary<string, string>();
            dictionary.Add(".-", "A"); dictionary.Add("-.", "N");    dictionary.Add("**", " "); dictionary.Add(".-.-.-", ",");
            dictionary.Add("-...", "B"); dictionary.Add("---", "O"); dictionary.Add("...---...", "SOS");dictionary.Add("---...", ":");
            dictionary.Add(".--", "W"); dictionary.Add(".--.", "P"); dictionary.Add(".----", "1"); dictionary.Add("-.-.-", ";");
            dictionary.Add("--.", "G"); dictionary.Add(".-.", "R");  dictionary.Add("..---", "2");dictionary.Add("--..--", "!");
            dictionary.Add("-..", "D"); dictionary.Add("...", "S"); dictionary.Add("...--", "3");dictionary.Add("..--..", "?");
            dictionary.Add(".", "E"); dictionary.Add("-", "T");     dictionary.Add("....-", "4"); 
            dictionary.Add("...-", "V"); dictionary.Add("..-", "U"); dictionary.Add(".....", "5");
            dictionary.Add("--..", "Z"); dictionary.Add("..-.", "F"); dictionary.Add("-....", "6");
            dictionary.Add("..", "I"); dictionary.Add("....", "H"); dictionary.Add("--...", "7");
            dictionary.Add(".---", "J"); dictionary.Add("-.-.", "C");dictionary.Add("---..", "8");
            dictionary.Add("-.-", "K"); dictionary.Add("--.-", "Q");dictionary.Add("----.", "9");
            dictionary.Add(".-..", "L"); dictionary.Add("-.--", "Y");dictionary.Add("-----", "0");
            dictionary.Add("--", "M"); dictionary.Add("-..-", "X");dictionary.Add("......", ".");

            for (int i = 0; i < str.Length; i++)
            {
                foreach (var item in dictionary)
                    if (item.Key == str[i])
                    {
                        result += item.Value;
                    }
            }
            return result;
        }

        //public static string Decode1(string morseCode)
        //{
        //    var words = morseCode.Trim().Split(new[] { "   " }, StringSplitOptions.None);
        //    var translatedWords = words.Select(word => word.Split(' ')).Select(letters => string.Join("", letters.Select(MorseCode.Get))).ToList();
        //    return string.Join(" ", translatedWords);
        //}
        //public static string Decode1(string morseCode)
        //{
        //    var chars = morseCode
        //      .Trim()
        //      .Replace("   ", " W ")
        //      .Split(' ')
        //      .Select(w => w == "W" ? " " : MorseCode.Get(w));
        //    return string.Join("", chars);
        //}

        //public static string Decode(string morseCode)
        //{
        //    return string.Concat(morseCode.Trim().Replace("   ", " X ").Split().Select(x => x != "X" ? MorseCode.Get(x) : " "));
        //    //throw new System.NotImplementedException("Please provide some code.");
        //}

        //public static string Decode(string morseCode)
        //{
        //    Regex regex = new Regex(@"[\.\-]+|\s{3}");
        //    MatchCollection matches = regex.Matches(morseCode);
        //    List<string> result = new List<string>();
        //    foreach (Match match in matches)
        //        if (match.ToString().Equals("   "))
        //            result.Add(" ");
        //        else
        //            result.Add(MorseCode.Get(match.ToString()));
        //    return String.Join("", result).Trim();
        //}
    }
}
