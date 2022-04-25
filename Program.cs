//using Internal;
using System.Collections.Concurrent;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Reflection.Emit;
using System.Data;
//using System;
namespace Dio.Serie
{
    public class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        static void Main(string[] args)
        {
           string OpcaoUsuario = ObterOpcaoUsuario();
           while(OpcaoUsuario.ToUpper() != "X")
           {
               switch(OpcaoUsuario)
               {
                   case "1":
                        ListarSerie();
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
               OpcaoUsuario = ObterOpcaoUsuario();
           }
           Console.WriteLine("Obrigado por utilizar nossos serviços");
           Console.ReadLine();
        }

        private static void ListarSerie()
        {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if(lista.Count==0)
            {
                 Console.WriteLine("Nenhuma Série Cadastrada");
                 return;
            }
            foreach (var serie in lista)
            {
                 Console.WriteLine("#ID {0}: . {1}", serie.retornaId(), serie.retornaTitulo());
            }
        }


          private static void InserirSerie()
          {
               Console.WriteLine("Inserir nova Série");

               foreach( int i in Enum.GetValues(typeof(Genero)))
               {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
               }
               Console.WriteLine("Digite o gênero entre as opções acima: ");
               int entradaGenero = int.Parse(Console.ReadLine());

               Console.WriteLine("Digite o título da série: ");
               string entradaTitulo = Console.ReadLine();

               Console.WriteLine("Digite o ano de início da Série: ");
               int entradaAno = int.Parse(Console.ReadLine());

               Console.WriteLine("Digite a descrição da série: ");
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
               Console.WriteLine("Digite o id da série: ");
               int indiceSerie = int.Parse(Console.ReadLine());

               foreach( int i in Enum.GetValues(typeof(Genero)))
               {
                    Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genero),i));
               }
               Console.WriteLine("Digite o gênero entre as opções acima: ");
               int entradaGenero = int.Parse(Console.ReadLine());

               Console.WriteLine("Digite o título da série: ");
               string entradaTitulo = Console.ReadLine();

               Console.WriteLine("Digite o ano de início da Série: ");
               int entradaAno = int.Parse(Console.ReadLine());

               Console.WriteLine("Digite a descrição da série: ");
               string entradaDescricao = Console.ReadLine();

               Serie novaSerie = new Serie(id: indiceSerie,
                                           genero: (Genero)entradaGenero,
                                           titulo: entradaTitulo,
                                           ano: entradaAno,
                                           descricao: entradaDescricao);
               repositorio.Insere(novaSerie);
          }

          private static void ExcluirSerie()
          {
               Console.Write("Digite o id sa série: ");
               int indiceSerie = int.Parse(Console.ReadLine());

               repositorio.Exclui(indiceSerie);

          }

           private static void VisualizarSerie()
          {
               Console.Write("Digite o id sa série: ");
               int indiceSerie = int.Parse(Console.ReadLine());

               var serie = repositorio.RetonarPorId(indiceSerie);

               Console.WriteLine(serie);

          }



          






















































        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Séries a seu dispor!!");
            Console.WriteLine("Informe a opção desejada:");

            Console.WriteLine("1, Listar séries");
            Console.WriteLine("2, Inserir nova série");
            Console.WriteLine("3, Atualizar série");
            Console.WriteLine("4, Excluir série");
            Console.WriteLine("5, Visualizar série");
            Console.WriteLine("C, Limpar tela");
            Console.WriteLine("X, Sair");
            Console.WriteLine();

            string OpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return OpcaoUsuario;
            
        }
    }
}