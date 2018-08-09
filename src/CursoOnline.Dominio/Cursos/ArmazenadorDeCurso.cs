using System;

namespace CursoOnline.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly ICursoRepository cursoRepository;

        public ArmazenadorDeCurso(ICursoRepository cursoRepository)
        {
            this.cursoRepository = cursoRepository;
        }

        public void Armazenar(CursoDto cursoDto)
        {
            var cursoJaSalvo = cursoRepository.ObterPeloNome(cursoDto.Nome);

            if (cursoJaSalvo != null)
                throw new ArgumentException("Já existe um curso salvo com este nome.");

            if (!Enum.TryParse(typeof(PublicoAlvo), cursoDto.PublicoAlvo, out var publicoAlvo))
                throw new ArgumentException("Público Alvo inválido");

            var curso = new Curso(cursoDto.Nome, cursoDto.Descricao, cursoDto.CargaHoraria, (PublicoAlvo)publicoAlvo, cursoDto.Valor);

            cursoRepository.Adicionar(curso);
        }
    }
}