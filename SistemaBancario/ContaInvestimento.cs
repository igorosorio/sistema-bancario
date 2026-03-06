namespace SistemaBancario
{
    class ContaInvestimento : Conta
    {
        readonly decimal juros = 0.009m;
        readonly decimal imposto = 0.001m;
        public ContaInvestimento(string nome, int numero) : base(nome, numero) { }
        public override void Depositar(decimal deposito)
        {
            Saldo += deposito;
            Saldo += Saldo * juros;
        }
        public override void Sacar(decimal saque)
        {
            if (Saldo - saque < 0)
            {
                Console.WriteLine("O saldo da conta não pode ser negativo. Pressione qualquer tecla para tentar novamente...");
                Console.ReadKey();
            }
            else
            {
                Saldo -= saque;
                Saldo -= Saldo * imposto;
            }
        }
    }
}
