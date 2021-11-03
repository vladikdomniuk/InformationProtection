using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lab_4
{
    class Program
    {
        private static readonly string alphabet = "абвгґдеєжзиіїйклмнопрстуфхцчшщьюя";

        //Shelin a = 7, reverseA = 19, b = 10
        //Anton a = 19, reverseA = 9, b = 10
        //Demid a = 13, reverseA = 28, b = 6

        //My a = 4, reverseA = 25, b = 8
        private static readonly int a = 4;
        private static readonly int b = 8; 
        private static readonly int reverseA = 25; 

        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Enter textfile name:");
            string filename = Console.ReadLine();
            string path = @"D:\4 курс 1 семестр\Захист Інформації\Лаб4\" + filename + ".txt"; //шлях до файлу
            string text = File.ReadAllText(path).ToLower();

            //Console.WriteLine("First Task");
            //FirstTaskDictionary(text);

            //Console.WriteLine("Second Task");
            //SecondTaskDictionary(text);

            //Console.WriteLine("Third Task");
            //ThirdTaskDictionary(text);

            string encodetext = AthensEncode(text);
            Console.WriteLine("Encode text:\n" + encodetext);

            string decodetext = AthensDecode(encodetext);
            Console.WriteLine("\nDecode text:\n" + decodetext);

            //Для дешифрування текстів одногрупників
            //string decodetext = AthensDecode(text);
            //Console.WriteLine("\nDecode text:\n" + decodetext);

            Console.ReadLine();
        }
        public static void FirstTaskDictionary(string text)
        {
            Dictionary<char, int> pair = new Dictionary<char, int>();
            double textlength = GetTextLength(text);
            foreach (char symbol in text)
            {
                if (alphabet.Contains(symbol))
                {
                    if (pair.ContainsKey(symbol))
                    {
                        pair[symbol] += 1;
                    }
                    else
                    {
                        pair.Add(symbol, 1);
                    }
                }
            }
            Console.WriteLine("Symbol    |     Frequency");
            foreach (KeyValuePair<char, int> kvp in pair)
            {
                 Console.WriteLine(kvp.Key + "\t\t" + kvp.Value / textlength);

            }
        }
        public static void SecondTaskDictionary(string text)
        {
            Dictionary<string, int> pair = new Dictionary<string, int>();
            double textlength = GetTextLength(text);
            var words = text.Split(' ');

            foreach (var word in words)
            {
                for(int i = 0; i<word.Length-1;i++)
                {
                    if (alphabet.Contains(word[i]) && alphabet.Contains(word[i + 1]))
                    {
                        string key = "" + word[i] + word[i + 1];
                        if (pair.ContainsKey(key))
                        {
                            pair[key] += 1;
                        }
                        else
                        {
                            pair.Add(key, 1);
                        }

                    }
                    else break;
                }
            }
            //Matrix(pair, textlength); // отримати матрицю частот появи біграм
            Console.WriteLine("Symbol    |     Frequency");
            foreach (KeyValuePair<string, int> kvp in pair)
            {
                Console.WriteLine(kvp.Key + "\t\t" + kvp.Value / (textlength - 1));
            }
        }
        public static void ThirdTaskDictionary(string text)
        {
            Dictionary<string, int> pair = new Dictionary<string, int>();
            double textlength = GetTextLength(text);
            var words = text.Split(' ');

            foreach (var word in words)
            {
                for (int i = 0; i < word.Length - 2; i++)
                {
                    if (alphabet.Contains(word[i]) && alphabet.Contains(word[i + 1]) && alphabet.Contains(word[i + 2]))
                    {
                        string key = "" + word[i] + word[i + 1] + word[i + 2];
                        if (pair.ContainsKey(key))
                        {
                            pair[key] += 1;
                        }
                        else
                        {
                            pair.Add(key, 1);
                        }

                    }
                    else break;
                }
            }

            Console.WriteLine("Symbol    |     Frequency");
            foreach (KeyValuePair<string, int> kvp in pair)
            {
                Console.WriteLine(kvp.Key + "\t\t" + kvp.Value / (textlength - 2));
            }
        }
        private static double GetTextLength(string text)
        {
            double textlength = 0;
            foreach (char symbol in text)
            {
                if (Char.IsLetter(symbol) || Char.IsWhiteSpace(symbol)) textlength++;
            }
            return textlength;
        }
        public static void Matrix(Dictionary<string,int> pair, double textlength)
        {
            //Console.WriteLine(" ,а,б,в,г,ґ,д,е,є,ж,з,и,і,ї,й,к,л,м,н,о,п,р,с,т,у,ф,х,ц,ч,ш,щ,ь,ю,я");
            for(int i = 0; i < alphabet.Length; i++)
            {
                //Console.Write(alphabet[i]+";");
                for (int j = 0; j < alphabet.Length; j++)
                {
                    int count = 0;
                    foreach (KeyValuePair<string, int> kvp in pair)
                    {
                        if(kvp.Key[0]==alphabet[i]&&kvp.Key[1]==alphabet[j])
                        {
                            count = kvp.Value;
                            break;
                        }
                    }
                    Console.Write(count/(textlength-1));
                    if (j != alphabet.Length - 1) Console.Write(";");
                }
                Console.Write("\n");
            }
        }
        private static string AthensEncode(string text)
        {
            string result = "";
            foreach (char word in text)
            {
                if (alphabet.Contains(word))
                {
                    int i = (a * alphabet.IndexOf(word) + b) % alphabet.Length;
                    result += alphabet[i];
                }
                else
                    result += word;
            }
            //Console.WriteLine(result);
            return result;
        }

        private static string AthensDecode(string text)
        {
            string result = "";
            foreach (char word in text)
            {
                if (alphabet.Contains(word))
                {
                    int i = reverseA * (alphabet.IndexOf(word) - b + alphabet.Length) % alphabet.Length;
                    result += alphabet[i];
                }
                else
                    result += word;
            }
            //Console.WriteLine(result);
            return result;
        }
    }
}
