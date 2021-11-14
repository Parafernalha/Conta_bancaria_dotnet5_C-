using System;
using System.Collections.Generic;

namespace ContaBancariaDotnet
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {

            //   Conta MinhaConta = new Conta(TipoConta.PessoaFisica, 0, 0, "Douglas de Oliveira Fernandes");        
            //   Console.WriteLine(MinhaConta.ToString());

            string opcaousuario = ObterOpcaoUsuario();

            while (opcaousuario.ToUpper() != "X")
            {
                switch (opcaousuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                      //    Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    default:
                       throw new ArgumentOutOfRangeException ();
                }
                opcaousuario = ObterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Sacar() 
        {
            Console.WriteLine("Digite o número da conta:");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double ValorSaque = double.Parse(Console.ReadLine());

            listaContas[IndiceConta].Sacar(ValorSaque);
        }
        private static void Depositar()
        {
            Console.WriteLine("Digite o número da conta:");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor a ser sacado: ");
            double ValorDeposito = double.Parse(Console.ReadLine());

            listaContas[IndiceConta].Depositar(ValorDeposito);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir uma nova conta");

            Console.WriteLine("Digite 1 para conta fisíca ou 2 para jurídica");
            int EntradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string EntradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double EntradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito: ");
            double EntradaCredito = double.Parse(Console.ReadLine());

            Conta NovaConta = new Conta(Tipoconta: (TipoConta)EntradaTipoConta,
                saldo: EntradaSaldo,
                credito: EntradaCredito,
                nome: EntradaNome);

            listaContas.Add(NovaConta);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar contas");

            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada.");
                return;
            }

            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);

            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Douglas Bank a seu dispor!");
            Console.WriteLine("Informa a opção desejada:");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("6 - Limpar tela");
            Console.WriteLine("X - Sair");

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario; 

        }
    }
}
