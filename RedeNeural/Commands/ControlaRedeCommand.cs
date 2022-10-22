using RedeNeural.Helpers;

namespace RedeNeural.Commands
{
    internal static class ControlaRedeCommand
    {
        public static void Execute()
        {
            var rede = CriaRedeCommand.Execute(ParametrizacaoHelper.CAMADAS, 18, 7);

            var arquivo = File.ReadAllLines(ParametrizacaoHelper.ARQUIVO_TREINO);

            rede = TreinaRedeCommand.Execute(rede, arquivo);

            TestaRedeCommand.Execute(rede, true);
        }
    }
}
