﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Commands
{
    internal static class CarregaArquivoTreinamentoCommand
    {
        public static string[] Execute()
        {
            var caminhoArquivo = @"C:\Users\marca\Desktop\RedeNeural\treinamento.csv";

            var arquivo = File.ReadAllLines(caminhoArquivo);

            return arquivo;
        }
    }
}
