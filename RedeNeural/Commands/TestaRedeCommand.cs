using RedeNeural.Entidades;
using RedeNeural.Helpers;
using System.Text;

namespace RedeNeural.Commands
{
    internal static class TestaRedeCommand
    {
        public static double Execute(Camada[] rede, bool escreveMatrizConfusao)
        {
            var arquivoTeste = File.ReadAllLines(ParametrizacaoHelper.ARQUIVO_TESTE);

            var matrizConfusao = new int[7, 7];

            var erroTeste = 0.0;

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

                // Calcula o erro da ultima camada
                for (int i = 0; i < rede[rede.Length - 1].Neuronios.Length; i++)
                {
                    var fatorErro = valoresEsperados[i] - rede[rede.Length - 1].Neuronios[i].Valor;
                    erroTeste += Math.Abs(rede[rede.Length - 1].Neuronios[i].Valor * (1 - rede[rede.Length - 1].Neuronios[i].Valor) * fatorErro);
                }

                if (escreveMatrizConfusao)
                {
                    var maior = 0.0;
                    var indiceMaior = 0;

                    for (int i = 0; i < rede[rede.Length - 1].Neuronios.Length; i++)
                    {
                        if (rede[rede.Length - 1].Neuronios[i].Valor > maior)
                        {
                            maior = rede[rede.Length - 1].Neuronios[i].Valor;
                            indiceMaior = i;
                        }
                    }

                    var indiceCorreto = ValoresEsperadosHelper.IndicesValoresEperados[colunas[0]];

                    matrizConfusao[indiceCorreto, indiceMaior]++;
                }
            }

            if (escreveMatrizConfusao)
            {
                EscreveMatrizConfusaoCommand.Execute(matrizConfusao);

                var acuracia = 0.0;

                var stringRecall = new StringBuilder();
                var stringPrecisao = new StringBuilder();
                var stringFScore = new StringBuilder();

                stringRecall.Append($"Recall".PadRight(10, ' '));
                stringPrecisao.Append($"Precisao".PadRight(10, ' '));
                stringFScore.Append($"F-Score".PadRight(10, ' '));

                for (int i = 0; i < 7; i++)
                {
                    acuracia += matrizConfusao[i, i];

                    var recall = (double)matrizConfusao[i, i] / 30D;
                    var precisao = CalculaPrecisao(matrizConfusao, i);
                    var fScore = 2 * (recall * precisao) / (recall + precisao);
                    stringRecall.Append($"{(recall * 100).ToString("F")}%".PadRight(15, ' '));
                    stringPrecisao.Append($"{(precisao * 100).ToString("F")}%".PadRight(15, ' '));
                    stringFScore.Append($"{(fScore * 100).ToString("F")}%".PadRight(15, ' '));
                }

                acuracia = (acuracia / 210) * 100;

                Console.WriteLine(stringRecall.ToString());
                Console.WriteLine(stringPrecisao.ToString());
                Console.WriteLine(stringFScore.ToString());
                Console.WriteLine();
                Console.WriteLine($"Acuracia = {acuracia.ToString("F")}%");
                Console.WriteLine($"Erro = {(100 - acuracia).ToString("F")}%");
            }

            return erroTeste;
        }

        private static double CalculaPrecisao(int[,] matrizConfusao, int coluna)
        {
            var somaPrecisao = 0;

            for (int i = 0; i < 7; i++)
            {
                somaPrecisao += matrizConfusao[i, coluna];
            }

            return (double)matrizConfusao[coluna, coluna] / (double)somaPrecisao;
        }
    }
}
