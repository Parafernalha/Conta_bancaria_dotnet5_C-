using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContaBancariaDotnet
{
    public class Conta
    {
        public string Nome {get;set;}

        private TipoConta TipoConta { get; set; }

        private double Saldo { get; set; }

        private double Credito { get; set; }


        public Conta(TipoConta Tipoconta, double saldo, double credito, String nome)

        {
            this.TipoConta = Tipoconta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;

        }


        public bool Sacar(double ValorSaque)
        {
            if (this.Saldo - ValorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente.");
                return false;

            }
            this.Saldo -= ValorSaque;
            Console.WriteLine("Saldo atual da conta:" + this.Nome + this.Saldo);
            return true;    
        }

            public void Depositar (double ValorDeposito)
        {
            this.Saldo += ValorDeposito;
            Console.WriteLine("O saldo atual da conta é:" + this.Nome + this.Saldo);
        }


            public void Transferir (double ValorTransferencia, Conta ContaDestino)
        {
            if(this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);
            }
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "TipoConta " + this.TipoConta + " | ";
            retorno += "Nome " + this.Nome + " | ";
            retorno += "Saldo " + this.Saldo + " | ";
            retorno += "Crédito " + this.Credito;
            return retorno;

        }
    }
}
