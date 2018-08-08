using System;
using CursoOnline.Dominio.Cursos;
using Moq;
using Xunit;

namespace CursoOnline.DominioTest.Cursos
{
    public class ArmazenadorDeCursoTest
    {
        [Fact]
        public void DeveAdicionarCurso()
        {
            var cursoDto = new CursoDto
            {
                Nome = "Curso A",
                Descricao = "Descrição",
                CargaHoraria = 80,
                PublicoAlvoId = 1,
                Valor = 850.00
            };

            var cursoRepositoryMock = new Mock<ICursoRepository>();
            var armazenadorDeCurso = new ArmazenadorDeCurso(cursoRepositoryMock.Object);

            armazenadorDeCurso.Armazenar(cursoDto);
            cursoRepositoryMock.Verify(r => r.Adicionar(It.IsAny<Curso>()));
        }
    }

    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
    }

    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepository cursoRepository;

        public ArmazenadorDeCurso(ICursoRepository cursoRepository)
        {
            this.cursoRepository = cursoRepository;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, PublicoAlvo.Estudante, cursoDto.Valor);

            cursoRepository.Adicionar(curso);
        }
    }

    public class CursoDto
    {
        public string Nome { get;  set; }
        public string Descricao { get;  set; }
        public double CargaHoraria { get;  set; }
        public int PublicoAlvoId { get;  set; }
        public double Valor { get;  set; }
    }
}