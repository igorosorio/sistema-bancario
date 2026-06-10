using SistemaBancario;

byte opcao;

while (true)
{
    Console.WriteLine("## SISTEMA BANCÁRIO ##\n");

    Console.WriteLine("1. Criar Conta\t2. Depositar\t3. Sacar\t4. Exibir Informações");

    do
    {
        Console.Write("\nDigite o número correspondente a uma das opções abaixo: ");
    }
    while (!byte.TryParse(Console.ReadLine(), out opcao));

    switch (opcao)
    {
        case 1:
            CriarConta();
            break;
        case 2:
            Deposito();
            break;
        case 3:
            Saque();
            break;
        case 4:
            ExibirInfo();
            break;
        default:
            Console.WriteLine("\nOpção Inválida! Pressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
            break;
    }
    Console.Clear();
}
// serviços
static void CriarConta()
{
    int numero;
    byte tipoConta;
    do
    {
        Console.Clear();
        Console.WriteLine("=== CRIAR CONTA ===\n");
        Console.Write("Digite seu nome: ");
        string nome = Console.ReadLine();

        while (true)
        {
            Console.Write("Digite um número para identificação da conta: ");
            if (int.TryParse(Console.ReadLine(), out numero))
            {
                if (!Repositorio.VerificaNumConta(numero))
                    break;
                else
                {
                    Console.WriteLine("Este número de conta já existe, digite outro!");
                    continue;
                }
            }
            else
                Console.WriteLine("Valor Inválido! Digite um número inteiro.");
        }

        Console.WriteLine("\n1. Conta Corrente\t2. Conta Poupança\t3. Conta Investimento\n");
        while (true)
        {
            Console.Write("Digite o número correspondente ao tipo de conta que deseja criar: ");
            if (byte.TryParse(Console.ReadLine(), out tipoConta) && tipoConta >= 1 && tipoConta <= 3)
                break;
            else
                Console.WriteLine("Valor Inválido! Digite uma das opções válidas (1, 2 ou 3)!");
        }

        try
        {
            switch (tipoConta)
            {
                case 1:
                    Repositorio.Insere(new Conta(nome, numero));
                    break;
                case 2:
                    Repositorio.Insere(new ContaPoupanca(nome, numero));
                    break;
                case 3:
                    Repositorio.Insere(new ContaInvestimento(nome, numero));
                    break;
            }
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
        Console.WriteLine("\nConta criada com sucesso! Pressione qualquer tecla para sair...");
        Console.ReadKey();
        break;
    }
    while (true);
}
static void Deposito()
{
    Console.Clear();
    Console.WriteLine("=== DEPÓSITO ===\n");

    Conta conta = ObterConta();

    do
    {
        decimal valor = LerValor("Digite o valor que deseja depositar: ");

        try
        {
            conta.Depositar(valor); //POLIMORFISMO - pelo método ser virtual o runtime analisa em tempo de execução o tipo real do objeto, e não sua referência
            break;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    while (true);
}
static void Saque()
{
    Console.Clear();
    Console.WriteLine("=== SAQUE ===\n");

    Conta conta = ObterConta();

    do
    {
        decimal valor = LerValor("Digite o valor que deseja sacar: ");

        try
        {
            conta.Sacar(valor); //POLIMORFISMO - pelo método ser virtual o runtime analisa em tempo de execução o tipo real do objeto, e não sua referência
            break;
        }
        catch (ArgumentOutOfRangeException ex)
        {
            Console.WriteLine(ex.Message);
            continue;
        }
    }
    while (true);
}
static void ExibirInfo()
{
    Console.Clear();
    Console.WriteLine("=== INFORMAÇÕES DA CONTA ===\n");

    Conta conta = ObterConta();

    Console.WriteLine(conta.ToString());
}
// métodos aux.
static Conta ObterConta()
{
    while (true)
    {
        Console.Write("Digite o número da conta: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            if (Repositorio.VerificaNumConta(numero))
            {
                return Repositorio.BuscaConta(numero);
            }
            else
            {
                Console.WriteLine("Esta conta não existe! Digite novamente...");
                continue;
            }
        }
        else
            Console.WriteLine("Valor Inválido! Digite um número inteiro.");
    }
}
static decimal LerValor(string mensagem)
{
    while (true)
    {
        Console.Write(mensagem);
        if (decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
                return valor;
        }
        else
            Console.WriteLine("Valor Inválido!");
    }
}