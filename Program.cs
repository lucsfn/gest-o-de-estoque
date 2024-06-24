/*-------------------------------------------------------------------------------------------------------------------

Nesta atividade prática iremos desenvolver uma aplicação para gerenciar o estoque de produtos de uma empresa. Nesta fase iremos criar a classe (Class) Produto ao sistema.

A classe Produto deve conter as seguintes informações:

Código do Produto
Nome do Produto
Preço do Produto
Quantidade de Produtos
Após atualizar todo o sistema para utilizar a estrutura Produto, você deve atualizar a funcionalidades para permitir:

1- Cadastrar um novo produto - OK
2- Listar todos os produtos cadastrados - OK
3- Editar dados de um produto - OK
4- Pesquisar um produto por nome - OK
5- Pesquisar um produto por código -OK
6- Listar todos os produtos com estoque inferior a 10 - OK
7- Apagar um produto - OK
8- Sair do Programa - OK

-------------------------------------------------------------------------------------------------------------------*/

using System;
using System.Globalization;

class Program
{

    public static void Main(string[] args)
    {
        CultureInfo customCulture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
        customCulture.NumberFormat.NumberDecimalSeparator = ".";
        customCulture.NumberFormat.CurrencyDecimalSeparator = ".";
        CultureInfo.CurrentCulture = customCulture;

        Estoque estoque = new Estoque();

        bool continuar = true;

        do
        {
            ImprimirMenu();

            int op = int.Parse(Console.ReadLine()!);

            switch (op)
            {

                case 1:
                    Console.Clear();
                    string stop = "";
                    Console.WriteLine("\n=====================================================================\n");
                    do
                    {

                        Console.WriteLine("Digite o código do produto:");
                        string cod = Console.ReadLine()!;
                        Console.WriteLine("Digite o nome do produto:");
                        string nome = Console.ReadLine()!;
                        Console.WriteLine("Digite o preço do produto:");
                        double preco = double.Parse(Console.ReadLine()!);
                        Console.WriteLine("Digite a quantidade do produto:");
                        int qtd = int.Parse(Console.ReadLine()!);

                        Produto produto = new Produto(cod, nome, preco, qtd);
                        estoque.AdicionarProduto(produto);

                        Console.WriteLine();
                        Console.WriteLine("Produto adicionado com sucesso!");
                        Console.WriteLine("Para adicionar outro produto, pressione qualquer caractere, para sair, digite 1.");
                        stop = Console.ReadLine()!;


                    } while (stop != "1");
                    Console.WriteLine("\n=====================================================================\n");
                    break;

                case 2:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("| Código     | Nome                 | Preço      | Quantidade |");
                    Console.WriteLine("--------------------------------------------------------------");
                    estoque.ListarProdutos();
                    Console.ReadLine();
                    break;

                case 3:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("Digite o código do produto que você quer editar:");
                    string codEditar = Console.ReadLine()!;
                    Console.WriteLine("Digite o novo nome do produto:");
                    string nomeEditar = Console.ReadLine()!;
                    Console.WriteLine("Digite o novo preço do produto:");
                    double prcEditar = double.Parse(Console.ReadLine()!);
                    Console.WriteLine("Digite a nova quantidade do produto:");
                    int qtdEditar = int.Parse(Console.ReadLine()!);

                    estoque.EditarProduto(codEditar, nomeEditar, prcEditar, qtdEditar);
                    Console.WriteLine("\n=====================================================================\n");
                    break;

                case 4:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("Digite o nome do produto para consulta:");
                    string nm = Console.ReadLine()!;
                    Console.Clear();
                    Console.WriteLine("| Código     | Nome                 | Preço      | Quantidade |");
                    Console.WriteLine("--------------------------------------------------------------");
                    estoque.PesquisarProduto(nm);

                    break;

                case 5:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("Digite o código do produto para consulta:");
                    string cd = Console.ReadLine()!;
                    Console.Clear();
                    Console.WriteLine("| Código     | Nome                 | Preço      | Quantidade |");
                    Console.WriteLine("--------------------------------------------------------------");
                    estoque.PesquisarProdutoPorCodigo(cd);
                    break;


                case 6:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("| Código     | Nome                 | Preço      | Quantidade |");
                    Console.WriteLine("--------------------------------------------------------------");
                    estoque.ListarEstoqueBaixo();

                    break;

                case 7:

                    Console.Clear();
                    Console.WriteLine("\n=====================================================================\n");
                    Console.WriteLine("Digite o código do produto que você deseja deletar:");
                    string cdDeletar = Console.ReadLine()!;
                    estoque.DeletarProduto(cdDeletar);
                    break;

                case 8:
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Digite uma opção válida!");
                    break;

            }
        } while (continuar);
    }

