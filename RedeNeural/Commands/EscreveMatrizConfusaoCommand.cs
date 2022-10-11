using RedeNeural.Helpers;

namespace RedeNeural.Commands
{
    internal static class EscreveMatrizConfusaoCommand
    {
        public static void Execute(int[,] matrizConfusao)
        {
            Console.Write($"".PadRight(10, ' '));
            foreach (var tipo in ValoresEsperadosHelper.IndicesValoresEperados.Reverse())
            {
                Console.Write($"{tipo.Key.PadRight(15, ' ')}");
            }

            Console.WriteLine();

            for (int i = 0; i < 7; i++)
            {
                Console.Write($"{ValoresEsperadosHelper.IndicesValoresEperados.First(a => a.Value == i).Key.PadRight(10, ' ')}");
                for (int j = 0; j < 7; j++)
                {
                    Console.Write($"{matrizConfusao[i, j]}".PadRight(15, ' '));
                }
                Console.WriteLine();
            }
        }
    }
}
