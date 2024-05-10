namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal abstract class EntidadeBase
    {
        public int Id { get; set; }

        public abstract string[] Validar();
    }
}
