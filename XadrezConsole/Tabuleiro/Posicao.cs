using System.Text;

namespace XadrezConsole.Tabuleiro
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(Linha).Append(", ").Append(Coluna);
            return builder.ToString();
        }
    }
}
