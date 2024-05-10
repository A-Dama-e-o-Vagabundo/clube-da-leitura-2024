using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;
internal class TelaRevista : TelaBase
{
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
                revistas.Id, revistas.Titulo, revistas.NumeroEdicao, revistas.Ano, revistas.Caixa.Etiqueta
            ) ;
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

        Console.Write("Digite de qual caixa é a revista: ");
        string caixa = Console.ReadLine();

        Amigo novoAmigo = new Amigo(titulo, numeroEdicao, ano, caixa);

        return novoAmigo;
    }

    public void CadastrarEntidadeTeste()
    {
        // Trazer a referência da tela de caixa e antes de pedir a caixa da revista mostrar a lista de caixas cadastradas (Visualizar registros)
        Revista revistas = new Revista("Turma da Mõnica", "12389", "1998", "HQs");

        repositorio.Cadastrar(revistas);
    }
}
