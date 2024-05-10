using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloAmigo
{
    internal class TelaAmigo : TelaBase
    {
        public override void VisualizarRegistros(bool exibirTitulo)
        {
            if (exibirTitulo)
            {
                ApresentarCabecalho();

                Console.WriteLine("Visualizando Amigos...");
            }

            Console.WriteLine();

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                "Id", "Nome", "Nome do responsável", "Telefone", "Endereco"
            );

            EntidadeBase[] amigosCadastrados = repositorio.SelecionarTodos();

            foreach (Amigo amigos in amigosCadastrados)
            {
                if (amigos == null)
                    continue;

                Console.WriteLine(
                    "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                    amigos.Id, amigos.Nome, amigos.NomeResponsavel, amigos.Telefone, amigos.Endereco
                );
            }

            Console.ReadLine();
            Console.WriteLine();
        }

        protected override EntidadeBase ObterRegistro()
        {
            Console.Write("Digite o nome do amigo: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do responsável: ");
            string nomeResponsavel = Console.ReadLine();

            Console.Write("Digite o telefone do amigo: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite endereço do amigo: ");
            string endereco = Console.ReadLine();

            Amigo novoAmigo = new Amigo(nome, nomeResponsavel, telefone, endereco);

            return novoAmigo;
        }

        public void CadastrarEntidadeTeste()
        {
            Amigo paciente = new Amigo("Cleitinho Souza", "Renatinho Souza", "(49)999662092", "Bela Vista");

            repositorio.Cadastrar(paciente);
        }
    }
}
