using RedeNeural.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                camadas[i] = CriaCamadaIntermediariaCommand.Execute(camadas[i - 1], (neuroniosPrimeiraCamada + neuroniosUltimaCamada) / 2);
            }

            camadas[quantidadeCamadas - 1] = CriaCamadaFinalCommand.Execute(camadas[quantidadeCamadas - 2], neuroniosUltimaCamada);

            return camadas;
        }
    }
}
