using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedeNeural.Entidades
{
    internal class Ligacao
    {
        public Ligacao(Neuronio neuronio)
        {
            Peso = (new Random()).NextDouble();
            Neuronio = neuronio;
        }

        public double Peso { get; set; }

        public Neuronio Neuronio { get; set; }
    }
}
