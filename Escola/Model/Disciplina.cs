namespace Escola.Model;

public class Disciplina{
    public int Id { get; set; } 
    public string Descricao { get; set; } 
    public Aluno?[] Alunos { get; set; }

    public Disciplina()
    {
        Id = 0;
        Descricao = string.Empty;
        Alunos = new Aluno[15]; // Inicializa o array de alunos com capacidade para 15 alunos
    }

    public bool matricularAluno(Aluno aluno)
    {
        if (aluno != null) // Não é nulo
        {
            for (int i = 0; i < Alunos.Length; i++)
            {
                if (Alunos[i] != null && Alunos[i].Id == aluno.Id) // Já está matriculado
                {
                    return false;
                }
                else if (Alunos[i] == null) // Vaga disponível
                {
                    Alunos[i] = aluno;
                    return true;
                }
            }
         }
        return false;
    }
    public bool desmatricularAluno(Aluno aluno)
    {
        if (aluno == null)
        return false;

        for (int i = 0; i < Alunos.Length; i++)
        {
            if (Alunos[i] != null && Alunos[i].Id == aluno.Id)
            {
                Alunos[i] = null;
                return true;
            }
        }

        return false;
    }
}