```c#

		
```

# Cadastro de Séries 🚨

#### Cadastro feito no Visual Studio Code, pada cadastrar as séries que já assistiu ou vai assistir, usando a linguagem C#.#

##### Neste cadastro utilizamos as class "Gênero, IRepositorio, Serie, Repositorio, EntidadeBase e SerieRepositorio, ", para que o program.cs funciona-se e consegui-se rodar o programa sem nenhum erro.

1. *Gênero*:

##### Em gênero utilizamos os parâmetros para ser "chamado" no programa principal program.cs:

​        Acao = 1,

​        Aventura = 2,

​        Comedia = 3,

​        Documentario = 4,

​        Drama = 5,

​        Espionagem = 6,

​        Faroeste = 7,

​        Fantasia = 8,

​        Ficcao_Cientifica = 9,

​        Musical = 10,

​        Romance = 11,

​        Suspense = 12,

​        Terror = 13,

2. *Serie*:

   ##### Na class Serie.cs, utilizamos alguns comandos para dar valor ao "Genero, Título, Descrição e o Ano", em que, abaixo, estará os códigos utilizado nessa class. 

   using System;

   namespace DIO.Series

   {

   ​    public class Serie : EntidadeBase

   ​    {

   ​        //Atributos:

   ​        public Serie(Genero genero, string titulo, string descricao, int ano)

   ​        {

   ​            this.Genero = genero;

   ​            this.Titulo = titulo;

   ​            this.Descricao = descricao;

   ​            this.Ano = ano;

   ​        }

   ​    

   ​        private Genero Genero { get; set; }

   ​        private string Titulo { get; set; }

   ​        private string Descricao { get; set; }

   ​        private int Ano { get; set; }

   ​        private bool Excluido{get; set;}

   ​        //Métodos:

   ​        public Serie(int Id, Genero genero, string Titulo, string Descricao, int Ano)

   ​        {

   ​            this.Id = Id;

   ​            this.Genero = genero;

   ​            this.Titulo = Titulo;

   ​            this.Descricao = Descricao;

   ​            this.Ano = Ano;

   ​            this.Excluido = false;

   ​        }

   ​        public override string ToString()

   ​        {

   ​            string retorno = "";

   ​            retorno += "Gênero: " + this.Genero + Environment.NewLine;

   ​            retorno += "Título: " + this.Titulo + Environment.NewLine;

   ​            retorno += "Descrição: " + this.Descricao + Environment.NewLine;

   ​            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;

   ​            retorno += "Excluída: " + this.Excluido;

   ​            return retorno;

   ​        }

   ​        //Encapisulamento:

   ​        public string retornaTitulo()

   ​        {

   ​            return this.Titulo;

   ​        }

   ​        public int retornaId()

   ​        {

   ​            return this.Id;

   ​        }

   ​        public bool retornaExcluido()

   ​        {

   ​            return this.Excluido;

   ​        }

   ​        public void Excluir()

   ​        {

   ​            this.Excluido = true;

   ​        }

   ​    }

   } 

   ​

