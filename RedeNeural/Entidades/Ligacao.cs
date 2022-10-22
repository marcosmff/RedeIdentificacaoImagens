namespace RedeNeural.Entidades
{
    internal class Ligacao
    {
        public Ligacao(Neuronio neuronio)
        {
            Peso = new Random().NextDouble();
            Neuronio = neuronio;
        }

        public double Peso { get; set; }

        public Neuronio Neuronio { get; set; }
    }
}
