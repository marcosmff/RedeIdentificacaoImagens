using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Commands
{
    internal static class CarregaArquivoTesteCommand
    {
        public static string[] Execute()
        {
            var caminhoArquivo = @"C:\Users\marca\Desktop\RedeNeural\teste.csv";

            var arquivo = File.ReadAllLines(caminhoArquivo);

            return arquivo;
        }
    }
}