3. *SerieRepositorio*:

   ##### Em SerieRepositorio utilizamos os parâmetros "Atualiza, Exclui, Insere, Lista, ProximoId e retornaPorId", para quando, por exemplo, quiser excluir alguma série ou mudar o nome dela, será utilizado esses valores falado a cima. Abaixo os comandos: 

   using System;

   using System.Collections.Generic;

   using DIO.Series.Interfaces;

   namespace DIO.Series

   {

   ​    public class SerieRepositorio : IRepositorio<Serie>

   ​    {

   ​        public List<Serie> listaSerie = new List<Serie>();

   ​        public void Atualiza(int id, Serie objeto)

   ​        {

   ​            listaSerie[id] = objeto; 

   ​        }

   ​        public void Exclui(int id)

   ​        {

   ​            listaSerie[id].Excluir();

   ​        }

   ​        public void Insere(Serie objeto)

   ​        {

   ​            listaSerie.Add(objeto);

   ​        }

   ​        public List<Serie> Lista()

   ​        {

   ​            return listaSerie;

   ​        }

   ​        public int ProximoId()

   ​        {

   ​            return listaSerie.Count;

   ​        }

   ​        public Serie retornaPorId(int id)

   ​        {

   ​            return listaSerie[id];

   ​        }

   ​    }

   }


   4. *IRepositorio*

      ##### Sendo essa class, responsável por "guardar", vamos assim dizer, os parâmetros utilizado na SerieRepositorio. Abaixo os comandos utilizado:

      using System.Collections.Generic;

      namespace DIO.Series.Interfaces

      {

      ​    public interface IRepositorio<T>

      ​    {

      ​        //Repositório:

      ​        List<T> Lista();

      ​        T retornaPorId(int id);

      ​        void Insere(T entidade);

      ​        void Exclui(int id);

      ​        void Atualiza(int id, T entidade);

      ​        int ProximoId();

      ​    }

      }


      5. *EntidadeBase*:

         #####Nesta class é aonde vamos apresentar o Id para ser aceito nas outras class. Abaixo o comando:

         namespace DIO.Series

         {

         ​    public abstract class EntidadeBase

         ​    {

         ​        public int Id {get; protected set;}

         ​        

         ​    }

         }

