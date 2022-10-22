using RedeNeural.Entidades;

namespace RedeNeural.Commands
{
    internal static class CriaRedeCommand
    {
        public static Camada[] Execute(int quantidadeCamadas, int neuroniosPrimeiraCamada, int neuroniosUltimaCamada)
        {
            var camadas = new Camada[quantidadeCamadas];

            camadas[0] = CriaCamadaInicialCommand.Execute(neuroniosPrimeiraCamada);

            for (int i = 1; i < quantidadeCamadas - 1; i++)
            {
                camadas[i] = CriaCamadaIntermediariaCommand.Execute(camadas[i - 1], ((camadas[i - 1].Neuronios.Length + neuroniosUltimaCamada) / 2) + 1);
            }

            camadas[quantidadeCamadas - 1] = CriaCamadaFinalCommand.Execute(camadas[quantidadeCamadas - 2], neuroniosUltimaCamada);

            return camadas;
        }
    }
}
