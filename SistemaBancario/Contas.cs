namespace SistemaBancario
{
    class Conta
    {
        public string NomeCliente { get; set; }
        public int Numero { get; set; }
        //protected permite que o saldo possa ser alterado somente pela classe Conta e suas derivadas
        public decimal Saldo { get; protected set; }
        public Conta(string nome, int numero)
        {
            NomeCliente = nome;
            this.Numero = numero;
        }
        public virtual void Depositar(decimal deposito)
        {
            Saldo += deposito;
        }
        public virtual void Sacar(decimal saque)
        {
            Saldo -= saque;
        }
        public void ExibirInfo()
        {
            Console.WriteLine($"\nNome do Titular: {NomeCliente}");
            Console.WriteLine($"Número da Conta: {Numero}");
            Console.WriteLine($"Saldo Atual: {Saldo}");
        }
    }
}