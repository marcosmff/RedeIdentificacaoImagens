using RedeNeural.Entidades;

namespace RedeNeural.Commands
{
    internal static class CriaCamadaIntermediariaCommand
    {
        public static Camada Execute(Camada camadaAnterior, int numeroNeuronios)
        {
            var camada = new Camada();

            var neuronios = new List<Neuronio>();

            for (int i = 0; i < numeroNeuronios; i++)
            {
                neuronios.Add(new Neuronio(camadaAnterior));
            }

            camada.Neuronios = neuronios.ToArray();

            return camada;
        }
    }
}
