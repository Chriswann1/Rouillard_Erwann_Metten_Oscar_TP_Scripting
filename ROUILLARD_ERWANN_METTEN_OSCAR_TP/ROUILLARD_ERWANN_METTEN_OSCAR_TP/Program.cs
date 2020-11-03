  using System;
using System.Collections.Generic;
using System.Linq;

//INDEV = In development

namespace ROUILLARD_ERWANN_METTEN_OSCAR_TP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char charcutter = 'f';
            
            string sentence = "Le fleuve fait le bonheur des enfants";
            string sentencereverse = "la vie est un long fleuve tranquille";
            
            int[] entiers = { 8, 6, 48, 3, 50 };
            
            List<int> Entiers1 = new List<int> {5,7,9,63,65,41};
            List<int> Entiers2 = new List<int> {9,3,7,20,75,96,43,85};
            List<int> Entiers3 = new List<int> {1,25,45,5,7,9,63,65,41,1,25,25,45,1};
            
            Console.WriteLine("--------------> Sortie Exo 1 <--------------");
            for (int i = 0; i < CutString(charcutter, sentence).Count; i++) //Permet d'afficher tout le tableau de la 1ère question
            {
                Console.WriteLine(CutString(charcutter, sentence)[i]);
            }


            Console.WriteLine("--------------> Sortie Exo 2 <--------------");
            Console.WriteLine(ReverseSentence(sentencereverse)); //Test 2ème question
            
            Console.WriteLine("--------------> Sortie Exo 3 <--------------");
            Console.WriteLine(ReverseWordNotSentence(sentencereverse)); //Test 3ème question

            Console.WriteLine("--------------> Sortie Exo 4 <--------------");
            Console.WriteLine(ReverseSentenceNotWord(sentence)); //Test 4ème question

            
            
            Console.WriteLine("--------------> Sortie Exo 5 <--------------");
            Console.WriteLine("L'index le plus petit est" + SmallestIndex(entiers)); // Test 5ème question
            
            Console.WriteLine("--------------> Sortie Exo 6 <--------------");
            for (int i = 0; i < SortBubble(entiers).Length; i++) //Permet d'afficher tout le tableau de la 6ème question
            {
                Console.WriteLine(SortBubble(entiers)[i]);
            }
            
            Console.WriteLine("--------------> Sortie Exo 7 <--------------");
            for (int i = 0; i < InsertionSort(entiers).Length; i++)  // Permet d'afficher tout le tableau de la 7ème question
            {
                Console.WriteLine(InsertionSort(entiers)[i]);
            }

            Console.WriteLine("--------------> Sortie Exo 8 <--------------");
            foreach (int Valeur in Fusion(Entiers1,Entiers2))
            {
                Console.WriteLine(Valeur);
            }

            Console.WriteLine("--------------> Sortie Exo 9 <--------------");
            foreach (int elements in triFusion(Entiers3))
            {
                Console.WriteLine("TriFusion : " + elements);
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
                //Console.WriteLine(y);
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

        static int[] SortBubble(int[] bubble) // Fonction répondant à la 6ème question
        {
            int cache1;
            int cache2;
            for (int i = 0; i < bubble.Length; i++)  
            {                                                // les 2 boucles For permettent de faire le bon
                for (int y = 0; y < bubble.Length; y++)      // nombre d'itérations pour la longueur du tableau
                {
                    if (y+1 != bubble.Length && bubble[y] > bubble[y+1])  //On vérifie si l'élément suivant est plus petit que l'élément actuel
                    {
                        cache1 = bubble[y];
                        cache2 = bubble[y + 1];
                        bubble[y] = cache2;                            //On inverse les 2 éléments
                        bubble[y + 1] = cache1;
                    }
                }
            }

            return bubble;
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
                        //Console.WriteLine("index"+ y);
                    }
                }
            }
            return Arraytosort;
        }
        
        static List<int> Fusion (List<int> entierA, List<int> entierB) //Fonction réponse à l'exo 8 INDEV
        {
            int n = 0;
            if (!entierA.Any() && !entierB.Any())
            {
                return new List<int>() {0};
            }
            else if (!entierA.Any())
            {
                return entierB;
            }
            else if (!entierB.Any())
            {
                return entierA;
            }
            if (entierA[n] <= entierB[n])
            {                           // On a essayé beaucoup de méthodes mais toutes infructueuses.
                List<int> listA = new List<int>(); 
                listA.AddRange(entierA.Skip(n+1));
                return new List<int>(){entierA[n]}.Concat(Fusion(listA, entierB)).ToList();
                //return null; // Pour pouvoir lancer le programme
                n = n + 1;
            }
            else
            {
                List<int> listB = new List<int>(); 
                listB.AddRange(entierA.Skip(n+1));
                return new List<int>(){entierA[n]}.Concat(Fusion(entierA, listB)).ToList();
                n = n + 1;
            }

        }
        
        static List<int> triFusion(List<int> listtocut) //Fonction réponse à l'exo 9
        {
            if (listtocut.Count <= 1)
            {
                return listtocut;
            }
            Console.WriteLine("in recursive"+listtocut.Count);
            
            List<int> lista = new List<int>();
            List<int> listb = new List<int>();
            
            int half = (listtocut.Count/2);
            
            for (int i = 0; i < half; i++)
            {
                lista.Add(listtocut[i]);
                //Console.WriteLine(i);
            }

            for (int i = half; i < listtocut.Count; i++)
            {
                listb.Add(listtocut[i]);
                //Console.WriteLine(i);
            }
            
            return Fusion(triFusion(lista),triFusion(listb));
            
            
        }
        
        
        
    }
}