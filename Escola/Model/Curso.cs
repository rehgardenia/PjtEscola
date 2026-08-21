namespace Escola.Model;

public class Curso
{
    public int Id { get; set; }
    public string Descricao { get; set; } 
    public Disciplina?[] Disciplinas { get; set; } 

    public Curso()
    {
        Id = 0;
        Descricao = string.Empty;
        Disciplinas = new Disciplina[12]; // Inicializa o array de disciplinas com capacidade para 10 disciplinas
    }
    public bool adicionarDisciplina(Disciplina disciplina)
    {
        if (disciplina != null) // Não é nulo
        {
            for (int i = 0; i < Disciplinas.Length; i++)
            {
                if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id) // Já está adicionada
                {
                    return false;
                }
                else if (Disciplinas[i] == null) // Vaga disponível
                {
                    Disciplinas[i] = disciplina;
                    return true;
                }
            }
         }
        return false;
    }
    public bool removerDisciplina(Disciplina disciplina)
    {
        if (disciplina == null)
        return false;

        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
            {
                Disciplinas[i] = null;
                return true;
            }
        }

        return false;
    }
    public Disciplina? pesquisarDisciplina(Disciplina disciplina)
    {
        for (int i = 0; i < Disciplinas.Length; i++)
        {
            if (Disciplinas[i] != null && Disciplinas[i].Id == disciplina.Id)
            {
                return Disciplinas[i];
            }
        }
        return null;
    }
 
}