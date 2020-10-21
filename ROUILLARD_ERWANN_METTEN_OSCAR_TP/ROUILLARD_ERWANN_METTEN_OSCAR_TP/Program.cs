using System;
using System.Collections.Generic;

namespace ROUILLARD_ERWANN_METTEN_OSCAR_TP
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            char charcutter = 'f';
            string sentence = "Le fleuve fait le bonheur des enfants";

            for (int i = 0; i < CutString(charcutter, sentence).Length; i++) //Permet d'afficher tout le tableau
            {
                Console.WriteLine(CutString(charcutter, sentence)[i]);
            }

        }
        
        
        
        
        

        static string[] CutString(char cutter, string sentencetocut) //Fonction répondant à la 1ère question
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

            return CuttedString.ToArray();
        }
    }
}