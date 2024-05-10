using ClubeDaLeitura.ConsoleApp.ModuloAmigo;
using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Emprestimo : EntidadeBase
    {
        public string Amigo { get; set; }
        public string CorCaixa { get; set; }
        public int TempoEmprestimo { get; set; }
        public ArrayList Revistas { get; set; }

        public Emprestimo(string amigo, string revista, int tempoEmprestimo)
        {
            Amigo = amigo;
            TempoEmprestimo = tempoEmprestimo;
            Revistas = new ArrayList();
        }

        public override string[] Validar()
        {


            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Amigo))
                erros[contadorErros++] = "O nome do amigo precisa ser informado";

            if (Revistas == null)
                erros[contadorErros++] = "O nome da revista precisa ser informado";

            if (TempoEmprestimo < 0)
                erros[contadorErros++] = "O tempo estimado precisa ser maior que zero";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }

        public void GuardarRevista(Revista revista)
        {

            Revistas.Add(revista);
        }
    }
}
