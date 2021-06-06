using System;
using System.Collections.Generic;

namespace DIO.Series
{
    class Program
    {
        static SerieRepositorio repositorio = new SerieRepositorio();
        private static int entradaGenero;
        private static string entradaTitulo;
        private static int entradaAno;
        private static string entradaDescricao;


        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "X") {

                switch (opcaoUsuario)
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
                        Console.WriteLine("Sinto muito, não há nenhuma opção daquela que escolheu! ");
                        FreezingScreen();
                        break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void ListarSeries() {
            Console.WriteLine("Listar séries");
            var lista = repositorio.Lista();
            if(lista.Count <= 0)
            {
                Console.WriteLine("Nenhuma série cadastrada.");
                FreezingScreen();
            }
            foreach (var serie in lista)
            {
                var excluido = serie.retornaExcluido();
                Console.WriteLine("#ID {0}: - {1} {2}", serie.retornaId(), serie.retornaTitulo(), (excluido? "**Excluido**": ""));
                FreezingScreen();
            }

        }
       
        private static void InserirSerie() {
            Console.WriteLine("Inserir nova séries");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
            }
            
            BasicForm();

            Serie novaSerie = new Serie(id: repositorio.ProximoId(),
                                        genero: (Genero)entradaGenero,
                                        titulo: entradaTitulo, 
                                        ano: entradaAno,
                                        descricao: entradaDescricao);
            repositorio.Insere(novaSerie);
        }

        private static void AtualizarSerie() {
            var lista = repositorio.Lista();
            Console.Write("Qual id pretende excluir? ");
            int id = int.Parse(Console.ReadLine());               
            if(ChecarExistenciaDoElemento(id, lista)){
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Genero), i));
                }

                BasicForm();

                Serie atualizaSerie = new Serie(
                    id: id,
                    genero: (Genero)entradaGenero,
                    titulo: entradaTitulo,
                    ano: entradaAno, 
                    descricao: entradaDescricao
                );

                repositorio.Atualiza(id, atualizaSerie);
            } else {
                Console.WriteLine("Não tem registro encontrado deste id passado");
            }
            FreezingScreen();
        }

        private static void ExcluirSerie() {
            Console.WriteLine("Deseja realmente excluir? Y ou N");
            string opcaoExclusao = Console.ReadLine().ToUpper();
            if(opcaoExclusao == "Y") {
                var lista = repositorio.Lista();
                Console.Write("Qual id pretende excluir? ");
                int id = int.Parse(Console.ReadLine());               
                if(ChecarExistenciaDoElemento(id, lista)){
                    repositorio.Exclui(id);
                } else {
                    Console.WriteLine("Não há qualquer registro com este id");
                }
            }
            FreezingScreen();
        }
        private static void VisualizarSerie() {

            var lista = repositorio.Lista();
            Console.Write("Qual id pretende visualizar? ");
            int id = int.Parse(Console.ReadLine());
            
            if(ChecarExistenciaDoElemento(id, lista)){
                Console.WriteLine(repositorio.RetornaPorId(id));
            } else {
                Console.WriteLine("Não tem registro encontrado deste id passado");
            }
            FreezingScreen();
        }

        private static string ObterOpcaoUsuario() {
            Console.WriteLine();
            Console.WriteLine("DIO Séries a seu dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine("1- Listar séries");
            Console.WriteLine("2- Inserir nova série");
            Console.WriteLine("3- Atualizar série");
            Console.WriteLine("4- Excluir série");
            Console.WriteLine("5- Visualizar série");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;

        }

        private static void BasicForm()
        {
            Console.Write("Digite o genêro entre as opções acima: ");
            entradaGenero = int.Parse(Console.ReadLine());

            Console.Write("Digite o Título da Série: ");
            entradaTitulo = Console.ReadLine();

            Console.Write("Digite o ano início da Série: ");
            entradaAno = int.Parse(Console.ReadLine());

            Console.Write("Digite o Descrição da Série: ");
            entradaDescricao = Console.ReadLine();
            return;
        }

        private static void FreezingScreen() {
            Console.ReadLine();
            return;
        }

        private static bool ChecarExistenciaDoElemento(int id, List<Serie> lista) {
            return lista.Exists(x => x.Id == id);
        }



    }
}
