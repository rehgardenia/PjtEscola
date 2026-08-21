
using Escola.Model;


public static class Program
{
    private static EscolaModel escola = new EscolaModel();

    private static int LerId(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);

            if (int.TryParse(Console.ReadLine(), out int id) && id > 0)
                return id;

            Console.WriteLine("Valor inválido. Digite um número inteiro maior que zero.");
        }
    }

    private static string LerTextoObrigatorio(string mensagem)
    {
        while (true)
        {
            Console.Write(mensagem);
            string? texto = Console.ReadLine()?.Trim();

            if (!string.IsNullOrWhiteSpace(texto))
                return texto;

            Console.WriteLine("Este campo é obrigatório.");
        }
    }
  
    public static void AdicionarCurso()
    {
        int id = LerId("Digite o ID do curso: ");
        string descricao = LerTextoObrigatorio("Digite a descrição do curso: ");

        Curso curso = new Curso { Id = id, Descricao = descricao };
        if (escola.adicionarCurso(curso)){
            Console.WriteLine("Curso adicionado com sucesso!");
        } else {
            Console.WriteLine("Não foi possível adicionar o curso. Verifique se o ID já existe ou se há espaço disponível.");
        }   
    }
    public static void PesquisarCurso()
    {
      // Mostrar as disciplinas associadas ao curso pesquisado

      int id = LerId("Digite o ID do curso a ser pesquisado: ");

      Curso curso = new Curso { Id = id };
      Curso? cursoEncontrado = escola.pesquisarCurso(curso);
      if (cursoEncontrado != null)
      {
          Console.WriteLine($"Curso encontrado: ID = {cursoEncontrado.Id}, Descrição = {cursoEncontrado.Descricao}");
          Console.WriteLine("Disciplinas associadas:");
          foreach (var disciplina in cursoEncontrado.Disciplinas)
          {
              if (disciplina != null)
              {
                  Console.WriteLine($"ID = {disciplina.Id}, Descrição = {disciplina.Descricao}");
              }
          }
      }
      else
      {
          Console.WriteLine("Curso não encontrado.");
      }
    }
    public static void RemoverCurso()
    {
        // Não pode ter nenhuma disciplina associada para poder remover o curso
        int id = LerId("Digite o ID do curso a ser removido: ");

        for (int i = 0; i < escola.Cursos.Length; i++)
        {
            if (escola.Cursos[i] != null && escola.Cursos[i].Id == id)
            {
                if (escola.Cursos[i].Disciplinas.All(d => d == null))
                {
                    escola.removerCurso(escola.Cursos[i]);
                    Console.WriteLine("Curso removido com sucesso.");
                }
                else
                {
                    Console.WriteLine("Não é possível remover o curso. Existem disciplinas associadas a ele.");
                }
                return;
            }

        }
        Console.WriteLine("Curso não encontrado.");
    }
    public static void AdicionarDisciplina()
    {
        int cursoId = LerId("Digite o ID do curso ao qual deseja adicionar a disciplina: ");

        Curso curso = new Curso { Id = cursoId };
        Curso? cursoEncontrado = escola.pesquisarCurso(curso);
        if (cursoEncontrado != null)
        {
            int disciplinaId = LerId("Digite o ID da disciplina: ");
            string descricao = LerTextoObrigatorio("Digite a descrição da disciplina: ");

            Disciplina disciplina = new Disciplina { Id = disciplinaId, Descricao = descricao };
            if (cursoEncontrado.adicionarDisciplina(disciplina))
            {
                Console.WriteLine("Disciplina adicionada com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível adicionar a disciplina. Verifique se o ID já existe ou se há espaço disponível.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado.");
        }
    }
    public static void PesquisarDisciplina()
    {
        // Mostrar os alunos associados à disciplina pesquisada
        int cursoId = LerId("Digite o ID do curso: ");

        Curso curso = new Curso { Id = cursoId };
        Curso? cursoEncontrado = escola.pesquisarCurso(curso);
        if (cursoEncontrado != null)
        {
            int disciplinaId = LerId("Digite o ID da disciplina a ser pesquisada: ");

            Disciplina disciplina = new Disciplina { Id = disciplinaId };
            Disciplina? disciplinaEncontrada = cursoEncontrado.pesquisarDisciplina(disciplina);
            if (disciplinaEncontrada != null)
            {
                Console.WriteLine($"Disciplina encontrada: ID = {disciplinaEncontrada.Id}, Descrição = {disciplinaEncontrada.Descricao}");
                Console.WriteLine("Alunos matriculados:");
                foreach (var aluno in disciplinaEncontrada.Alunos)
                {
                    if (aluno != null)
                    {
                        Console.WriteLine($"ID = {aluno.Id}, Nome = {aluno.Nome}");
                    }
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado.");
        }

    }
    public static void RemoverDisciplina()
    {
        //não pode ter nenhum aluno matriculado
        int cursoId = LerId("Digite o ID do curso: ");

        Curso curso = new Curso { Id = cursoId };
        Curso? cursoEncontrado = escola.pesquisarCurso(curso);
        if (cursoEncontrado != null)
        {
            int disciplinaId = LerId("Digite o ID da disciplina a ser removida: ");

            Disciplina disciplina = new Disciplina { Id = disciplinaId };
            if (cursoEncontrado.removerDisciplina(disciplina))
            {
                Console.WriteLine("Disciplina removida com sucesso!");
            }
            else
            {
                Console.WriteLine("Não foi possível remover a disciplina. Verifique se ela existe e se não há alunos matriculados.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado.");
        }
    }
    public static void MatricularAluno()
    {
        int cursoId = LerId("Digite o ID do curso: ");
        Curso curso = new Curso { Id = cursoId };
        Curso? cursoEncontrado = escola.pesquisarCurso(curso);
        if (cursoEncontrado != null){
            
             int disciplinaId = LerId("Digite o ID da disciplina: ");
            Disciplina disciplina = new Disciplina { Id = disciplinaId };
            Disciplina? disciplinaEncontrada = cursoEncontrado.pesquisarDisciplina(disciplina);
            if (disciplinaEncontrada != null)
            {
                int alunoId = LerId("Digite o ID do aluno: ");
                string nomeAluno = LerTextoObrigatorio("Digite o nome do aluno: ");

                Aluno aluno = new Aluno { Id = alunoId, Nome = nomeAluno };
                if (disciplinaEncontrada.matricularAluno(aluno))
                {
                    Console.WriteLine("Aluno matriculado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível matricular o aluno. Verifique se o ID já existe ou se há espaço disponível.");
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado.");
        }
    }
    public static void DesmatricularAluno()
    {
        int cursoId = LerId("Digite o ID do curso: ");
        Curso curso = new Curso { Id = cursoId };
        Curso? cursoEncontrado = escola.pesquisarCurso(curso);
        if (cursoEncontrado != null)
        {
            int disciplinaId = LerId("Digite o ID da disciplina: ");
            Disciplina disciplina = new Disciplina { Id = disciplinaId };
            Disciplina? disciplinaEncontrada = cursoEncontrado.pesquisarDisciplina(disciplina);
            if (disciplinaEncontrada != null)
            {
                int alunoId = LerId("Digite o ID do aluno a ser desmatriculado: ");
                Aluno aluno = new Aluno { Id = alunoId };
                if (disciplinaEncontrada.desmatricularAluno(aluno))
                {
                    Console.WriteLine("Aluno desmatriculado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Não foi possível desmatricular o aluno. Verifique se ele está matriculado na disciplina.");
                }
            }
            else
            {
                Console.WriteLine("Disciplina não encontrada.");
            }
        }
        else
        {
            Console.WriteLine("Curso não encontrado.");
        }
    }
    public static void PesquisarAluno()
    {
        // (informar seu nome e em quais disciplinas ele está matriculado
        string nomeAluno = LerTextoObrigatorio("Informe o nome do aluno a ser pesquisado: ");

        bool alunoEncontrado = false;
        Aluno? alunoPesquisado = null;
        Curso? cursoAluno = null;
        List<Disciplina> disciplinasEncontradas = new List<Disciplina>();
        
        foreach (var curso in escola.Cursos)
        {
            if (curso == null)
                continue;
            
                foreach (var disciplina in curso.Disciplinas)
                {
                    if (disciplina == null)
                        continue;
                        
                        foreach (var aluno in disciplina.Alunos)
                        {
                            if (aluno != null && aluno.Nome.Equals(nomeAluno, StringComparison.OrdinalIgnoreCase))
                            {
                                alunoEncontrado = true;
                                alunoPesquisado = aluno;
                                cursoAluno = curso;
                                disciplinasEncontradas.Add(disciplina);
                                break; // Encontrou o aluno, não precisa continuar procurando
                            }
                        }
                    }
                }
                    
        if (!alunoEncontrado)
        {
            Console.WriteLine("Aluno não encontrado.");
        }

        Console.WriteLine("\nAluno encontrado:");
        Console.WriteLine($"ID: {alunoPesquisado!.Id}");
        Console.WriteLine($"Nome: {alunoPesquisado.Nome}");

        Console.WriteLine($"\nCurso:");
        Console.WriteLine($"ID: {cursoAluno!.Id}");
        Console.WriteLine($"Descrição: {cursoAluno.Descricao}");

        Console.WriteLine("\nDisciplinas matriculadas:");

        foreach (var disciplina in disciplinasEncontradas)
        {
            Console.WriteLine(
                $"ID: {disciplina.Id} - {disciplina.Descricao}"
            );
        }
    }

    public static int ExibirMenu(){

        int opcao;
        Console.WriteLine("=== Menu da Escola ===");
        Console.WriteLine("0. Sair");
        Console.WriteLine("1. Adicionar Curso");
        Console.WriteLine("2. Pesquisar Curso");
        Console.WriteLine("3. Remover Curso");
        Console.WriteLine("4. Adicionar Disciplina");
        Console.WriteLine("5. Pesquisar Disciplina");
        Console.WriteLine("6. Remover Disciplina");
        Console.WriteLine("7. Matricular Aluno");
        Console.WriteLine("8. Desmatricular Aluno");
        Console.WriteLine("9. Pesquisar Aluno");
        Console.WriteLine("=======================");
        Console.Write("\nOpção: ");
        if(int.TryParse(Console.ReadLine(), out opcao) && opcao >= 0 && opcao <= 9)
        {
            return opcao;
        }
        else
        {
            Console.WriteLine("Opção inválida. Digite um número entre 0 e 9.");
            return -1;
        }
    }
    public static void Main(string[] args)
    {
        int op = -1;

        while (op != 0)
        {
            op = ExibirMenu();

            switch(op)
            {
                case 0:
                    Console.WriteLine("Saindo do programa...");
                    break;
                case 1:
                    AdicionarCurso();
                    break;
                case 2:
                    PesquisarCurso();
                    break;
                case 3:
                    RemoverCurso();
                    break;
                case 4:
                    AdicionarDisciplina();
                    break;
                case 5:
                    PesquisarDisciplina();
                    break;
                case 6:
                    RemoverDisciplina();
                    break;
                case 7:
                    MatricularAluno();
                    break;
                case 8:
                    DesmatricularAluno();
                    break;
                case 9:
                    PesquisarAluno();
                    break;
            }

            Console.WriteLine();
        }
    }
}
