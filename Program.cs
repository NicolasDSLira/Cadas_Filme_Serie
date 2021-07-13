using System;
using System.Collections;
using Cadastro_Series.Interfaces;
using Cadastro_Series.Generos;


namespace Cadastro_Series
{
    class Program
    {

        static SerieRepositorio repositorio = new SerieRepositorio();
        static FilmeRepositorio repositorioF = new FilmeRepositorio();
        static void Main(string[] args)
        {
            string optionUser = OptionOne();

            while (optionUser.ToUpper() != "X")
            {
                switch (optionUser)
                {
                    case "1":

                       string opcaoUsuario = ObterOpcaoUsuarioUm();

                        while (opcaoUsuario.ToUpper() != "X")
                        {
                            switch (opcaoUsuario)
                            {
                                case "1":
                                    Console.WriteLine();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    ListarSeries();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine();
                                    Console.Write("Precione qualquer tecla");
                                    Console.ReadKey();
                                    break;

                                case "2":
                                    InserirSerie();
                                    break;

                                case "3":
                                    AtualizarSerie();
                                    break;

                                case "4":
                                    ExcluirSerie();
                                    break;

                                case "5":
                                   Console.WriteLine();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    VisualizarSerie();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine();
                                    Console.Write("Precione qualquer tecla");
                                    Console.ReadKey();
                                    break;

                                case "C":
                                    Console.Clear();
                                    break; 

                                default:
                                    throw new ArgumentOutOfRangeException();
                            }
                                opcaoUsuario = ObterOpcaoUsuarioUm();
                        }
                    break;

                    case "2":
                        string opcaoUsuarioF = ObterOpcaoUsuarioDois();

                        while (opcaoUsuarioF.ToUpper() != "X")
                        {
                            switch (opcaoUsuarioF)
                            {
                               case "1":
                                    Console.WriteLine();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    ListarFilme();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine();
                                    Console.Write("Precione qualquer tecla");
                                    Console.ReadKey();
                                    break;

                                case "2":
                                    InserirFilme();
                                    break;

                                case "3":
                                    AtualizarFilme();
                                    break;                    

                                case "4":
                                    ExcluirFilme();
                                    break;

                                case "5":
                                    Console.WriteLine();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    VisualizarFilme();
                                    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
                                    Console.WriteLine();
                                    Console.Write("Precione qualquer tecla");
                                    Console.ReadKey();
                                    break;

                                case "C":
                                    Console.Clear();
                                    break; 

                                default:
                                    throw new ArgumentOutOfRangeException();
                            }

                            opcaoUsuarioF = ObterOpcaoUsuarioDois();
                        }

                    break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }

                optionUser = OptionOne();
            }
                
            Console.WriteLine("Obrigado por utilizar nossos serviços.");
            Console.WriteLine("Desenvolvido por Nicolas dos Santos Lira;");
			Console.ReadLine();
        }

        public static string OptionOne()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine("}-_- BEM VINDO A 'THE BIG LIST' -_-{");
            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Digite 1 para séries");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Digite 2 para filmes");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("X - Sair");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();

            string optionUser = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return optionUser;
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar séries");

            var lista = repositorio.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há séries cadastradas");
                return;
            }

            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();

        
                Console.WriteLine("#ID {0}: - {1}  {2}", 
                                serie.retornaID(), 
                                serie.retornaTitulo(), 
                                excluido ?  " *Excluido* " : "");
            }
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série a lista:");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano a qual a série começou: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie()
        {
            Console.Write("Digite o ID da série: ");

            int indiceSerie = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano a qual a série começou: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizarSerie = new Serie(id: indiceSerie,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorio.Atualizar(indiceSerie, atualizarSerie);
        }

        private static void ExcluirSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Excluir(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.RetornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static string ObterOpcaoUsuarioUm()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("}- Opcão 1 - Séries -{");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("1 - Listar Séries");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("2 - inserir nova série");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("3 - Atualizar série");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("4 - Excluir série");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("5 - Visualizar série");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("X - Sair");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }

        private static void ListarFilme()
        {
            Console.WriteLine("Lista de Filmes");

            var lista = repositorioF.Lista();

            if (lista.Count == 0)
            {
                Console.WriteLine("Não há Filmes cadastradas");
                return;
            }

            foreach (var filme in lista)
            {
                var excluido = filme.retornaExcluido();

        
                Console.WriteLine("#ID {0}: - {1}  {2}", 
                                filme.retornaID(), 
                                filme.retornaTitulo(), 
                                excluido ?  " *Excluido* " : "");
            }
        }

        private static void InserirFilme()
        {
            Console.WriteLine("Inserir novo filme a lista");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano que o filme foi lançado: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme novoFilme = new Filme(id: repositorioF.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            
            repositorioF.Insere(novoFilme);
        }

        private static void AtualizarFilme()
        {
            Console.Write("Digite o ID do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            foreach (var i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título do Filme: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano que o filme foi lançado: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição do Filme: ");
            string entradaDescricao = Console.ReadLine();

            Filme atualizarFilme = new Filme(id: indiceFilme,
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo,
                                        ano: entradaAno,
                                        descricao: entradaDescricao);

            repositorioF.Atualizar(indiceFilme, atualizarFilme);
        }

        private static void ExcluirFilme()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            repositorioF.Excluir(indiceFilme);
        }

        private static void VisualizarFilme()
        {
            Console.Write("Digite o id do Filme: ");
            int indiceFilme = int.Parse(Console.ReadLine());

            var serie = repositorioF.RetornaPorId(indiceFilme);

            Console.WriteLine(serie);
        }


        public static string ObterOpcaoUsuarioDois()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("}- Opcão 2 - Filmes -{");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("1 - Listar Filmes");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("2 - inserir novo Filme");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("3 - Atualizar Filme");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("4 - Excluir Filme");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("5 - Visualizar Filme");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("X - Sair");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine();

            string opcaoUsuarioF = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuarioF;
        }


    }
}
