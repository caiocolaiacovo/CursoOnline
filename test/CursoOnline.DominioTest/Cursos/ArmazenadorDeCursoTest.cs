using System;
using Bogus;
using CursoOnline.Dominio.Cursos;
using CursoOnline.DominioTest._Builders;
using CursoOnline.DominioTest._Util;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        private readonly CursoDto cursoDto;
        private readonly Mock<ICursoRepository> cursoRepositoryMock;
        private readonly ArmazenadorDeCurso armazenadorDeCurso;

        public ArmazenadorDeCursoTest()
        {
            var faker = new Faker();

            cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição",
                CargaHoraria = 80,
                PublicoAlvo = "Estudante",
                Valor = 850.00
            };

            cursoRepositoryMock = new Mock<ICursoRepository>();
            armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositoryMock.Object);
        }

        [Fact]
        public void DeveAdicionarCurso()
        {
            armazenadorDeCurso.Armazenar(cursoDto);
            cursoRepositoryMock.Verify(r => 
                r.Adicionar(
                    It.Is<Curso>(c => c.Nome == cursoDto.Nome)
                )
            );
        }
        [Fact]
        public void NaoDeveAdicionarCursoComMesmoNomeDeOutroJaSalvo()
        {
            var cursoJaSalvo = CursoBuilder.Novo().ComNome(cursoDto.Nome).Build();
            cursoRepositoryMock.Setup(r => r.ObterPeloNome(cursoDto.Nome)).Returns(cursoJaSalvo);

            Assert.Throws<ArgumentException>(() => armazenadorDeCurso.Armazenar(cursoDto))
                .ComMensagem("Já existe um curso salvo com este nome.");
        }

        [Fact]
        public void NaoDeveAdicionarPublicoAlvoInvalido()
        {
            var publicoAlvoInvalido = "Médico";
            cursoDto.PublicoAlvo = publicoAlvoInvalido;

            Assert.Throws<ArgumentException>(() => armazenadorDeCurso.Armazenar(cursoDto))
                .ComMensagem("Público Alvo inválido");
        }
    }
}