using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;
internal class TelaRevista : TelaBase
{
    public TelaCaixa telaCaixa = new TelaCaixa();
    public RepositorioCaixa repositorioCaixa = null;

    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Revistas...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
            "Id", "Titulo", "Número de edição", "Ano", "Caixa"
        );

        EntidadeBase[] revistasCadastradas = repositorio.SelecionarTodos();

        foreach (Revista revistas in revistasCadastradas)
        {
            if (revistas == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                revistas.Id, revistas.Titulo, revistas.NumeroEdicao, revistas.Ano, revistas.Caixa
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite o titulo da revista: ");
        string titulo = Console.ReadLine();

        Console.Write("Digite o número da edição: ");
        string numeroEdicao = Console.ReadLine();

        Console.Write("Digite o ano: ");
        string ano = Console.ReadLine();

        telaCaixa.VisualizarRegistros(false);

        Console.Write("Digite o id da caixa: ");
        int idCaixa = Convert.ToInt32(Console.ReadLine());

        Caixa caixaSelecionada =  (Caixa)repositorioCaixa.SelecionarPorId(idCaixa);

        Revista revista = new Revista(titulo, numeroEdicao, ano, caixaSelecionada);
       
        return revista;
    }
}
