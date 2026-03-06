namespace SistemaBancario
{
    class Repositorio<T> where T : Conta
    {
        Dictionary<int, T> listaContas = new();
        public void Insere(T objConta)
        {
            listaContas.Add(objConta.Numero, objConta);
        }
        public T? BuscaConta(int numero)
        {
            if (listaContas.TryGetValue(numero, out T? conta))
                return conta;
            else
                return null;
        }
    }
}