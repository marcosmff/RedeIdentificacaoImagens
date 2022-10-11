using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Entidades
{
    internal class Neuronio
    {
        public Neuronio()
        {

        }

        public Neuronio(Camada camada)
        {
            Ligacoes = camada.Neuronios.Select(neuronio => { return new Ligacao(neuronio); }).ToArray();
        }

        public double Valor { get; set; }

        public double Erro { get; set; }

        public Ligacao[] Ligacoes { get; set; }
    }
}
