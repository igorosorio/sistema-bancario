namespace SistemaBancario
{
    class ContaPoupanca : Conta
    {
        private const decimal juros = 0.005m;
        public ContaPoupanca(string nome, int numero) : base(nome, numero) { }
        public override void Depositar(decimal deposito)
        {
            base.Depositar(deposito);
            Saldo += Saldo * juros;
        }
        public override void Sacar(decimal saque)
        {
            base.Sacar(saque);
        }
    }
}