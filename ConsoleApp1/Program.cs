// See https://aka.ms/new-console-template for more information
using System;

namespace Atividade
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------------- Jogo da Forca ---------------------\n");
            Console.WriteLine("                     Regras do jogo:\n");
            Console.WriteLine(" - Digite uma letra por vez, caso contrário será computado como um erro.\n");
            Console.WriteLine(" - Você pode errar 6 vezes, no sétimo erro será enforcado.\n");


            //Array de palavras disponíveis para jogar.
            string[] worlds = { "banana", "uva", "paralelepipedo", "mouse", "flor", "gato", "cachorro"};

            //Variáveis para armazenar a letra digitada e a palavra escolhida.
            string world = "", letter = "";
            
            //Variáveis para armazenar erros, acertos e a posiçao da letra em questão.
            int errors = 1, assertions = 1, check = 1;

            //Limite de erros
            const int errorslimit = 7;

            //Lógica para escolher a palavra randomicamente
            Random random = new Random();   
            int chosenWorld = random.Next(worlds.Length);
            world = worlds[chosenWorld];    
            string[] worldToArray = new string[world.Length];

            Console.WriteLine("Digite uma letra:");
            while (errors <= errorslimit && check <= worldToArray.Length)
            {
                letter = Console.ReadLine();
                int ocurrences = world.IndexOf(letter);

                if(letter.Length > 1)
                {
                    Console.Write("Digite uma letra por vez! ");
                }
                
                if (letter.Length == 0 || letter == null)
                {
                    Console.Write("Campo vazio! para começar digite uma letra: ");
                }

                if (ocurrences == -1)
                {
                    Console.Write($"A letra digitada não está presente na palavra!! Tentativas erradas: {errors}\n");
                    errors++;
                }
                else
                {
                    Console.Write($"Temos a letra '{letter}'! você fez {assertions} ponto(s). ");
                    assertions++;

                    for (int i = 0; i < world.Length; i++)
                    {
                        if (world[i].ToString() == letter)
                        {
                            worldToArray[i] = letter;

                            if (worldToArray[i] != null && worldToArray[i] != " _ ")
                            {
                                check++;
                            }
                            if(check > worldToArray.Length)
                            {
                                Console.Write("Parabéns, você ganhou, palavra secreta era: ");
                            }
                        }
                        else if (worldToArray[i] is null)
                        {
                            worldToArray[i] = " _ ";
                        }
                    }
                }
            foreach(string item in worldToArray)
                {
                    Console.Write(item);
                }
                Console.WriteLine();
            }
            if(errors > errorslimit)
            {
                Console.Write($"Você foi enforcado!!! a palavra secreta era {world}");
            }
        }
    }
}
