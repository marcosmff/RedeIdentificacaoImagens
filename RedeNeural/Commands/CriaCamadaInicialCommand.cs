using RedeNeural.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Commands
{
    internal class CriaCamadaInicialCommand
    {
        public static Camada Execute()
        {
            var camada = new Camada();

            var neuronios = new List<Neuronio>();

            for (int i = 0; i < 2; i++)
            {
                neuronios.Add(new Neuronio());
            }

            camada.Neuronios = neuronios;

            return camada;
        }
    }
}
