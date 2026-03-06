using SistemaBancario;

Repositorio<Conta> contas = new();
Repositorio<ContaPoupanca> contasPoupanca = new();
Repositorio<ContaInvestimento> contasInvestimento = new();
string? nome;
byte tipoConta;
decimal valor;
int numero;

while (true)
{
    Console.WriteLine("## SISTEMA BANCÁRIO ##\n");

    Console.WriteLine("1. Criar Conta\t2. Depositar\t3. Sacar\t4. Exibir Informações");
    Console.Write("\nDigite o número correspondente a uma das opções abaixo: ");
    int opcao = Convert.ToInt32(Console.ReadLine());

    switch (opcao)
    {
        case 1:
            do
            {
                Console.Clear();
                Console.WriteLine("=== CRIAR CONTA ===\n");
                Console.Write("Digite seu nome: ");
                nome = Console.ReadLine();

                Console.Write("Digite um número para identificação da conta: ");
                numero = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("\n1. Conta Corrente\t2. Conta Poupança\t3. Conta Investimento\n");
                Console.Write("Digite o número correspondente ao tipo de conta que deseja criar: ");
                tipoConta = Convert.ToByte(Console.ReadLine());

                if (nome == null || nome == "" || numero == 0)
                {
                    Console.WriteLine("\nValores Inválidos! Pressione qualquer tecla para tentar novamente...");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    switch (tipoConta)
                    {
                        case 1:
                            contas.Insere(new Conta(nome, numero));
                            break;
                        case 2:
                            contasPoupanca.Insere(new ContaPoupanca(nome, numero));
                            break;
                        case 3:
                            contasInvestimento.Insere(new ContaInvestimento(nome, numero));
                            break;
                    }
                    Console.WriteLine("\nConta criada com sucesso! Pressione qualquer tecla para sair...");
                    Console.ReadKey();
                    break;
                }
            }
            while (true);
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("=== DEPÓSITO ===\n");
            Console.Write("Digite o número da conta: ");
            numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n1. Conta Corrente\t2. Conta Poupança\t3. Conta Investimento");
            Console.Write("\nDigite o número correspondente ao tipo de conta: ");
            tipoConta = Convert.ToByte(Console.ReadLine());

            Console.Write("Digite o valor que deseja depositar: ");
            valor = Convert.ToDecimal(Console.ReadLine());

            switch (tipoConta)
            {
                case 1:
                    Conta? conta = contas.BuscaConta(numero);

                    if (conta != null)
                    {
                        conta.Depositar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    ContaPoupanca? contaPoupanca = contasPoupanca.BuscaConta(numero);

                    if (contaPoupanca != null)
                    {
                        contaPoupanca.Depositar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    ContaInvestimento? contaInvestimento = contasInvestimento.BuscaConta(numero);

                    if (contaInvestimento != null)
                    {
                        contaInvestimento.Depositar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
            }
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("=== SAQUE ===\n");
            Console.Write("Digite o número da conta: ");
            numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n1. Conta Corrente\t2. Conta Poupança\t3. Conta Investimento");
            Console.Write("\nDigite o número correspondente ao tipo de conta: ");
            tipoConta = Convert.ToByte(Console.ReadLine());

            Console.Write("Digite o valor que deseja sacar: ");
            valor = Convert.ToDecimal(Console.ReadLine());

            switch (tipoConta)
            {
                case 1:
                    Conta? conta = contas.BuscaConta(numero);

                    if (conta != null)
                    {
                        conta.Sacar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    ContaPoupanca? contaPoupanca = contasPoupanca.BuscaConta(numero);

                    if (contaPoupanca != null)
                    {
                        contaPoupanca.Sacar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    ContaInvestimento? contaInvestimento = contasInvestimento.BuscaConta(numero);

                    if (contaInvestimento != null)
                    {
                        contaInvestimento.Sacar(valor);
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
            }
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("=== INFORMAÇÕES DA CONTA ===\n");
            Console.Write("Digite o número da conta: ");
            numero = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\n1. Conta Corrente\t2. Conta Poupança\t3. Conta Investimento");
            Console.Write("\nDigite o número correspondente ao tipo de conta: ");
            tipoConta = Convert.ToByte(Console.ReadLine());

            switch (tipoConta)
            {
                case 1:
                    Conta? conta = contas.BuscaConta(numero);

                    if (conta != null)
                    {
                        conta.ExibirInfo();
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 2:
                    ContaPoupanca? contaPoupanca = contasPoupanca.BuscaConta(numero);

                    if (contaPoupanca != null)
                    {
                        contaPoupanca.ExibirInfo();
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
                case 3:
                    ContaInvestimento? contaInvestimento = contasInvestimento.BuscaConta(numero);

                    if (contaInvestimento != null)
                    {
                        contaInvestimento.ExibirInfo();
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("Conta inexistente...");
                        Console.WriteLine("\nPressione qualquer tecla para sair...");
                        Console.ReadKey();
                    }
                    break;
            }
            break;
        default:
            Console.WriteLine("\nOpção Inválida! Pressione qualquer tecla para tentar novamente...");
            Console.ReadKey();
            break;
    }
    Console.Clear();
}
