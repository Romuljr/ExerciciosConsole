using System;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        while (true)
        {
            // Exibir o menu
            Console.Clear();
            Console.WriteLine("< Escolha uma atividade >");
            Console.WriteLine("1. Atividade 01");
            Console.WriteLine("2. Atividade 02");
            Console.WriteLine("3. Atividade 03");
            Console.WriteLine("4. Atividade 04");
            Console.WriteLine("5. Atividade 05");
            Console.WriteLine("0. Sair");
            Console.Write("\nDigite o número corresponde: ");
            // Ler a escolha do usuário
            string escolha = Console.ReadLine();

            // Processar a escolha
            switch (escolha)
            {
                case "1":
                    Atividade1();
                    break;
                case "2":
                    Atividade2();
                    break;
                case "3":
                    Atividade3();
                    break;
                case "4":
                    Atividade4();
                    break;
                case "5":
                    Atividade5();
                    break;
                case "0":
                    Console.WriteLine("Saindo...");
                    return; // Encerra o programa
                default:
                    Console.WriteLine("Escolha inválida. Tente novamente.");
                    break;
            }

            // Esperar o usuário pressionar uma tecla para continuar
            Console.WriteLine("Pressione qualquer tecla para voltar para o menu e continuar...");
            Console.ReadKey();
        }
    }

    static void Atividade1()
    {
        Console.WriteLine("Executando Atividade 1...");
        
        // Observe o trecho de código abaixo: 

        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K = K + 1; // Incrementa K
            SOMA = SOMA + K; // Adiciona K à SOMA
        }
        Console.WriteLine($"SOMA: {SOMA}"); // Imprime o valor final de SOMA

        // Ao final do processamento, qual será o valor da variável SOMA?
        // Resposta: O valor final da variável SOMA será 91.
    }

    static void Atividade2()
    {
        Console.WriteLine("Executando Atividade 2...");
        // Solicita ao usuário um número

        Console.Write("Informe um número para verificar se pertence à sequência de Fibonacci: ");
        if (int.TryParse(Console.ReadLine(), out int numero))
        {
            // Inicializa os primeiros dois números da sequência de Fibonacci
            int a = 0, b = 1;

            // Flag para verificar se o número pertence à sequência
            bool pertence = (numero == a || numero == b);

            // Calcula a sequência de Fibonacci até o número informado
            while (b < numero)
            {
                int temp = a;
                a = b;
                b = temp + b;

                if (b == numero)
                {
                    pertence = true;
                    break;
                }
            }

            // Imprime o resultado
            if (pertence)
            {
                Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
            }
            else
            {
                Console.WriteLine($"{numero} não pertence à sequência de Fibonacci.");
            }
        }
        else
        {
            Console.WriteLine("Número inválido.");
        }

    }

    static void Atividade3()
    {
        // Lê o conteúdo do arquivo JSON
        string json = File.ReadAllText("dados.json");

        // Desserializa o JSON para uma lista de dicionários
        var faturamentos = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

        if (faturamentos == null || faturamentos.Count == 0)
        {
            Console.WriteLine("Nenhum dado disponível.");
            return;
        }

        double menorValor = double.MaxValue;
        double maiorValor = double.MinValue;
        double somaValores = 0;
        int diasComFaturamento = 0;

        // Itera sobre os faturamentos para calcular menor, maior e soma
        foreach (var item in faturamentos)
        {
            if (item.TryGetValue("valor", out object valorObj) && double.TryParse(valorObj.ToString(), out double valor))
            {
                if (valor > 0) // Ignora dias sem faturamento
                {
                    somaValores += valor;
                    diasComFaturamento++;

                    if (valor < menorValor)
                        menorValor = valor;

                    if (valor > maiorValor)
                        maiorValor = valor;
                }
            }
        }

        if (diasComFaturamento == 0)
        {
            Console.WriteLine("Não há faturamento para calcular a média.");
            return;
        }

        // Calcula a média mensal
        double mediaMensal = somaValores / diasComFaturamento;

        // Conta o número de dias com faturamento superior à média mensal
        int diasAcimaDaMedia = 0;

        foreach (var item in faturamentos)
        {
            if (item.TryGetValue("valor", out object valorObj) && double.TryParse(valorObj.ToString(), out double valor))
            {
                if (valor > mediaMensal)
                    diasAcimaDaMedia++;
            }
        }

        // Exibe os resultados
        Console.WriteLine($"Menor valor de faturamento: {menorValor}");
        Console.WriteLine($"Maior valor de faturamento: {maiorValor}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
    }

    static void Atividade4()
    {
        // Valores de faturamento por estado
        double sp = 67836.43;
        double rj = 36678.66;
        double mg = 29229.88;
        double es = 27165.48;
        double outros = 19849.53;

        // Calcula o total de faturamento
        double total = sp + rj + mg + es + outros;

        // Calcula o percentual de cada estado
        double percentualSP = (sp / total) * 100;
        double percentualRJ = (rj / total) * 100;
        double percentualMG = (mg / total) * 100;
        double percentualES = (es / total) * 100;
        double percentualOutros = (outros / total) * 100;

        // Exibe os resultados
        Console.WriteLine($"Percentual de SP: {percentualSP:F2}%");
        Console.WriteLine($"Percentual de RJ: {percentualRJ:F2}%");
        Console.WriteLine($"Percentual de MG: {percentualMG:F2}%");
        Console.WriteLine($"Percentual de ES: {percentualES:F2}%");
        Console.WriteLine($"Percentual de Outros: {percentualOutros:F2}%");
    }

    static void Atividade5()
    {
        // Entrada de string definida manualmente
        Console.Write("Digite um texto:");
        string texto = Console.ReadLine();

        // Converte a string em um array de caracteres
        char[] caracteres = texto.ToCharArray();

        // Loop para inverter os caracteres
        for (int i = 0, j = caracteres.Length - 1; i < j; i++, j--)
        {
            // Troca os caracteres das posições i e j
            char temp = caracteres[i];
            caracteres[i] = caracteres[j];
            caracteres[j] = temp;
        }

        // Converte o array de volta para string
        string textoInvertido = new string(caracteres);

        // Exibe o resultado
        Console.WriteLine($"String invertida: {textoInvertido}");
    }
}
