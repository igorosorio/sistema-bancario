namespace SistemaBancario
{
    class Conta
    {
        public string Titular { get; private set; }
        public int Numero { get; private set; }
        public decimal Saldo { get; protected set; }
        public Conta(string nome, int numero)
        {
            if (string.IsNullOrWhiteSpace(nome) || numero <= 0)
                throw new ArgumentException("A conta deve ter nome e número válidos!");

            Titular = nome;
            Numero = numero;
        }
        public virtual void Depositar(decimal deposito)
        {
            if (deposito <= 0)
                throw new ArgumentOutOfRangeException(nameof(deposito), "O valor de depósito deve ser válido (maior que zero)!");

            Saldo += deposito;
        }
        public virtual void Sacar(decimal saque)
        {
            if (saque <= 0)
                throw new ArgumentOutOfRangeException(nameof(saque), "O valor de saque deve ser válido (maior que zero)!");
            if (Saldo - saque < 0)
                throw new ArgumentOutOfRangeException(nameof(saque), "Saldo Insuficiente!");

            Saldo -= saque;
        }
        public override string ToString()
        {
            return $"Nome do Titular: {Titular}\n" +
                $"Número da Conta: {Numero}\n" +
                $"Saldo Atual: {Saldo:C}";
        }
    }
}