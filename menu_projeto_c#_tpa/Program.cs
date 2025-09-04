using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
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
                SetCursorPosition(25, 5); Write("[1] Menu de vetores");
                SetCursorPosition(25, 6); Write("[2] Tabuada");
                SetCursorPosition(25, 7); Write("[3] Média aritmética");
                SetCursorPosition(25, 10); Write("[6] Fim");
                SetCursorPosition(25, 11); Write("[7] Adivinhe o número");

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
                        Menu_vetores();
                        break;
                    case 2:
                        Tabuada();
                        break;
                    case 3:
                        Analisa_num();
                        break;
                    case 6: 
                        //adicionar opção de sair
                        break;
                    case 7:
                        AdivinhaNum();
                        break;
                    default: //caso contrario
                        SetCursorPosition(25, 20);
                        Write("[**** Opção inválida ****]");
                        Thread.Sleep(2000);
                        break;
                }
    
            } while (opcao != 6);
        }

        static void Menu_vetores()
        {
            int opcao = 0;

            do
            {

                Clear();
                BackgroundColor = ConsoleColor.DarkCyan;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Menu de vetores ******");
                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(25, 4); Write("[1] Consulta dia e mês");
                SetCursorPosition(25, 5); Write("[2] Consulta siglas e estados");
                SetCursorPosition(25, 6); Write("[3] Número extenso de 0 a mil");
                SetCursorPosition(25, 7); Write("[4] Ordena vetores");
                SetCursorPosition(25, 8); Write("[5] Sair");

                SetCursorPosition(0, 13);
                Linha();


                SetCursorPosition(0, 17);
                Linha();

                SetCursorPosition(25, 15);
                Write("Digite sua opção: ");
                opcao = int.Parse(ReadLine());

                switch (opcao)
                {
                    case 1:
                        Consulta_dia_mes();
                        break;
                    case 2:
                        Consulta_siglas_e_estados();
                        break;
                    case 3:
                          Extenso_0_1000();
                      break;
                    /*case 4:
                        Ordena vetor();
                        */
                    case 5:
                        //adicionar opção de sair
                        break;

                }
            }while (opcao != 5);
        }

        static void Analisa_num()
        {
            int[] v = new int[10];
            int i = 0, numpar = 0, numimp = 0, posmaior = 0, posmenor = 0, total = 0, media, maior = 0, menor = 0;
            string repetir = "";

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkMagenta;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Análise de Números ******");
                SetCursorPosition(0, 2);
                Linha();
                SetCursorPosition(0, 13);
                Linha();
                SetCursorPosition(0, 19);
                Linha();

                for (i = 0; i < 10; i++)
                {
                    SetCursorPosition(25, 4 + i);
                    Write($"Digite o {i + 1}º número: ");
                    v[i] = int.Parse(ReadLine());
                    total += v[i];
                }

                Clear();
                BackgroundColor = ConsoleColor.DarkMagenta;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Resumo da Análise ******");
                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(25, 4);
                Write("Vetor na ordem informada:");
                for (i = 0; i < 10; i++)
                {
                    SetCursorPosition(25, 5 + i);
                    Write($"{i + 1}º -> {v[i]}");
                }

                numpar = 0;
                numimp = 0;
                maior = v[0];
                menor = v[0];
                posmaior = 1;
                posmenor = 1;

                for (i = 0; i < 10; i++)
                {
                    if (v[i] % 2 == 0)
                        numpar++;
                    else
                        numimp++;

                    if (v[i] > maior)
                    {
                        maior = v[i];
                        posmaior = i + 1;
                    }
                    if (v[i] < menor)
                    {
                        menor = v[i];
                        posmenor = i + 1;
                    }
                }

                media = total / 10;

                SetCursorPosition(25, 16);
                Write($"Existem {numpar} números pares");
                SetCursorPosition(25, 17);
                Write($"Existem {numimp} números ímpares");
                SetCursorPosition(25, 18);
                Write($"O maior número digitado é: {maior} na {posmaior}ª posição");
                SetCursorPosition(25, 19);
                Write($"O menor número digitado é: {menor} na {posmenor}ª posição");
                SetCursorPosition(25, 20);
                Write($"O resultado da soma dos números é: {total}");
                SetCursorPosition(25, 21);
                Write($"A média aritmética é igual a: {media}");

                SetCursorPosition(2, 24);
                Write("Deseja repetir? (sim/não): ");
                repetir = ReadLine().ToLower();

                total = 0;

            } while (repetir == "sim");
        }

        static void Consulta_dia_mes()
        { 
            string[] dia = { "Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado" };
            string[] mes = { "Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro" };

            int n = 0, es = 0;
            string repetir = "";

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkBlue;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();

                SetCursorPosition(0, 0);
                Linha();

                SetCursorPosition(30, 1);
                Write("****** Consulta Dia/Mês ******");

                SetCursorPosition(0, 2);
                Linha();

                SetCursorPosition(0, 13);
                Linha();

                SetCursorPosition(0, 19);
                Linha();

                SetCursorPosition(25, 4);
                Write("O que deseja consultar?");
                SetCursorPosition(25, 5);
                Write("[1] Dia");
                SetCursorPosition(25, 6);
                Write("[2] Mês");
                SetCursorPosition(25, 8);
                Write("Digite sua opção: ");
                es = int.Parse(ReadLine());

                Clear();
                BackgroundColor = ConsoleColor.DarkBlue;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();

                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Resultado ******");
                SetCursorPosition(0, 2);
                Linha();

                switch (es)
                {
                    case 1:
                        SetCursorPosition(25, 4);
                        Write("Digite o número do dia (1 a 7): ");
                        n = int.Parse(ReadLine());

                        if (n < 1 || n > 7)
                        {
                            SetCursorPosition(25, 6);
                            Write("Dia inválido");
                        }
                        else
                        {
                            SetCursorPosition(25, 6);
                            Write($"Corresponde ao dia: {dia[n - 1]}");
                        }
                        break;

                    case 2:
                        SetCursorPosition(25, 4);
                        Write("Digite o número do mês (1 a 12): ");
                        n = int.Parse(ReadLine());

                        if (n < 1 || n > 12)
                        {
                            SetCursorPosition(25, 6);
                            Write("Mês inválido");
                        }
                        else
                        {
                            SetCursorPosition(25, 6);
                            Write($"{n} corresponde ao mês: {mes[n - 1]}");
                        }
                        break;
                    default:
                        SetCursorPosition(25, 6);
                        Write("Opção inválida");
                        break;
                }

                SetCursorPosition(2, 24);
                Write("Deseja repetir? (sim/não)");
                repetir = ReadLine().ToLower();

            } while (repetir == "sim");
        }

        static void Extenso_0_1000()
        {
            string repetir = "";

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkGreen;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Número por extenso de 0 a 1000 ******");
                SetCursorPosition(0, 2);
                Linha();
                SetCursorPosition(0, 13);
                Linha();
                SetCursorPosition(0, 19);
                Linha();

                string[] unidade = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove", "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
                string[] dezena = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
                string[] centena = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

                int n, c, d, u;
                string extenso = "";

                SetCursorPosition(25, 4);
                Write("Digite um número (0-1000): ");
                n = int.Parse(ReadLine());

                Clear();
                BackgroundColor = ConsoleColor.DarkGreen;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();
                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Resultado ******");
                SetCursorPosition(0, 2);
                Linha();

                if (n < 0 || n > 1000)
                {
                    SetCursorPosition(25, 6);
                    Write("Este número é inválido");
                }
                else if (n == 0)
                {
                    extenso = "zero";
                }
                else if (n == 100)
                {
                    extenso = "cem";
                }
                else if (n == 1000)
                {
                    extenso = "mil";
                }
                else if (n < 20)
                {
                    extenso = unidade[n];
                }
                else if (n < 100)
                {
                    d = n / 10;
                    u = n % 10;

                    extenso = dezena[d];

                    if (u > 0)
                    {
                        extenso += " e " + unidade[u];
                    }
                }
                else
                {
                    c = n / 100;
                    d = (n % 100) / 10;
                    u = n % 10;

                    int resto = n % 100;

                    extenso = centena[c];

                    if (resto > 0)
                    {
                        extenso += " e ";

                        if (resto < 20)
                        {
                            extenso += unidade[resto];
                        }
                        else
                        {
                            extenso += dezena[d];

                            if (u > 0)
                            {
                                extenso += " e " + unidade[u];
                            }
                        }
                    }
                }

                if (n >= 0 && n <= 1000)
                {
                    SetCursorPosition(25, 8);
                    Write($"{n} corresponde a: {extenso}");
                }

                SetCursorPosition(2, 24);
                Write("Deseja continuar? (sim/não): ");
                repetir = ReadLine().ToLower();

            } while (repetir != "não");
        }

        static void Consulta_siglas_e_estados()
        {
            string[,] estado = new string[27, 2];
            string texto, repetir = "";
            bool encontrado;
            int i;

            estado[0, 0] = "SP"; estado[0, 1] = "São Paulo";
            estado[1, 0] = "RJ"; estado[1, 1] = "Rio de Janeiro";
            estado[2, 0] = "MG"; estado[2, 1] = "Minas Gerais";
            estado[3, 0] = "PE"; estado[3, 1] = "Pernambuco";
            estado[4, 0] = "ES"; estado[4, 1] = "Espírito Santo";
            estado[5, 0] = "AC"; estado[5, 1] = "Acre";
            estado[6, 0] = "AL"; estado[6, 1] = "Alagoas";
            estado[7, 0] = "AP"; estado[7, 1] = "Amapá";
            estado[8, 0] = "AM"; estado[8, 1] = "Amazonas";
            estado[9, 0] = "BA"; estado[9, 1] = "Bahia";
            estado[10, 0] = "CE"; estado[10, 1] = "Ceará";
            estado[11, 0] = "DF"; estado[11, 1] = "Distrito Federal";
            estado[12, 0] = "GO"; estado[12, 1] = "Goiás";
            estado[13, 0] = "MA"; estado[13, 1] = "Maranhão";
            estado[14, 0] = "MT"; estado[14, 1] = "Mato Grosso";
            estado[15, 0] = "MS"; estado[15, 1] = "Mato Grosso do Sul";
            estado[16, 0] = "PA"; estado[16, 1] = "Pará";
            estado[17, 0] = "PB"; estado[17, 1] = "Paraíba";
            estado[18, 0] = "PR"; estado[18, 1] = "Paraná";
            estado[19, 0] = "PI"; estado[19, 1] = "Piauí";
            estado[20, 0] = "RN"; estado[20, 1] = "Rio Grande do Norte";
            estado[21, 0] = "RS"; estado[21, 1] = "Rio Grande do Sul";
            estado[22, 0] = "RO"; estado[22, 1] = "Rondônia";
            estado[23, 0] = "RR"; estado[23, 1] = "Roraima";
            estado[24, 0] = "SC"; estado[24, 1] = "Santa Catarina";
            estado[25, 0] = "SE"; estado[25, 1] = "Sergipe";
            estado[26, 0] = "TO"; estado[26, 1] = "Tocantins";

            do
            {
                Clear();
                BackgroundColor = ConsoleColor.DarkGreen;
                ForegroundColor = ConsoleColor.Yellow;
                Clear();

                SetCursorPosition(0, 0);
                Linha();
                SetCursorPosition(30, 1);
                Write("****** Consulta Siglas/Estados ******");
                SetCursorPosition(0, 2);
                Linha();
                SetCursorPosition(0, 13);
                Linha();
                SetCursorPosition(0, 19);
                Linha();

                SetCursorPosition(25, 4);
                Write("Informe a sigla ou o nome do estado:");
                SetCursorPosition(25, 5);
                texto = ReadLine().ToUpper();

                encontrado = false;

                for (i = 0; i < 27; i++)
                {
                    if (texto == estado[i, 0])
                    {
                        SetCursorPosition(25, 7);
                        Write($" {texto} corresponde a: {estado[i, 1]}");
                        encontrado = true;
                        break;
                    }
                    else if (texto == estado[i, 1].ToUpper())
                    {
                        SetCursorPosition(25, 7);
                        Write($" {texto} corresponde a: {estado[i, 0]}");
                        encontrado = true;
                        break;
                    }
                }

                if (!encontrado)
                {
                    SetCursorPosition(25, 9);
                    Write("Estado ou sigla inválido(a)!");
                }

                SetCursorPosition(2, 24);
                Write("Deseja repetir? (sim/não): ");
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

        static void AdivinhaNum()
        {
         
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