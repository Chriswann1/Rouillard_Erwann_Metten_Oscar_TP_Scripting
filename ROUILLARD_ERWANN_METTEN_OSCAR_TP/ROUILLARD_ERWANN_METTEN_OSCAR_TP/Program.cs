using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace ROUILLARD_ERWANN_METTEN_OSCAR_TP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char charcutter = 'f';
            string sentence = "Le fleuve fait le bonheur des enfants";

            for (int i = 0; i < CutString(charcutter, sentence).Count; i++) //Permet d'afficher tout le tableau
            {
                Console.WriteLine(CutString(charcutter, sentence)[i]);
            }

            string sentencereverse = "la vie est un long fleuve tranquille";
            Console.WriteLine(ReverseSentence(sentencereverse));
            
            Console.WriteLine(ReverseWordNotSentence(sentencereverse));

            Console.WriteLine(ReverseSentenceNotWord(sentence));

        }
        
        
        
        
        

        static List<string> CutString(char cutter, string sentencetocut) //Fonction répondant à la 1ère question
        {
            string cache = null;
            List<string> CuttedString = new List<string>();
            for (int i = 0; i < sentencetocut.Length; i++)
            {
                if (sentencetocut[i] != 'f')
                {
                    cache += sentencetocut[i].ToString();
                }

                else if (sentencetocut[i] == 'f')
                {
                    //Console.WriteLine("Cutted");                  //Permet de voir quand la fonction cut la phrase
                    CuttedString.Add(cache);
                    cache = null;
                }
                //Console.WriteLine(i);                                //Permet de voir l'index
            }
            CuttedString.Add(cache);

            return CuttedString;
        }






        static string ReverseSentence(string sentencetoreverse) // Fonction répondant à la 2ème question
        {
            string reversed = null;
            for (int i = sentencetoreverse.Length -1; i >= 0; i--) // Inverse la phrase entière
            {
                reversed += sentencetoreverse[i];
            }
            return reversed;
        }



        static string ReverseWordNotSentence(string sentenceword) // Fonction répondant à la 3ème question
        {
            string cache = null;
            string reversed = null;
            string result = null;
            string lastchar;
            for (int i = 0; i < sentenceword.Length; i++)  // découpe chaque mot grâce aux espaces
            {
                if (sentenceword[i] != ' ')
                {
                    cache += sentenceword[i].ToString();
                }

                else if (sentenceword[i] == ' ' && cache != null) // inverse les lettres des mots
                {
                    for (int y = cache.Length-1; y >= 0; y--)
                        {
                            reversed += cache[y];
                        }

                        cache = null;
                        result += reversed + ' ';  // ajoute les mots inversés dans la phrase
                        reversed = null;
                }
            }
            if (cache != null)
            {
                for (int y = cache.Length-1; y >= 0; y--)  // permet d'ajouter le dernier mot dans certaines situations
                {
                    reversed += cache[y];
                }

                cache = null;
                result += reversed + ' ';
                reversed = null;
            }
            return result;
        }

        static string ReverseSentenceNotWord(string sentence)
        {
            string result = null;
            List<string> wordcache = new List<string>();
            string cache = null;
            
            for (int i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] != ' ')
                {
                    cache += sentence[i];
                }
                else
                {
                    wordcache.Add(cache);
                    cache = null;
                }
            }
            wordcache.Add(cache);
            cache = null;
            for (int y = wordcache.Count-1; y >= 0 ; y--)
            {
                Console.WriteLine(y);
                result += wordcache[y];
            }
            return result;
        }
    }
}