    public static void ImprimirMenu()
    {
        Console.WriteLine("\n=====================================================================\n");
        Console.WriteLine("Bem vindo ao estoque de produtos!\n");
        Console.WriteLine("O que você deseja fazer?\n");
        Console.WriteLine("1 - Cadastrar um novo produto");
        Console.WriteLine("2 - Listar todos os produtos cadastrados");
        Console.WriteLine("3 - Editar dados de um produto cadastrado");
        Console.WriteLine("4 - Pesquisar por dados de um produto cadastrado");
        Console.WriteLine("5 - Pesquisar um produto por código");
        Console.WriteLine("6 - Listar todos os produtos com estoque inferior a 10");
        Console.WriteLine("7 - Apagar um produto");
        Console.WriteLine("8 - Sair do Programa");
        Console.WriteLine("\n=====================================================================\n");
    }
}

class Produto
{
    public string codProduto;
    public string nomeProduto;
    public double precoProduto;
    public int qtdProduto;

    public Produto(string cod, string nome, double preco, int qtd)
    {
        codProduto = cod;
        nomeProduto = nome;
        precoProduto = preco;
        qtdProduto = qtd;
    }

    public void ExibirProduto()
    {
        Console.WriteLine($"| {codProduto,-10} | {nomeProduto,-20} | {precoProduto,-10:F2} | {qtdProduto,-10} |");
    }
}

class Estoque
{
    private int indexPreenchido;
    private int tamMaximo = 30;
    private Produto[] estoque;

    public Estoque()
    {
        estoque = new Produto[tamMaximo];
        indexPreenchido = 0;
    }

    public bool VerificarEstoque()
    {
        return indexPreenchido < tamMaximo;
    }

    public void AdicionarProduto(Produto produto)
    {
        if (VerificarEstoque())
        {
            estoque[indexPreenchido] = produto;
            indexPreenchido++;
        }
        else
        {
            Console.WriteLine("O estoque está cheio!");
            Console.WriteLine("Favor remover um produto antes de adicionar outro.");
        }
    }

    public void ListarProdutos()
    {
        if (indexPreenchido == 0)
        {
            Console.WriteLine("Estoque vazio!");
            Console.WriteLine("Preencha com produtos antes de listar.");
            return;
        }

        for (int i = 0; i < indexPreenchido; i++)
        {
            if (estoque[i] != null)
            {
                estoque[i].ExibirProduto();
            }
        }
    }

    public void EditarProduto(string cd, string nm, double prc, int qtd)
    {
        for (int i = 0; i < indexPreenchido; i++)
        {
            if (cd == estoque[i].codProduto)
            {
                estoque[i].nomeProduto = nm;
                estoque[i].precoProduto = prc;
                estoque[i].qtdProduto = qtd;
                Console.WriteLine("Produto editado com sucesso!");
                break;
            }
            else
            {
                Console.WriteLine("Não foi encontrado nenhum produto com este código!");
                Console.WriteLine("Favor verificar.");
            }
        }
    }

    public void PesquisarProduto(string nm)
    {
        bool encontrado = false;
        for (int i = 0; i < indexPreenchido; i++)
        {
            if (nm == estoque[i].nomeProduto)
            {
                estoque[i].ExibirProduto();
                encontrado = true;
                break;
            }

            if (!encontrado)
            {
                Console.WriteLine("Produto não encontrado!");
                Console.WriteLine("Favor verificar!");
            }
        }
    }

    public void PesquisarProdutoPorCodigo(string cd)
    {
        bool encontrado = false;
        for (int i = 0; i < indexPreenchido; i++)
        {
            if (cd == estoque[i].codProduto)
            {
                estoque[i].ExibirProduto();
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Produto não encontrado.");
        }
    }


    public void ListarEstoqueBaixo()
    {
        if (indexPreenchido == 0)
        {
            Console.WriteLine("Estoque vazio!");
            Console.WriteLine("Preencha com produtos antes de listar.");
            return;
        }

        for (int i = 0; i < indexPreenchido; i++)
        {
            if (estoque[i] != null && estoque[i].qtdProduto < 10)
            {
                estoque[i].ExibirProduto();
            }

            if (!(estoque[i].qtdProduto < 10))
            {
                Console.WriteLine("Não existem produtos com estoque inferior a 10 unidades.");
            }
        }
    }

    public void DeletarProduto(string cd)
    {
        bool produtoEncontrado = false;
        int indexRemover = -1;

        for (int i = 0; i < indexPreenchido; i++)
        {
            if (cd == estoque[i].codProduto)
            {
                indexRemover = i;
                produtoEncontrado = true;
                break;
            }
        }

        if (!produtoEncontrado)
        {
            Console.WriteLine("Produto não encontrado para remoção.");
            Console.WriteLine("Favor verificar.");
            return;
        }
        else
        {
            for (int i = indexRemover; i < indexPreenchido - 1; i++)
            {
                estoque[i] = estoque[i + 1];
            }
            indexPreenchido--;
            Console.WriteLine("Produto removido com sucesso!");
        }
    }
}