using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        private Genero Genero { get; set; }       
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano) {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;  
        }

        public override string ToString() {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine + "\n";
            retorno += "Título: " + this.Titulo + Environment.NewLine + "\n";
            retorno += "Descrição: " + this.Descricao + Environment.NewLine + "\n";
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine + "\n";
            retorno += "Excluido: " + this.Excluido; 
            return retorno;
        }
        
        public string retornaTitulo() {
            return this.Titulo;
        }
        public int retornaId()  {
            return this.Id;
        }
        public void Exclui() {
            this.Excluido = true;
        }
        public bool retornaExcluido() {
            return this.Excluido;
        }
 
    }
}