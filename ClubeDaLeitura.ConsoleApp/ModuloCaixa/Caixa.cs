using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string CorCaixa { get; set; }
        public int TempoEmprestimo { get; set; }
        public Revista[] Revistas { get; set; }

        public Caixa(string etiqueta, string corCaixa, int tempoEmprestimo, Revista[] revistas)
        {
            Etiqueta = etiqueta;
            CorCaixa = corCaixa;
            TempoEmprestimo = tempoEmprestimo;
            Revistas = revistas;
        }

        public override string[] Validar()
        {
            string[] erros = new string[3];
            int contadorErros = 0;

            if (string.IsNullOrEmpty(Etiqueta))
                erros[contadorErros++] = "A etiqueta precisa ser informada";

            if (string.IsNullOrEmpty(CorCaixa))
                erros[contadorErros++] = "A cor da caixa precisa ser informada";

            if (TempoEmprestimo < 0)
                erros[contadorErros++] = "O tempo estimado precisa ser maior que zero";

            string[] errosFiltrados = new string[contadorErros];

            Array.Copy(erros, errosFiltrados, contadorErros);

            return errosFiltrados;
        }
    }
}
