using RedeNeural.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Commands
{
    internal static class ControlaRedeCommand
    {
        

        public static void Execute()
        {
            var rede = CriaRedeCommand.Execute(3, 18, 7);

            var arquivo = CarregaArquivoTreinamentoCommand.Execute();

            rede = TreinaRedeCommand.Execute(rede, arquivo);

            TestaRedeCommand.Execute(rede);
        }
    }
}
