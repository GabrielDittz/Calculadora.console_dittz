using System;
using System.IO;
using System.Xml.Serialization;
using Application;
using Calculadora.Data;
using Domain.Models;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.Clear();

            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("1 - Soma");
            Console.WriteLine("2 - Subtração");
            Console.WriteLine("3 - Divisão");
            Console.WriteLine("4 - Multiplicação");
            Console.WriteLine("5 - Sair");

            Console.WriteLine("----------");
            Console.WriteLine("Selecione uma opção: ");

            short res = short.Parse(Console.ReadLine());

            switch (res)
            {
                case 1: Soma(); break;
                case 2: Subtracao(); break;
                case 3: Divisao(); break;
                case 4: Multiplicacao(); break;
                case 5: Environment.Exit(0); break;
                default: Menu(); break;
            }
        }

        static void Soma()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Somar(v1, v2);
            Console.WriteLine($"O resultado da soma é {resultado}");

            CriarTXT("Soma");

            SalvarBanco("Soma", resultado);

            Console.ReadKey();
            Menu();
        }

        static void Subtracao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Subtrair(v1, v2);
            Console.WriteLine($"O resultado da subtração é {resultado}");

            CriarTXT("Subtração");

            SalvarBanco("Subtração", resultado);

            Console.ReadKey();
            Menu();
        }

        static void Divisao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            while (v1 == 0 || v2 == 0)
            {
                Console.WriteLine("Digite os valores novamente.");
                Console.ReadKey();

                Divisao();
            }

            Console.WriteLine("");

            float resultado = Operacoes.Dividir(v1, v2);
            Console.WriteLine($"O resultado da divisão é {resultado}");

            CriarTXT("Divisão");

            SalvarBanco("Divisão", resultado);

            Console.ReadKey();
            Menu();
        }

        static void Multiplicacao()
        {
            Console.Clear();

            Console.WriteLine("Primeiro valor: ");
            float v1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Segundo valor:");
            float v2 = float.Parse(Console.ReadLine());

            Console.WriteLine("");

            float resultado = Operacoes.Multiplicar(v1, v2);
            Console.WriteLine($"O resultado da multiplicação é {resultado}");

            CriarTXT("Multiplicação");

            SalvarBanco("Multiplicação", resultado);

            Console.ReadKey();
            Menu();
        }

        static void CriarTXT(string nomeOperacao)
        {
            string path = @"C:\Users\gabrieldittz_frwk\Documents\Estudos\PDI\Calculadora.console_dittz\ultimo_comando.txt";

            string textoArquivo = $"{nomeOperacao} - {DateTime.Now}";

            File.WriteAllText(path, textoArquivo);

            Console.WriteLine("Arquivo salvo com sucesso!");
        }

        static void SalvarBanco(string nomeOperacao, float resultado)
        {
            using (var context = new AppDbContext())
            {
                var operacao = new OperacoesHistorico();

                operacao.SetOperacoesHistorico(nomeOperacao, resultado);

                context.Add(operacao);
                context.SaveChanges();
            }
        }
    }
}