using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Reflection.Emit;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;
internal class TelaCaixa : TelaBase
{
    public override void VisualizarRegistros(bool exibirTitulo)
    {


        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Caixas...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
            "Etiqueta", "Cor", "Revistas", "Tempo de Emprestimo"
        )

        EntidadeBase[] caixasCadastradas = repositorio.SelecionarTodos();

        foreach (Caixa caixas in caixasCadastradas)
        {
            if (caixas == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -25} | {2, -25} | {3, -15} | {4, -20}",
                caixas.Etiqueta, caixas.CorCaixa, caixas.Revistas, caixas.TempoEmprestimo
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite a etiqueta da caixa: ");
        string etiqueta = Console.ReadLine();

        Console.Write("Digite a cor da caixa: ");
        string cor = Console.ReadLine();

        Console.Write("Digite as revistas presentes na caixa: ");
        string revistas = Console.ReadLine();

        Caixa novaCaixa = new Caixa(etiqueta, cor, revistas);

        return novaCaixa;
    }

    public void CadastrarEntidadeTeste()
    {
        Caixa caixa = (Caixa)RepositorioCaixa.SelecionarTodos()[0];

        DateTime dataValidade = new DateTime(2025, 06, 20);

        Revista revista = new Revista("Turma da Mõnica", "12389", "1998", caixa);

        repositorio.Cadastrar(revista);
    }
}
