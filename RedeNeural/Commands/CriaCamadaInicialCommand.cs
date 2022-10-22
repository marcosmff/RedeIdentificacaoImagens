using RedeNeural.Entidades;

namespace RedeNeural.Commands
{
    internal class CriaCamadaInicialCommand
    {
        public static Camada Execute(int numeroNeuronios)
        {
            var camada = new Camada();

            var neuronios = new List<Neuronio>();

            for (int i = 0; i < numeroNeuronios; i++)
            {
                neuronios.Add(new Neuronio());
            }

            camada.Neuronios = neuronios.ToArray();

            return camada;
        }
    }
}
