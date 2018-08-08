using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest.Cursos;

namespace CursoOnline.DominioTest._Builders
{
    public class CursoBuilder
    {
        private string nome = "Informática Básica";
        private double cargaHoraria = 80.00;
        private PublicoAlvo publicoAlvo = PublicoAlvo.Estudante;
        private double valor = 950.00;
        private string descricao = "Uma descrição qualquer";

        public static CursoBuilder Novo()
        {
            return new CursoBuilder();
        }

        public CursoBuilder ComNome(string nome)
        {
            this.nome = nome;
            return this;
        }

        public CursoBuilder ComCargaHoraria(double cargaHoraria)
        {
            this.cargaHoraria = cargaHoraria;
            return this;
        }

        public CursoBuilder ComPublicoAlvo(PublicoAlvo publicoAlvo)
        {
            this.publicoAlvo = publicoAlvo;
            return this;
        }
        public CursoBuilder ComValor(double valor)
        {
            this.valor = valor;
            return this;
        }

        public CursoBuilder ComDescricao(string descricao)
        {
            this.descricao = descricao;
            return this;
        }

        public Curso Build()
        {
            return new Curso(nome, descricao, cargaHoraria, publicoAlvo, valor);
        }
    }
}