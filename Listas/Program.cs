using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas
{
    class Program
    {
        // List<T> (classe): representa uma lista fortemente tipada de objetos do tipo Pessoa que podem ser acessados pelo seu índice
        static List<Pessoa> pessoas;

        static void Main(string[] args)
        {
            pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa("Jhonathan", 19));
            pessoas.Add(new Pessoa("Lucas", 30));
            pessoas.Add(new Pessoa("Isabela", 22));
            pessoas.Add(new Pessoa("Ana", 24));


            // ForEach(): Obtendo a lista não ordenada
            ListaNaoOrdenada();

            // Sort(): Classificando os elementos em toda a lista usando um comparador padrão
            ListaOrdenadaPorNome();
            ListaOrdenadaPorIdade();

            // Insert(): Inserindo um elemento na lista em uma posição especificada
            ListaInserirItemNaPosicao();

            Console.WriteLine("\nDepois da inserção de novas pessoas: ");
            ListaNaoOrdenada();

            // Remove(): Removendo a primeira ocorrência de um objeto específico
            ListaRemoverItem();

            // Exists(): Verificando se a List<T> contém objetos que combinam as condições definidas pelo predicado especificado
            ListaVerificarSeItemExiste();

            // FindAll(): Recuperando todos os elementos que combinam as condições definidas pelo predicado especificado
            ListaLocalizaPessoaMaisVelha();

            //ListaLocalizaPessoasMenoresDeIdade();

            Console.ReadKey();

        }

        static void ListaNaoOrdenada()
        {
            Console.WriteLine("Lista Não Ordenada");

            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
        }

        static void ListaOrdenadaPorNome()
        {
            Console.WriteLine("\nLista Ordenada por Nome");

            pessoas.Sort(delegate (Pessoa p1, Pessoa p2)
            {
                return p1.Nome.CompareTo(p2.Nome);
            });

            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
        }


        static void ListaOrdenadaPorIdade()
        {
            Console.WriteLine("\nLista Ordenada por Idade");
            pessoas.Sort(delegate (Pessoa p1, Pessoa p2)
            {
                return p1.Idade.CompareTo(p2.Idade);
            });
            pessoas.ForEach(delegate (Pessoa p)
            {
                Console.WriteLine(String.Format("{0} {1}", p.Nome, p.Idade));
            });
        }

        static void ListaInserirItemNaPosicao()
        {
            Console.WriteLine("\nInserindo uma pessoa na posição 1 e outra na posição 3");

            pessoas.Insert(1, new Pessoa() { Nome = "João", Idade = 22 });
            pessoas.Insert(3, new Pessoa() { Nome = "Aline", Idade = 25 });
        }

        static void ListaRemoverItem()
        {
            Console.WriteLine("\nRemovendo objeto Pessoa:  Nome=Jhonathan, Idade=19");

            var personToRemove = pessoas.Single(p => p.Nome.Equals("Jhonathan") && p.Idade == 19);

            bool result = pessoas.Remove(personToRemove);
        }

        static void ListaVerificarSeItemExiste()
        {
            Console.WriteLine("\n" + @"Existe na Lista Pessoa com Nome = ""Jhonathan"" e Idade = 19: {0}", pessoas.Exists(p => p.Nome.Equals("Jhonathan") && p.Idade == 19));
        }

        static void ListaLocalizaPessoaMaisVelha()
        {
            Pessoa maisJovem = pessoas.OrderByDescending(p => p.Idade).ToList()[0];

            Console.WriteLine("\nPessoa mais velha é " + maisJovem.Nome);
        }
    }
}
