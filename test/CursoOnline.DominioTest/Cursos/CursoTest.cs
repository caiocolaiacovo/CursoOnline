using Xunit;
using System;
using ExpectedObjects;
using CursoOnline.DominioTest._Util;
using Xunit.Abstractions;
using CursoOnline.DominioTest._Builders;
using Bogus;
using CursoOnline.Dominio.Cursos;

namespace CursoOnline.DominioTest.Cursos
{
    public class CursoTest : IDisposable
    {
        private readonly string nome;
        private readonly double cargaHoraria;
        private readonly PublicoAlvo publicoAlvo;
        private readonly double valor;
        private readonly string descricao;

        public CursoTest()
        {
            var faker = new Faker();

            nome = faker.Random.Word();
            cargaHoraria = faker.Random.Double(50, 1000);
            publicoAlvo = PublicoAlvo.Estudante;
            valor = faker.Random.Double(100,1000);
            descricao = faker.Lorem.Text();
        }

        public void Dispose()
        {
           // throw new NotImplementedException();
        }

        [Fact]
        public void DeveCriarOCurso()
        {
            var cursoEsperado = new
            {
                Nome = nome,
                CargaHoraria = cargaHoraria,
                PublicoAlvo = publicoAlvo,
                Valor = valor,
                Descricao = descricao
            };

            var curso = new Curso(cursoEsperado.Nome, cursoEsperado.Descricao, cursoEsperado.CargaHoraria, cursoEsperado.PublicoAlvo, cursoEsperado.Valor);

            cursoEsperado.ToExpectedObject().ShouldMatch(curso);
        }
        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void NaoDeveCursoTerUmNomeVazio(string nomeInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComNome(nomeInvalido).Build())
                .ComMensagem("Nome inválido");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerUmaCargaHorariaMenorQueUm(double cargaHorariaInvalida)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComCargaHoraria(cargaHorariaInvalida).Build())
                .ComMensagem("Carga horária inválida");
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void NaoDeveCursoTerUmValorMenorQueUm(double valorInvalido)
        {
            Assert.Throws<ArgumentException>(() => CursoBuilder.Novo().ComValor(valorInvalido).Build())
                .ComMensagem("Valor inválido");
        }
    }
}