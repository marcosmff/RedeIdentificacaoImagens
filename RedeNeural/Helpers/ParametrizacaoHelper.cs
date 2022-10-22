namespace RedeNeural.Helpers
{
    internal static class ParametrizacaoHelper
    {
        public static readonly string ARQUIVO_TREINO = @"C:\Users\marca\Desktop\RedeNeural\treinamento.csv";
        public static readonly string ARQUIVO_TESTE = @"C:\Users\marca\Desktop\RedeNeural\teste.csv";
        public static readonly string ARQUIVO_DADOS_GRAFICO = @"c:\tmp\grafico_erro.csv";
        public static readonly string ARQUIVO_VALORES_ERROS_EPOCA = @"c:\tmp\erros.csv";

        public static readonly int CAMADAS = 3;
        public static readonly double TAXA_APRENDIZAGEM = 0.1;
        public static readonly int EPOCAS = 1000;
        public static readonly char SEPARADOR_ARQUIVO = ';';
    }
}
