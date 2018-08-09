namespace CursoOnline.Dominio.Cursos
{
    public interface ICursoRepository
    {
        void Adicionar(Curso curso);
        Curso ObterPeloNome(string nome);
    }
}