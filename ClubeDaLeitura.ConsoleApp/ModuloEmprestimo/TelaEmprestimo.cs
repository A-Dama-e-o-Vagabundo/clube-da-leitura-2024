using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;
internal class TelaEmprestimo : TelaBase
{
    public TelaRevista telaRevista = null;
    public RepositorioRevista repositorioRevista = null;

    public override void VisualizarRegistros(bool exibirTitulo)
    {

        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Emprestimos...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
            "Amigo", "Revista", "TempoEmprestimo"
        );

        EntidadeBase[] emprestimosCadastrados = repositorio.SelecionarTodos();

        foreach (Emprestimo emprestimos in emprestimosCadastrados)
        {
            if (emprestimos == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                emprestimos.Id, emprestimos.Amigo, emprestimos.Revistas, emprestimos.TempoEmprestimo
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite o nome do amigo: ");
        string amigo = Console.ReadLine();

        Console.Write("Digite o nome da revista: ");
        string revista = Console.ReadLine();

        Console.Write("Digite o nome da caixa: ");
        string caixa = Console.ReadLine();

        Console.Write("Digite o tempo de empréstimo em dias: ");
        int tempoEmprestimo = int.Parse(Console.ReadLine());


        Caixa novaCaixa = new Caixa(amigo, revista, tempoEmprestimo);

        return novaCaixa;
    }
}
