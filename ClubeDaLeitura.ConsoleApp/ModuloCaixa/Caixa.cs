using ClubeDaLeitura.ConsoleApp.ModuloRevista;
using ControleMedicamentos.ConsoleApp.Compartilhado;
using System.Collections;

namespace ClubeDaLeitura.ConsoleApp.ModuloCaixa
{
    internal class Caixa : EntidadeBase
    {
        public string Etiqueta { get; set; }
        public string CorCaixa { get; set; }
        public int TempoEmprestimo { get; set; }
        public ArrayList Revistas { get; set; }

        public Caixa(string etiqueta, string corCaixa, int tempoEmprestimo)
        {
            Etiqueta = etiqueta;
            CorCaixa = corCaixa;
            TempoEmprestimo = tempoEmprestimo;
            Revistas = new ArrayList();
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

        public void GuardarRevista(Revista revista)
        {
            
            Revistas.Add(revista);
        }
    }
}
