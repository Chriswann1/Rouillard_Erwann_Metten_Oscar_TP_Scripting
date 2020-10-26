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
            
            Console.WriteLine(ReverseWordNotSentence(sentencereverse));
            
            int[] small = { 5, 6, 4, 20, 1 };
            Console.WriteLine("L'index le plus petit est" + SmallestIndex(small));

            for (int i = 0; i < InsertionSort(small).Length; i++)
            {
                Console.WriteLine(InsertionSort(small)[i]);
            }

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
        
        static string ReverseSentenceNotWord(string sentence) //Fonction répondant à la 4ème question
        {
            string result = null; //Le resultat
            List<string> wordcache = new List<string>(); //On fais un 'cache' pour les mots
            string cache = null; //Le cache pour un mot
            
            for (int i = 0; i < sentence.Length; i++) //Boucle for permettant de séparer les mots dans un string à part (dans la liste wordcache)
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
            wordcache.Add(cache); //Pour le dernier mot de la liste
            cache = null;
            for (int y = wordcache.Count-1; y >= 0 ; y--)
            {
                Console.WriteLine(y);
                result += wordcache[y];
            }
            return result;
        }
        
        static int SmallestIndex(int[] smallIndex)  // Fonction répondant à la 5ème question
        {
            int cache = smallIndex[0];
            int index = 0; 
            for (int i = 0; i < smallIndex.Length; i++) // Boucle qui s'effectue pour le nombre d'entiers contenus dans le tableau
            {
                if (smallIndex[i] < cache)
                {
                    cache = smallIndex[i];                    // ajout du plus petit entier
                    index = Array.IndexOf(smallIndex, cache);  // ajout de l'index du plus petit entier du tableau
                }
            }
            return index;
        }

        static int[] InsertionSort(int[] Arraytosort) //Réponse à l'exo 7
        {
            int cache = 0; //Cache du nombre au dessus (y+1)
            for (int i = 0; i < Arraytosort.Length; i++) //Boucle permettant de répéter le triage 
            {
                for (int y = 0; y < Arraytosort.Length; y++) //Boucle permettant le triage
                {
                    if (y+1 != Arraytosort.Length && Arraytosort[y] > Arraytosort[y + 1])
                    {
                        cache = Arraytosort[y + 1];
                        Arraytosort[y + 1] = Arraytosort[y];
                        Arraytosort[y] = cache;
                        Console.WriteLine("index"+ y);
                    }
                }
            }
            return Arraytosort;
        }
        
    }
}