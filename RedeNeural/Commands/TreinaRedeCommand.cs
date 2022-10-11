using RedeNeural.Entidades;
using RedeNeural.Helpers;

namespace RedeNeural.Commands
{
    internal static class TreinaRedeCommand
    {
        public static Camada[] Execute(Camada[] rede, string[] arquivo)
        {
            using (StreamWriter sw = File.CreateText(@"c:\tmp\teste.txt"))
            {

                for (int x = 0; x < ParametrizacaoHelper.EPOCAS; x++)
                {
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

                        for (int i = 1; i < rede.Length; i++)
                        {
                            foreach (var neuronio in rede[i].Neuronios)
                            {
                                var somatorio = neuronio.Ligacoes.Sum(ligacao => ligacao.Peso * ligacao.Neuronio.Valor);
                                neuronio.Valor = 1 / (1 + Math.Exp(-somatorio));
                            }
                        }

                        // Calcula o erro da ultima camada
                        for (int i = 0; i < rede[2].Neuronios.Length; i++)
                        {
                            var fatorErro = valoresEsperados[i] - rede[2].Neuronios[i].Valor;
                            rede[2].Neuronios[i].Erro = rede[2].Neuronios[i].Valor * (1 - rede[2].Neuronios[i].Valor) * fatorErro;
                        }

                        // Calcula o erro da camada intermediaria
                        for (int i = 0; i < rede[1].Neuronios.Length; i++)
                        {
                            var fatorErro = rede[2].Neuronios.Sum(neuronio => neuronio.Erro * neuronio.Ligacoes[i].Peso);
                            rede[1].Neuronios[i].Erro = rede[1].Neuronios[i].Valor * (1 - rede[1].Neuronios[i].Valor) * fatorErro;
                        }

                        // Recalcula os pesos entre a camada intermediaria e a ultima
                        for (int i = 0; i < rede[2].Neuronios.Length; i++)
                        {
                            for (int j = 0; j < rede[2].Neuronios[i].Ligacoes.Length; j++)
                            {
                                rede[2].Neuronios[i].Ligacoes[j].Peso = rede[2].Neuronios[i].Ligacoes[j].Peso + ParametrizacaoHelper.TAXA_APRENDIZAGEM * rede[2].Neuronios[i].Ligacoes[j].Neuronio.Valor * rede[2].Neuronios[i].Erro;
                            }

                        }

                        // Recalcula os pesos entre a primeira camada e a camada intermediaria
                        for (int i = 0; i < rede[1].Neuronios.Length; i++)
                        {
                            for (int j = 0; j < rede[1].Neuronios[i].Ligacoes.Length; j++)
                            {
                                rede[1].Neuronios[i].Ligacoes[j].Peso = rede[1].Neuronios[i].Ligacoes[j].Peso + ParametrizacaoHelper.TAXA_APRENDIZAGEM * rede[1].Neuronios[i].Ligacoes[j].Neuronio.Valor * rede[1].Neuronios[i].Erro;
                            }

                        }

                        sw.Write($"\nesperado      ");

                        foreach (var valorEsperado in valoresEsperados)
                        {
                            sw.Write($"{valorEsperado}     ");
                        }

                        sw.Write($"\nvalores     ");
                        foreach (var neuronio in rede[2].Neuronios)
                        {

                            sw.Write($"{neuronio.Valor}     ");
                        }

                        sw.Write($"\nerros     ");
                        foreach (var neuronio in rede[2].Neuronios)
                        {

                            sw.Write($"{neuronio.Erro}     ");
                        }
                    }
                }

            }

            return rede;
        }
    }
}
