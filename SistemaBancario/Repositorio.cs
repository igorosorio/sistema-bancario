namespace SistemaBancario
{
    class Repositorio
    {
        private static Dictionary<int, Conta> listaContas = new();
        public static void Insere(Conta conta)
        {
            listaContas.Add(conta.Numero, conta);
        }
        public static bool VerificaNumConta(int numero)
        {
            return listaContas.ContainsKey(numero);

        }
        public static Conta BuscaConta(int numero)
        {
            return listaContas[numero];
        }
    }
}