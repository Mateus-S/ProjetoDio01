using System;
using Projeto.Classes;
using Projeto.Enum;


namespace Projeto
{
    class Program
    {
        static AnimalRepositorio repositorio = new AnimalRepositorio();
        static void Main(string[] args)
        {
            string OpcaoUsuario = ObeterOpcaoUsuario();

            while (OpcaoUsuario.ToUpper() != "X")
            {
                switch (OpcaoUsuario)
                {
                    case "1":
                        ListarAnimais();
                        break;
                    case "2":
                        InserirAnimal();
                        break;
                    case "3":
                        AtualizarAnimal();
                        break;
                    case "4":
                        ExcluirAnimal();
                        break;
                    case "5":
                        VizualizarAnimal();
                        break;
                    case "C":
                        Console.Clear();
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();

                }

                OpcaoUsuario = ObeterOpcaoUsuario();

            }
            Console.WriteLine("Obrigado por Utilizar nossos Serviços.");
            Console.WriteLine();
        }

        private static void ListarAnimais()
        {
            Console.WriteLine("Listar Animais");
            var lista = repositorio.Lista();
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhum Animal Cadastrado");
                return;
            }
            foreach (var animal in lista)
            {
                var excluido = animal.retornarExluido();
                Console.WriteLine("#ID {0}; - {1} {2}", animal.retornarId(), animal.retornaNome(), (excluido ? "*Excluido*" : ""));

            }

        }

        private static void InserirAnimal()
        {
            Console.WriteLine("Inserir novo Animal!");

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Gênero de acordo com as inforções acima.");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in System.Enum.GetValues(typeof(Sexo)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Sexo), i));
            }
            Console.WriteLine("Digite o Sexo de acordo com as inforções acima.");
            int entradaSexo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o nome do Animal.");
            string Nome = Console.ReadLine();

            Console.WriteLine("Digite a Raça do Animal.");
            string Raca = Console.ReadLine();

            Console.WriteLine("Digite a Idade do Animal.");
            int Idade = int.Parse(Console.ReadLine());

            Animal novoAnimal = new Animal(Id: repositorio.ProximoId(),
                                       genero: (Genero)entradaGenero,
                                       sexo: (Sexo)entradaSexo,
                                       nome: Nome,
                                       raca: Raca,
                                       idade: Idade);
            repositorio.Insere(novoAnimal);
        }

        private static void AtualizarAnimal()
        {
            Console.WriteLine("Digite o Id do Animal.");
            int Id = int.Parse(Console.ReadLine());

            foreach (int i in System.Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Genero), i));
            }
            Console.WriteLine("Digite o Gênero de acordo com as inforções acima.");
            int entradaGenero = int.Parse(Console.ReadLine());
            Console.WriteLine();

            foreach (int i in System.Enum.GetValues(typeof(Sexo)))
            {
                Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(Sexo), i));
            }
            Console.WriteLine("Digite o Sexo de acordo com as inforções acima.");
            int entradaSexo = int.Parse(Console.ReadLine());
            Console.WriteLine();

            Console.WriteLine("Digite o nome do Animal.");
            string Nome = Console.ReadLine();

            Console.WriteLine("Digite a Raça do Animal.");
            string Raca = Console.ReadLine();

            Console.WriteLine("Digite a Idade do Animal.");
            int Idade = int.Parse(Console.ReadLine());

            Animal atualizarAnimal = new Animal(Id: Id,
                                       genero: (Genero)entradaGenero,
                                       sexo: (Sexo)entradaSexo,
                                       nome: Nome,
                                       raca: Raca,
                                       idade: Idade);
            repositorio.Atualiza(Id, atualizarAnimal);

        }

        private static void ExcluirAnimal()
        {
            Console.WriteLine("Informe o Id do Animal.");
            int id = int.Parse(Console.ReadLine());

            repositorio.Exclui(id);
        }

        private static void VizualizarAnimal()
        {
            Console.WriteLine("Informe o Id.");
            int id = int.Parse(Console.ReadLine());

            var animal = repositorio.RetornaPorId(id);

            Console.WriteLine(animal);            
            
        }


        private static string ObeterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Cadastro de Animais!");
            Console.WriteLine("Informe a opção desejada!");

            Console.WriteLine("1- Listar Animais!");
            Console.WriteLine("2- Inserir Novo Animal!");
            Console.WriteLine("3- Atualizar Animal!");
            Console.WriteLine("4- Excluir Animal!");
            Console.WriteLine("5- Vizualizar Animal");
            Console.WriteLine("C- Limpar Tela!");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
