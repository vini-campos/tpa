using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Menu_Projeto_CSharp_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkBlue;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Menu Principal ******");
                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(25, 4); Write("[0] Descanso de tela");
                SetCursorPosition(25, 5); Write("[1] Cálculos");
                SetCursorPosition(25, 6); Write("[2] Tabuada");
                SetCursorPosition(25, 7); Write("[3] Compara números");
                SetCursorPosition(25, 8); Write("[4] Par/Impar");
                SetCursorPosition(25, 9); Write("[5] Média 4 notas");
                SetCursorPosition(25, 10); Write("[6] Fim");

                SetCursorPosition(0, 13);
                Linha();


                SetCursorPosition(0, 17);
                Linha();

                SetCursorPosition(25, 15);
                Write("Digite sua opção: ");
                opcao = int.Parse(ReadLine());//leia pausa

                switch (opcao)
                {
                    case 0:
                        Descanso_Tela();
                        break;
                    case 1:
                        Calculos();
                        break;
                    case 2:
                        Tabuada();
                        break;
                    case 3:
                        ComparaNumeros();
                        break;
                    case 4:
                        ParImpar();
                        break;
                    case 5:
                        MediaNotas();
                        break;
                    case 6: 
                        //adicionar opção de sair
                        break;
                    default: //caso contrario
                        SetCursorPosition(25, 20);
                        Write("[**** Opção inválida ****]");
                        Thread.Sleep(2000);
                        break;
                }



            } while (opcao != 6);


        }
        static void Calculos()
        {
            string repetir, op;
            int num1, num2;

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkGreen;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();

                SetCursorPosition(0, 0);
                Linha();

                SetCursorPosition(23, 1);
                Write("****** Cálculos ******");

                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(0, 13);
                Linha();

                SetCursorPosition(0, 19);
                Linha();

                SetCursorPosition(25, 4);
                Write("Digite o primeiro número:");
                while (!int.TryParse(ReadLine(), out num1))
                {
                    SetCursorPosition(25, 5);
                    Write("Digite um número! :");
                }

                SetCursorPosition(25, 6);
                Write("Digite o segundo número:");
                while (!int.TryParse(ReadLine(), out num2))
                {
                    SetCursorPosition(25, 7);
                    Write("Digite um número! :");
                }

                SetCursorPosition(25, 8);
                Write("Digite a operação que deseja realizar (+ - * /):");
                op = ReadLine();

                switch (op)
                {
                    case "+":
                        SetCursorPosition(25, 15);
                        WriteLine($"A soma de {num1} + {num2} = {num1 + num2}");
                        break;

                    case "-":
                        SetCursorPosition(25, 15);
                        WriteLine($"A subtração de {num1} - {num2} = {num1 - num2}");
                        break;

                    case "*":
                        SetCursorPosition(25, 15);
                        WriteLine($"A multiplicação de {num1} * {num2} = {num1 * num2}");
                        break;

                    case "/":
                        if (num2 == 0)
                        {
                            SetCursorPosition(25, 15);
                            WriteLine("Não é possível dividir por zero.");
                        }
                        else
                        {
                            SetCursorPosition(25, 15);
                            WriteLine($"A divisão de {num1} / {num2} = {num1 / num2}");
                        }
                        break;

                     default:
                        SetCursorPosition(25, 20);
                        Write("[**** Opção inválida ****]");
                        Thread.Sleep(2000);
                        break;
                }

                SetCursorPosition(2, 23);
                Write("Deseja repetir? (sim/não)");
                repetir = ReadLine().ToLower();

            } while (repetir == "sim");
        }

        static void Tabuada()
        {
            int num, i;
            string repetir = "";

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkRed;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();

                SetCursorPosition(0, 0);
                Linha();

                SetCursorPosition(30, 1);
                Write("****** Tabuada ******");

                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(0, 13);
                Linha();

                SetCursorPosition(0, 26);
                Linha();

                SetCursorPosition(25,4);
                Write("Digite um número para ver a sua tabuada: ");
                while (!int.TryParse(ReadLine(), out num))
                {
                    SetCursorPosition(25, 6);
                    Write("Digite um número válido: ");
                }

                for (i = 1; i <= 10; i++)
                {
                    SetCursorPosition(2, 14 + i);
                    WriteLine($"{num} x {i} = {num * i}");
                }

                SetCursorPosition(2, 28);
                Write("Deseja repetir? (sim/não)");
                repetir = ReadLine().ToLower();

            } while (repetir == "sim");
        }

        static void ComparaNumeros()
        {
            string repetir = "";
            int num1, num2;

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkMagenta;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(23, 1);
                Write("****** Comparação de Números ******");
                SetCursorPosition(0, 2);
                Linha();
                SetCursorPosition(0, 13);
                Linha();
                SetCursorPosition(0, 19);
                Linha();

                SetCursorPosition(25, 4);
                Write("Digite o primeiro número: ");
                while (!int.TryParse(ReadLine(), out num1))
                {
                    SetCursorPosition(25, 5);
                    Write("Digite um número válido: ");
                }

                SetCursorPosition(25, 6);
                Write("Digite o segundo número: ");
                while (!int.TryParse(ReadLine(), out num2))
                {
                    SetCursorPosition(25, 7);
                    Write("Digite um número válido: ");
                }

                if (num1 > num2)
                    {
                    SetCursorPosition(25, 15);
                    WriteLine($"O número {num1} é maior que {num2}.");
                }
                else if (num1 < num2)
                {
                    SetCursorPosition(25, 15);
                    WriteLine($"O número {num1} é menor que {num2}.");
                }
                else
                {
                    SetCursorPosition(25, 15);
                    WriteLine($"Os números {num1} e {num2} são iguais.");
                }

                SetCursorPosition(2, 24);
                Write("Deseja repetir? (sim/não)");
                repetir = ReadLine().ToLower();

            } while (repetir == "sim");
        }

        static void ParImpar()
        {
            
            Clear();
            BackgroundColor = ConsoleColor.DarkCyan;
            ForegroundColor = ConsoleColor.Yellow;
            Clear();
            SetCursorPosition(0, 0);
            Linha();
            SetCursorPosition(23, 1);
            Write("****** Par ou Ímpar ******");
            SetCursorPosition(0, 2);
            Linha();
            SetCursorPosition(0, 13);
            Linha();
            SetCursorPosition(0, 19);
            Linha();
        }

        static void MediaNotas()
        {
            Clear();
            BackgroundColor = ConsoleColor.DarkYellow;
            ForegroundColor = ConsoleColor.Yellow;
            Clear();
            SetCursorPosition(0, 0);
            Linha();
            SetCursorPosition(23, 1);
            Write("****** Média de 4 Notas ******");
            SetCursorPosition(0, 2);
            Linha();
            SetCursorPosition(0, 13);
            Linha();
            SetCursorPosition(0, 19);
            Linha();
        }

        static void Descanso_Tela()
        {
            string palavra;
            int coluna, linha, cor;
            Random geranum = new Random();

            Clear();
            Write("Qual é a palavra para o preenchimento? ");
            palavra = ReadLine();
            BackgroundColor = ConsoleColor.Black;
            Clear();
 
            do
            {
                
                coluna = geranum.Next(0, 80);
                linha = geranum.Next(0, 30);
                cor = geranum.Next(1, 16);
                Thread.Sleep(50);
                ForegroundColor = (ConsoleColor)cor;
                SetCursorPosition(coluna, linha); Write(palavra);
            } while (!KeyAvailable);
        }

        static void Linha()
        {
            Write(new string('=', 80));
        }

    }
}