using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;
internal class TelaReserva : TelaBase
{
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Reserva...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
            "Id", "Revista", "Amigo", "Data empréstimo", "Dias emprestados"
        );

        EntidadeBase[] reservasCadastrados = repositorio.SelecionarTodos();

        foreach (Reserva reserva in reservasCadastrados)
        {
            if (reserva == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                reserva.Id, reserva.Revista.Titulo, reserva.Amigo.Nome, reserva.DataEmprestimo, reserva.DiasEmprestados
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Reserva reserva = new Reserva();
        
        Console.Write("Digite o título da revista: ");
        string tituloRevista = Console.ReadLine();
        tituloRevista = reserva.Revista.Titulo;

        Console.Write("Digite o nome do amigo: ");
        string nomeAmigo = Console.ReadLine();
        nomeAmigo = reserva.Amigo.Nome;

        Console.Write("Digite o telefone do amigo: ");
        DateTime dataEmprestimo = DateTime.Parse(Console.ReadLine());

        Console.Write("Digite endereço do amigo: ");
        int diasEmprestados = int.Parse(Console.ReadLine());

        Reserva novoAmigo = new Reserva(tituloRevista, nomeAmigo, dataEmprestimo, diasEmprestados);

        return novoAmigo;
    }

    public void CadastrarEntidadeTeste()
    {
        Reserva emprestimo = new Reserva("Batman", "Renatinho Souza", "14/02/2024", 3);

        repositorio.Cadastrar(emprestimo);
    }
}
