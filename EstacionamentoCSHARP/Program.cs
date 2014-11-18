using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EstacionamentoCSHARP
{
    class Program
    {


        static void Main(string[] args)
        {

            EstacionamentoSS inicio = new EstacionamentoSS();
            inicio.Inicio();
            
        }

    }

    class EstacionamentoSS
    {
        int tipo;
        decimal valor;
        string placa, retornaPlaca, tipostring;
        DateTime retornaEntrada;
        DateTime retornaSaida;
        List<Estacionamento_PM> Estacionamento = new List<Estacionamento_PM>();

        public void Inicio()
        {
            Console.WriteLine(":::::::: Seja Bem Vindo ao Estacionamento MAROTO ::::::::");
            Console.WriteLine("Digite 1 para entrada de veículos ou 2 para saída de veiculos e 3 para visualizar veículos no estacionamento.");
            Console.WriteLine();
            Console.WriteLine("DIGITE 1 PARA ENTRADA DE VEÍCULOS. ");
            Console.WriteLine("DIGITE 2 PARA SAÍDA DE VEÍCULOS. ");
            Console.WriteLine("DIGITE 3 PARA VISUALIZAR VEÍCULOS NO ESTACIONAMENTO. ");
            Console.WriteLine("DIGITE 4 PARA VISUALIZAR VEÍCULOS QUE SAÍRAM DO ESTACIONAMENTO. ");
            Console.WriteLine();
            Console.Write("DIGITE A OPÇÃO: ");
            tipostring = Console.ReadLine();
            if (!Int32.TryParse(tipostring, out tipo))
            {

                Console.Clear();
                Inicio();
            }
            else
            {
                tipo = Convert.ToInt32(tipostring);
            }
            if ((tipo == 1))
            {
                Console.WriteLine();
                Console.WriteLine("CADASTRO VEÍCULOS.");
                Console.Write("Digite a placa do veículo: ");
                placa = Console.ReadLine();
                Entrada(placa);
            }
            if ((tipo == 2))
            {
                Console.Write("Digite a placa do veículo: ");
                placa = Console.ReadLine();
                Saida(placa);
                System.Console.ReadLine();
            }
            if ((tipo == 3))
            {
                  ListaEstacionamento();
            }
            if ((tipo == 4))
            {
                ListaSaidaEstacionamento();
            }
        }



        public void Entrada(string placa)
        {

            var query = (from c in Estacionamento where c.PLACA == placa && c.DATA_SAIDA == null select c).Count();

            if ((query == 10))
            {
                Console.WriteLine("ESTACIONAMENTO LOTADO!");
                Console.ReadLine();
                Console.Clear();
                Inicio();
            }
            Estacionamento_PM newRecord = new Estacionamento_PM();
            newRecord.PLACA = placa;
            newRecord.DATA_ENTRADA = DateTime.Now;
            Estacionamento.Add(newRecord);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("VEÍCULO CADASTRADO COM SUCESSO, APERTE QUALQUER TECLA PARA CONTINUAR !");
            Console.ReadLine();
            Console.Clear();
            Inicio();
        }

        public void Saida(string placa)
        {


            var query = (from c in Estacionamento where c.PLACA == placa && c.DATA_SAIDA == null select c).FirstOrDefault();

            if ((query == null))
            {
                Console.WriteLine("PLACA NÃO CONSTA NO ESTACIONAMENTO!");
                Console.ReadLine();
                Console.Clear();
                Inicio();
            }
            else
            {

                query.DATA_SAIDA = DateTime.Now;
                retornaPlaca = query.PLACA;
                retornaEntrada = query.DATA_ENTRADA;
                retornaSaida = DateTime.Now;
                

                //DateDiffs
                //int HoursDiff = - (query.DATA_ENTRADA.Subtract(DateTime.Now).Seconds);

                int HoursDiff = -((TimeSpan)(query.DATA_ENTRADA - DateTime.Now)).Hours;
                if (HoursDiff <= 1)
	            {
                    valor = 10;
	            }
                else
                {
                    valor = 15;
                }
               

                query.VALOR = valor;
            }
            Console.WriteLine();
            Console.WriteLine(":::::::: SAÍDA DO VEÍCULO REGISTRADA COM SUCESSO ::::::::");
            Console.WriteLine(("A placa do veículo: "
                            + (retornaPlaca + "")));
            Console.WriteLine(("A data e hora de entrada do veículo: "
                            + (retornaEntrada + "")));
            Console.WriteLine(("A data e hora de saída do veículo: "
                            + (retornaSaida + "")));
            Console.WriteLine(("Valor cobrado: R$ "
                            + (valor + "")));
            Console.ReadLine();
            Console.Clear();
            Inicio();
        }

      
        public void ListaEstacionamento() {

        int querycount = (from c in Estacionamento where c.DATA_SAIDA == null select c).Count();
        if ((querycount == 0)) {
            Console.WriteLine("NÃO CONSTA VEÍCULOS NO ESTACIONAMENTO");
            Console.ReadLine();
            Console.Clear();
            Inicio();
        }
        Console.WriteLine();
        Console.WriteLine(":::::::: VEICULOS QUE ESTÃO NO ESTACIONAMENTO ::::::::");
        Console.WriteLine();

        var query = (from c in Estacionamento where c.DATA_SAIDA == null select c);
        foreach (var item in query) {
            Console.WriteLine(("A placa do veículo: " 
                            + (item.PLACA + "")));
            Console.WriteLine(("A data e hora de entrada do veículo: " 
                            + (item.DATA_ENTRADA + "")));
            Console.WriteLine();
        }
        Console.ReadLine();
        Console.Clear();
        Inicio();
    }


        public void ListaSaidaEstacionamento()
        {

            int querycount = (from c in Estacionamento where c.DATA_SAIDA != null select c).Count();
            if (querycount == 0)
            {
                Console.WriteLine("NÃO CONSTA SAÍDA VEÍCULOS NO ESTACIONAMENTO");
                Console.ReadLine();
                Console.Clear();
                Inicio();
            }

            var query = (from c in Estacionamento where c.DATA_SAIDA != null select c);
            foreach (var item in query)
            {
                Console.WriteLine(("A placa do veículo: "
                                + (item.PLACA + "")));
                Console.WriteLine(("A data e hora de entrada do veículo: "
                                + (item.DATA_ENTRADA + "")));
                Console.WriteLine(("A data e hora de saída do veículo: "
                                + (item.DATA_SAIDA + "")));
                Console.WriteLine(("Valor Cobrado: "
                                + (item.VALOR + "")));
                Console.WriteLine();
            }

        }


    }



}
