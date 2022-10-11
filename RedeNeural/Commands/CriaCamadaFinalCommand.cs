using RedeNeural.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Commands
{
    internal static class CriaCamadaFinalCommand
    {
        public static Camada Execute(Camada camadaAnterior, int quantidadeNeuronios)
        {
            var camada = new Camada();

            var neuronios = new List<Neuronio>();

            for (int i = 0; i < quantidadeNeuronios; i++)
            {
                neuronios.Add(new Neuronio(camadaAnterior));
            }

            camada.Neuronios = neuronios.ToArray();

            return camada;
        }
    }
}
