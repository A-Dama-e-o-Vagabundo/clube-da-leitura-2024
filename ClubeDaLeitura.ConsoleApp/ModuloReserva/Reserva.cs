using ClubeDaLeitura.ConsoleApp.Compartilhado;
using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;

namespace ClubeDaLeitura.ConsoleApp.ModuloReserva;
internal class Reserva : EntidadeBase
{
    public Revista Revista { get; set; }
    public Amigo Amigo { get; set; }
    public DateTime DataEmprestimo {  get; set; }
    public int DiasEmprestados { get; set; }

    public Reserva()
    {

    }

    public Reserva(Revista revista, Amigo amigo, DateTime dataEmprestimo, int diasEmprestados)
    {
        Revista = revista;
        Amigo = amigo;
        DataEmprestimo = dataEmprestimo;
        DiasEmprestados = diasEmprestados;
    }
    
    public override string[] Validar()
    {
        string[] erros = new string[3];
        int contadorErros = 0;

        if (DataEmprestimo == null)
            erros[contadorErros++] = "A data de emprestimo precisa ser informada";

        if (DiasEmprestados == null)
            erros[contadorErros++] = "O número de dias emprestados precisa ser informado";

        string[] errosFiltrados = new string[contadorErros];

        Array.Copy(erros, errosFiltrados, contadorErros);

        return errosFiltrados;
    }
}
