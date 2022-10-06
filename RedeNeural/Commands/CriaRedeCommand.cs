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
        public static Camada[] Execute(int quantidadeCamadas)
        {
            quantidadeCamadas = 3;

            var camadas = new Camada[quantidadeCamadas];

            camadas.Append(CriaCamadaInicialCommand.Execute());

            for (int i = 0; i < quantidadeCamadas - 2; i++)
            {
                camadas.Append(CriaCamadaIntermediariaCommand.Execute(camadas[i]));
            }

            camadas.Append(CriaCamadaFinalCommand.Execute(camadas[quantidadeCamadas - 2]));

            return camadas;
        }
    }
}
