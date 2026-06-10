namespace SistemaBancario
{
    class ContaInvestimento : Conta
    {
        private const decimal juros = 0.009m;
        private const decimal imposto = 0.001m;
        public ContaInvestimento(string nome, int numero) : base(nome, numero) { }
        public override void Depositar(decimal deposito)
        {
            base.Depositar(deposito);
            Saldo += Saldo * juros;
        }
        public override void Sacar(decimal saque)
        {
            base.Sacar(saque);
            Saldo -= Saldo * imposto;
        }
    }
}