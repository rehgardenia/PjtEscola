namespace Escola.Model;

public class EscolaModel{
    public Curso?[] Cursos { get; set; }

    public EscolaModel()
    {
        Cursos = new Curso[5]; // Inicializa o array de cursos com capacidade para 5 cursos
    }
    public bool adicionarCurso(Curso curso)
    {
        if (curso != null) // Não é nulo
        {
            for (int i = 0; i < Cursos.Length; i++)
            {
                if (Cursos[i] != null && Cursos[i].Id == curso.Id) // Já está adicionado
                {
                    return false;
                }
                else if (Cursos[i] == null) // Vaga disponível
                {
                    Cursos[i] = curso;
                    return true;
                }
            }
         }
        return false;
    }
    public bool removerCurso(Curso curso)
    {
        if (curso == null)
            return false;

        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] != null && Cursos[i].Id == curso.Id)
            {
                Cursos[i] = null;
                return true;
            }
        }

        return false;
    }
    public Curso? pesquisarCurso(Curso curso)
    {
        for (int i = 0; i < Cursos.Length; i++)
        {
            if (Cursos[i] != null && Cursos[i].Id == curso.Id)
            {
                return Cursos[i];
            }
        }
        return null;
    }
}