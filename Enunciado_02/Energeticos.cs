using System;
using System.Collections.Generic;

namespace EnergeticosAccelerator
{
    //Clase de Energetico para calcular os impostos
    class Energetico
    {
        public string CLIENTE { get; set; }
        public int QTD { get; set; }
        public double ICMS { get; set; }
        public double IPI { get; set; }
        public double PIS { get; set; }
        public double COFINS { get; set; }
        public double TOTAL_MERCADORIA { get; set; }
        public double TOTAL_IMPOSTOS { get; set; }
        public double TOTAL_GERAL { get; set; }

        public Energetico(string client, int qtd)
        {
            QTD = qtd;
            CLIENTE = client;
            TOTAL_MERCADORIA = QTD * 4.5;
            ICMS = TOTAL_MERCADORIA * 0.18;
            IPI = TOTAL_MERCADORIA * 0.04;
            PIS = TOTAL_MERCADORIA * 0.0186;
            COFINS = TOTAL_MERCADORIA * 0.0854;
            TOTAL_IMPOSTOS = ICMS + IPI + PIS + COFINS;
            TOTAL_GERAL = TOTAL_IMPOSTOS + TOTAL_MERCADORIA;
        }

        //Sobrescrevendo o metodo ToString para imprimir corretamente os valores
        public override string ToString()
        {
            return $"Cliente: {CLIENTE}\nICMS: R${ICMS.ToString("0.00")}\nIPI: R${IPI.ToString("0.00")}\nPIS: R${PIS.ToString("0.00")}\nCOFINS: R${COFINS.ToString("0.00")}\nTOTAL: R${TOTAL_GERAL.ToString("0.00")}";
        }
    }

    class Program
    {
        static void Main()
        {
            //Variavel de controle
            bool sair = false;
            List<Energetico> Vendas = new();
            while (!sair)
            {
                Console.Clear();
                Console.WriteLine("Selecione a opção desejada: ");
                Console.WriteLine("1. Adicionar venda");
                Console.WriteLine("2. Imprimir relatório");
                Console.WriteLine("3. Sair");
                string a = Console.ReadLine();
                switch (a)
                {
                    //Adicionando nova venda
                    case "1":
                        Console.WriteLine("Digite o nome do cliente: ");
                        string cliente = Console.ReadLine();
                        Console.WriteLine("Informe a quantidade de energéticos vendidos: ");
                        string qtd = Console.ReadLine();
                        try
                        {
                            int q = Convert.ToInt32(qtd);
                            Energetico aux = new(cliente, q);
                            Vendas.Add(aux);
                            Console.WriteLine("Sucesso ao adicionar o registro...");
                        }
                        catch
                        {
                            Console.WriteLine("Erro ao adicionar o registro");
                        }
                        Console.WriteLine("Aperte qualquer tecla para continuar...");
                        _ = Console.ReadKey();
                        break;
                    //Imprimindo todos as vendas como relatório
                    case "2":
                        Console.WriteLine("\n\n");
                        double totalImposto = 0, totalMercadoria = 0, totalGeral = 0;
                        //ForEach para imprimir todas as vendas
                        Vendas.ForEach(e =>
                        {
                            Console.WriteLine("--------------------------------");
                            Console.WriteLine(e);
                            totalGeral += e.TOTAL_GERAL;
                            totalImposto += e.TOTAL_IMPOSTOS;
                            totalMercadoria += e.TOTAL_MERCADORIA;
                        });
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine($"Total Imposto: R${totalImposto.ToString("0.00")}");
                        Console.WriteLine($"Total Mercadoria: R${totalMercadoria.ToString("0.00")}");
                        Console.WriteLine($"Total Geral: R${totalGeral.ToString("0.00")}");
                        Console.WriteLine("--------------------------------");
                        Console.WriteLine("\n\n");
                        Console.WriteLine("Aperte qualquer tecla para continuar...");
                        _ = Console.ReadKey();
                        break;
                    case "3":
                        sair = true;
                        Console.WriteLine("Aperte qualquer tecla para continuar...");
                        _ = Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Opção não existe...");
                        Console.WriteLine("Aperte qualquer tecla para continuar...");
                        _ = Console.ReadKey();
                        break;
                }
            }
        }
    }
}