​          

         6. *Program.cs*

            ##### Nessa class, a principal, é aonde terá os comandos principais para que o programa rode na IDE ou em algum console. É aonde escreveremos os parâmetros para que o mesmo rode, através dos valores dado nas outras class. Abaixo o comando: 

            using System;

            namespace DIO.Series

            {

            ​    class Program

            ​    {

            ​        static SerieRepositorio repositorio = new SerieRepositorio();

            ​        static void Main(string[] args)

            ​        {

            ​            string opcaoUsuario = ObterOpcaoUsuario();

            ​            while(opcaoUsuario.ToUpper() != "X")

            ​            {

            ​                switch(opcaoUsuario)

            ​                {

            ​                    case "1":

            ​                        ListarSeries();

            ​                        break;

            ​                    case "2":

            ​                        InserirSerie();

            ​                        break;

            ​                    case "3":

            ​                        AtualizarSerie();

            ​                        break;

            ​                    case "4":

            ​                        ExcluirSerie();

            ​                        break;

            ​                    case "5":

            ​                        VisualizarSerie();

            ​                        break;

            ​                    case "C":

            ​                        Console.Clear();

            ​                        break;

            ​                    

            ​                    default:

            ​                        throw new ArgumentOutOfRangeException();

            ​                }

            ​                opcaoUsuario = ObterOpcaoUsuario();

            ​            }

            ​            

            ​            //Serie meuObjeto = new Serie();

            ​            Console.WriteLine("Obrigado por utilizar nossos serviços!!");

            ​            Console.WriteLine();

            ​        }

            ​        private static void ExcluirSerie()

            ​        {

            ​            Console.WriteLine("Deseja mesmo excluir esse Id?: ");

            ​            //var Excluido = Excluido.retornaExcluido();

            ​            /*if(Excluido.ToUpper() = "SIM")

            ​            {

            ​                Console.WriteLine("Será excluído o Id");

            ​            }

            ​            else

            ​            {

            ​                Console.WriteLine("Ela não será excluída!!");

            ​            }*/

            ​            Console.WriteLine();

            ​            //int indiceSerie = int.Parse(Console.ReadLine());

            ​            Console.Write("Digite o id da série: ");

            ​            int indiceSerie = int.Parse(Console.ReadLine());

            ​            repositorio.Exclui(indiceSerie);

            ​        }

            ​        private static void VisualizarSerie()

            ​        {

            ​            Console.Write("Digite o id da Série: ");

            ​            int indiceSerie = int.Parse(Console.ReadLine());

            ​            var serie = repositorio.retornaPorId(indiceSerie);

            ​            Console.WriteLine(serie);

            ​        }

            ​        public static void AtualizarSerie()

            ​        {

            ​            Console.Write("Digite o id da série: ");

            ​            int indiceSerie = int.Parse(Console.ReadLine());

            ​            

            ​            foreach (int i in Enum.GetValues(typeof(Genero)))

            ​            {

            ​                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero), i));

            ​            }

            ​            Console.Write("Digite o gênero entre as opções acima: ");

            ​            int entradaGenero = int.Parse(Console.ReadLine());

            ​            Console.Write("Digite o título da Série: ");

            ​            string entradaTitulo = Console.ReadLine();

            ​            Console.Write("Digite o Ano do início da Série: ");

            ​            int entradaAno = int.Parse(Console.ReadLine());

            ​            Console.Write("Digite a descrição da Série: ");

            ​            string entradaDescricao = Console.ReadLine();

            ​            Serie atualizaSerie = new Serie(Id: indiceSerie,

            ​                                            genero: (Genero) entradaGenero,

            ​                                            Titulo: entradaTitulo,

            ​                                            Ano: entradaAno,

            ​                                            Descricao: entradaDescricao);

            ​            repositorio.Atualiza(indiceSerie, atualizaSerie);

            ​        }

            ​        private static void ListarSeries()

            ​        {

            ​            Console.WriteLine("Listar Séries");

            ​            var lista = repositorio.Lista();

            ​            

            ​            if (lista.Count == 0)

            ​            {

            ​                Console.WriteLine("Nenhuma Série cadastrada");

            ​                return;

            ​            }

            ​            foreach (var serie in lista)

            ​            {

            ​                var Excluido = serie.retornaExcluido();

            ​                Console.WriteLine("#DIO {0} - {1} {2};", serie.retornaId(), serie.retornaTitulo(), (Excluido ? "**Excluído**" : ""));

            ​            }

            ​            

            ​        }

            ​        private static void InserirSerie()

            ​        {

            ​            Console.WriteLine("Inserir nova série");

            ​            foreach (int i in Enum.GetValues(typeof(Genero)))

            ​            {

            ​                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));                

            ​            }

            ​            Console.Write("Digite o gênero entre as opções acima: ");

            ​            int entradaGenero = int.Parse(Console.ReadLine());

            ​            Console.Write("Digite o título da série: ");

            ​            string entradaTitulo = Console.ReadLine();

            ​            Console.Write("Digite o ano do início da série: ");

            ​            int entradaAno = int.Parse(Console.ReadLine());

            ​            Console.Write("Digite a descrição da série: ");

            ​            string entradaDescricao = Console.ReadLine();

            ​            Serie novaSerie = new Serie(Id: repositorio.ProximoId(),

            ​                                        genero: (Genero)entradaGenero,

            ​                                        Titulo: entradaTitulo,

            ​                                        Ano: entradaAno,

            ​                                        Descricao: entradaDescricao);

            ​                                        

            ​            repositorio.Insere(novaSerie);

            ​        }

            ​        private static String ObterOpcaoUsuario() 

            ​        {

            ​            Console.WriteLine();

            ​            Console.WriteLine("DIO Séries a seu dispor!!");

            ​            Console.WriteLine("Informe a opção desejada: ");

            ​            Console.WriteLine();

            ​            

            ​            Console.WriteLine("1- Lista Séries");

            ​            Console.WriteLine("2- Inserir nova Série");

            ​            Console.WriteLine("3- Atualizar Série");

            ​            Console.WriteLine("4- Excluir Série");

            ​            Console.WriteLine("5- Visualizar Série");

            ​            Console.WriteLine("C- Limpar tela");

            ​            Console.WriteLine("X- Sair");

            ​            Console.WriteLine();

            ​            

            ​            string opcaoUsuario = Console.ReadLine();

            ​            //ToUpper();

            ​            Console.WriteLine();

            ​            return opcaoUsuario;

            ​        }

            ​    }

            }