using System;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario.ToUpper() != "X")
            {
                switch(opcaoUsuario)
                {
                    case "1":
                        ListarSeries();
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
                        VisualizarSerie();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            //Serie meuObjeto = new Serie();
            Console.WriteLine("Obrigado por utilizar nossos serviços!!");
            Console.WriteLine();
        }

        private static void ExcluirSerie()
        {
            Console.WriteLine("Deseja mesmo excluir esse Id?: ");
            //var Excluido = Excluido.retornaExcluido();

            /*if(Excluido.ToUpper() = "SIM")
            {
                Console.WriteLine("Será excluído o Id");
            }

            else
            {
                Console.WriteLine("Ela não será excluída!!");
            }*/
            Console.WriteLine();
            //int indiceSerie = int.Parse(Console.ReadLine());

            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            repositorio.Exclui(indiceSerie);
        }

        private static void VisualizarSerie()
        {
            Console.Write("Digite o id da Série: ");
            int indiceSerie = int.Parse(Console.ReadLine());

            var serie = repositorio.retornaPorId(indiceSerie);

            Console.WriteLine(serie);
        }

        public static void AtualizarSerie()
        {
            Console.Write("Digite o id da série: ");
            int indiceSerie = int.Parse(Console.ReadLine());
            
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));
            }

            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da Série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o Ano do início da Série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da Série: ");
            string entradaDescricao = Console.ReadLine();

            Serie atualizaSerie = new Serie(Id: indiceSerie,
                                            genero: (Genero) entradaGenero,
                                            Titulo: entradaTitulo,
                                            Ano: entradaAno,
                                            Descricao: entradaDescricao);
            repositorio.Atualiza(indiceSerie, atualizaSerie);
        }

        private static void ListarSeries()
        {
            Console.WriteLine("Listar Séries");
            var lista = repositorio.Lista();
            
            if (lista.Count == 0)
            {
                Console.WriteLine("Nenhuma Série cadastrada");
                return;
            }
            foreach (var serie in lista)
            {
                var Excluido = serie.retornaExcluido();
                Console.WriteLine("#DIO {0} - {1} {2};", serie.retornaId(), serie.retornaTitulo(), (Excluido ? "**Excluído**" : ""));
            }
            
        }

        private static void InserirSerie()
        {
            Console.WriteLine("Inserir nova série");

            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));                
            }
            Console.Write("Digite o gênero entre as opções acima: ");
            int entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o título da série: ");
            string entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano do início da série: ");
            int entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite a descrição da série: ");
            string entradaDescricao = Console.ReadLine();

            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        Titulo: entradaTitulo,
                                        Ano: entradaAno,
                                        Descricao: entradaDescricao);
                                        
            repositorio.Insere(novaSerie);
        }

        private static String ObterOpcaoUsuario() 
        {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!");
            Console.WriteLine("Informe a opção desejada: ");
            Console.WriteLine();
            
            Console.WriteLine("1- Lista Séries");
            Console.WriteLine("2- Inserir nova Série");
            Console.WriteLine("3- Atualizar Série");
            Console.WriteLine("4- Excluir Série");
            Console.WriteLine("5- Visualizar Série");
            Console.WriteLine("C- Limpar tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();
            
            string opcaoUsuario = Console.ReadLine();
            //ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
