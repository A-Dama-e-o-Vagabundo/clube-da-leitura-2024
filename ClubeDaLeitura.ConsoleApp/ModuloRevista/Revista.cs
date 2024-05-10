using ClubeDaLeitura.ConsoleApp.ModuloCaixa;
using ClubeDaLeitura.ConsoleApp.Compartilhado;

namespace ClubeDaLeitura.ConsoleApp.ModuloRevista;
internal class Revista : EntidadeBase
{
    public string Titulo { get; set; }
    public string NumeroEdicao { get; set; }
    public string Ano {  get; set; }
    public Caixa Caixa { get; set; }

    public Revista(string titulo, string numeroEdicao, string ano, Caixa caixa)
    {

        Titulo = titulo;
        NumeroEdicao = numeroEdicao;
        Ano = ano;
        Caixa = caixa;
        //caixaSelecionada
    }

    public override string[] Validar()
    {
        string[] erros = new string[3];
        int contadorErros = 0;

        if (Titulo.Length < 3)
            erros[contadorErros++] = "O Nome precisa conter ao menos 3 caracteres";

        if (string.IsNullOrEmpty(NumeroEdicao))
            erros[contadorErros++] = "O Número da edição precisa ser preenchido";

        if (string.IsNullOrEmpty(Ano))
            erros[contadorErros++] = "O ano precisa ser preenchido";

        string[] errosFiltrados = new string[contadorErros];

        Array.Copy(erros, errosFiltrados, contadorErros);

        return errosFiltrados;
    }

}
