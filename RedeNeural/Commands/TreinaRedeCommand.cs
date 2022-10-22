using RedeNeural.Entidades;
using RedeNeural.Helpers;

namespace RedeNeural.Commands
{
    internal static class TreinaRedeCommand
    {
        public static Camada[] Execute(Camada[] rede, string[] arquivo)
        {
            var tamanhoRede = rede.Length;
            using (StreamWriter graficoErro = File.CreateText(ParametrizacaoHelper.ARQUIVO_DADOS_GRAFICO))
            {
                using (StreamWriter sw = File.CreateText(ParametrizacaoHelper.ARQUIVO_VALORES_ERROS_EPOCA))
                {
                    for (int x = 0; x < ParametrizacaoHelper.EPOCAS; x++)
                    {
                        var erroEpoca = 0.0;

                        sw.Write($"\n----------------------------epoca {x} -----------------------------------\n");
                        foreach (var linha in arquivo)
                        {
                            var colunas = linha.Split(ParametrizacaoHelper.SEPARADOR_ARQUIVO);

                            // Carrega os dados na entrada da primeira camada
                            for (int i = 1; i < colunas.Length; i++)
                            {
                                rede[0].Neuronios[i - 1].Valor = Convert.ToDouble(colunas[i]);
                            }

                            var valoresEsperados = ValoresEsperadosHelper.ValoresEperados[colunas[0]];

                            // Calcula valores das camadas
                            for (int i = 1; i < tamanhoRede; i++)
                            {
                                foreach (var neuronio in rede[i].Neuronios)
                                {
                                    var somatorio = neuronio.Ligacoes.Sum(ligacao => ligacao.Peso * ligacao.Neuronio.Valor);
                                    neuronio.Valor = 1 / (1 + Math.Exp(-somatorio));
                                }
                            }

                            // Calcula o erro da ultima camada
                            for (int i = 0; i < rede[tamanhoRede - 1].Neuronios.Length; i++)
                            {
                                var fatorErro = valoresEsperados[i] - rede[tamanhoRede - 1].Neuronios[i].Valor;
                                rede[tamanhoRede - 1].Neuronios[i].Erro = rede[tamanhoRede - 1].Neuronios[i].Valor * (1 - rede[tamanhoRede - 1].Neuronios[i].Valor) * fatorErro;

                                erroEpoca += Math.Abs(rede[tamanhoRede - 1].Neuronios[i].Erro);
                            }


                            // Calcula o erro das camadas intermediaria
                            for (int camada = rede.Length - 2; camada > 0; camada--)
                            {
                                for (int i = 0; i < rede[camada].Neuronios.Length; i++)
                                {
                                    var fatorErro = rede[camada + 1].Neuronios.Sum(neuronio => neuronio.Erro * neuronio.Ligacoes[i].Peso);
                                    rede[camada].Neuronios[i].Erro = rede[camada].Neuronios[i].Valor * (1 - rede[camada].Neuronios[i].Valor) * fatorErro;
                                }
                            }

                            // Recalcula os pesos das camadas
                            for (int camada = rede.Length - 1; camada > 0; camada--)
                            {
                                for (int i = 0; i < rede[camada].Neuronios.Length; i++)
                                {
                                    for (int j = 0; j < rede[camada].Neuronios[i].Ligacoes.Length; j++)
                                    {
                                        rede[camada].Neuronios[i].Ligacoes[j].Peso = rede[camada].Neuronios[i].Ligacoes[j].Peso + ParametrizacaoHelper.TAXA_APRENDIZAGEM * rede[camada].Neuronios[i].Ligacoes[j].Neuronio.Valor * rede[camada].Neuronios[i].Erro;
                                    }

                                }
                            }

                            sw.Write($"\nesperado      ");

                            foreach (var valorEsperado in valoresEsperados)
                            {
                                sw.Write($"{valorEsperado}     ");
                            }

                            sw.Write($"\nvalores     ");
                            foreach (var neuronio in rede[tamanhoRede - 1].Neuronios)
                            {

                                sw.Write($"{neuronio.Valor}     ");
                            }

                            sw.Write($"\nerros     ");
                            foreach (var neuronio in rede[tamanhoRede - 1].Neuronios)
                            {

                                sw.Write($"{neuronio.Erro}     ");
                            }
                        }

                        var erroTeste = TestaRedeCommand.Execute(rede, false);

                        graficoErro.WriteLine($"{x}{ParametrizacaoHelper.SEPARADOR_ARQUIVO}{erroEpoca/2100}{ParametrizacaoHelper.SEPARADOR_ARQUIVO}{erroTeste / 210}");
                    }

                }
            }

            return rede;
        }
    }
}
