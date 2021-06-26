using Projeto.Enum;
using System;

namespace Projeto.Classes
{
    public class Animal : EntidadeBase
    {
        private Genero Genero { get; set; }
        private Sexo Sexo { get; set; }
        private string Nome { get; set; }
        private string Raca { get; set; }
        private int Idade { get; set; }
        private bool Excluido { get; set; }

        public Animal(int Id, Genero genero, Sexo sexo, string nome, string raca, int idade)
        {
            Genero = genero;
            Sexo = sexo;
            Nome = nome;
            Raca = raca;
            Idade = idade;
            Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";

            retorno += "Gênero: " + Genero + Environment.NewLine;
            retorno += "Sexo: " + Sexo + Environment.NewLine;
            retorno += "Nome: " + Nome + Environment.NewLine;
            retorno += "Raça: " + Raca + Environment.NewLine;
            retorno += "Idade: " + Idade + Environment.NewLine;
            retorno += "Excluido: " + Excluido + Environment.NewLine;

            return retorno;
        }

        public string retornaNome()
        {
            return Nome;

        }
        public int retornarId()
        {
            return Id;
        }

        public bool retornarExluido()
        {
            return Excluido;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}