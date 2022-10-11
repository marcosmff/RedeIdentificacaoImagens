using RedeNeural.Entidades;
using RedeNeural.Helpers;

namespace RedeNeural.Commands
{
    internal static class TestaRedeCommand
    {
        public static void Execute(Camada[] rede)
        {
            var arquivoTeste = CarregaArquivoTesteCommand.Execute();

            var matrizConfusao = new int[7, 7];

            foreach (var linha in arquivoTeste)
            {
                var colunas = linha.Split(ParametrizacaoHelper.SEPARADOR_ARQUIVO);

                // Carrega os dados na entrada da primeira camada
                for (int i = 1; i < colunas.Length; i++)
                {
                    rede[0].Neuronios[i - 1].Valor = Convert.ToDouble(colunas[i]);
                }

                var valoresEsperados = ValoresEsperadosHelper.ValoresEperados[colunas[0]];

                for (int i = 1; i < rede.Length; i++)
                {
                    foreach (var neuronio in rede[i].Neuronios)
                    {
                        var somatorio = neuronio.Ligacoes.Sum(ligacao => ligacao.Peso * ligacao.Neuronio.Valor);
                        neuronio.Valor = 1 / (1 + Math.Exp(-somatorio));
                    }
                }

                var maior = 0.0;
                var indiceMaior = 0;

                for (int i = 0; i < rede[2].Neuronios.Length; i++)
                {
                    if (rede[2].Neuronios[i].Valor > maior)
                    {
                        maior = rede[2].Neuronios[i].Valor;
                        indiceMaior = i;
                    }
                }

                var indiceCorreto = ValoresEsperadosHelper.IndicesValoresEperados[colunas[0]];

                matrizConfusao[indiceMaior, indiceCorreto]++;
            }

            EscreveMatrizConfusaoCommand.Execute(matrizConfusao);
        }
    }
}
