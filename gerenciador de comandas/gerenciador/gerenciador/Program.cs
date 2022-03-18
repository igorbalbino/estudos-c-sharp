using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 SISTEMA DE GERENCIA DE COMANDAS

Será feito da seguinte forma:
À medida que os clientes vão chegando, as comandas vão sendo geradas e precisa registrar o pedido do cliente com cópia para o mesmo e uma para a gerência,
cada pedido terá um código que se alto encrementa para cada nova comanda gerada.
O sistema deve ter entrada para saber quando houve o pagamento e calcular troco.
 */

namespace gerenciador
{
    public class Program
    {
        //vars
        private static List<Comanda> comandas = new List<Comanda>();

        private static void telaInicial()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("TELA INICIAL");
            Console.WriteLine("\n");

            Console.WriteLine("Opções:");
            Console.WriteLine("1. Gerar nova comanda.");
            Console.WriteLine("2. Ver comandas geradas no dia.");
            Console.WriteLine("3. Indicar comanda paga.");
            Console.WriteLine("4. Finalizar.");
            Console.WriteLine("");

            Console.WriteLine("Opção: ");
            string opt = Console.ReadLine();
            Console.WriteLine("\n");

            int optInt = int.Parse(opt);

            leOpcao(optInt);
        }

        private static void leOpcao(int opt)
        {
            switch(opt)
            {
                case 1:
                    geraComanda();
                    break;

                case 2:
                    mostraComandas();
                    break;

                case 3:
                    atualizaStatusPagamento();
                    break;

                case 4:
                    finalizaSistema();
                    break;

                default:
                    break;
            }
        }

        private static void geraComanda()
        {
            List<string> dadosPedido = pedeInfoComanda();

            if (comandas.Count == 0)
            {
                comandas.Add(new Comanda(1, dadosPedido[0], dadosPedido[1]));
            }
            else
            {
                comandas.Add(new Comanda(comandas.Count + 1, dadosPedido[0], dadosPedido[1]));
            }

            Console.WriteLine("Nova comanda gerada!");
            Console.WriteLine("\n");

            //Console.WriteLine("Cliente: " + comandas[comandas.Count-1].nome);

            telaInicial();
        }

        private static List<string> pedeInfoComanda()
        {
            Console.WriteLine("Nome do cliente: ");
            string nomeCliente = Console.ReadLine();
            Console.WriteLine("");

            Console.WriteLine("Pedido: ");
            string pedido = Console.ReadLine();
            Console.WriteLine("");

            List<string> dadosPedido = new List<string>();
            dadosPedido.Add(Convert.ToString(nomeCliente));
            dadosPedido.Add(Convert.ToString(pedido));

            //for(int i = 0; i < dadosPedido.Count; i++ ) Console.WriteLine("Item: " + dadosPedido[i]);
            //Console.WriteLine("");

            return dadosPedido;
        }

        private static void mostraComandas()
        {
            Console.WriteLine("Todas as comandas: ");

            for (int i = 0; i < comandas.Count; i++)
            {
                if (comandas[i].Status == false)
                {
                    Console.WriteLine("ID da comanda: " + comandas[i].id);
                    Console.WriteLine("Nome do cliente: " + comandas[i].nome);
                    Console.WriteLine("Pedido do cliente: " + comandas[i].pedido);
                    Console.WriteLine("");
                }
            }

            telaInicial();
        }

        private static void atualizaStatusPagamento()
        {
            string nmrComanda;

            Console.WriteLine("Digite o número da comanda: ");
            nmrComanda = Console.ReadLine();

            int nmr = int.Parse(nmrComanda);

            Console.WriteLine("\n");

            Console.WriteLine("A comanda foi paga ?");

            Console.WriteLine("1. Sim.");
            Console.WriteLine("2. Não.");
            Console.WriteLine("");

            Console.WriteLine("Opção: ");
            string opt = Console.ReadLine();

            int optInt = int.Parse(opt);

            switch(optInt)
            {
                case 1:
                    for (int i = 0; i < comandas.Count; i++) if (comandas[i].id == nmr) comandas[i].Status = true;
                    telaInicial();
                    break;

                case 2:
                    telaInicial();
                    break;

                default:
                    telaInicial();
                    break;
            }

        }

        private static void finalizaSistema()
        {
            Console.WriteLine("O sistema será finalizado.");
            Console.WriteLine("Aperte qualquer tecla para continuar...");

            Console.ReadLine();
        }

    static void Main(string[] args)
        {
            Console.WriteLine("Olá, Bem vindo(a) ao Sistema de Gerenciamento de Comandas!");

            telaInicial();


        }
    }
}
