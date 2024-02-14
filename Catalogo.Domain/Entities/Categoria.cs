using Catalogo.Domain.Validation;

namespace Catalogo.Domain.Entities;

//sealed:não pode ser herdada
public sealed class Categoria : Entity
{
    public Categoria(string nome, string imagemUrl)
    {
        ValidateDomain(nome, imagemUrl);
    }
    //popular tabela
    public Categoria(int id, string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(id < 0, "valor de id inválido");
        Id = id;
        ValidateDomain(nome, imagemUrl);
    }
    
    //private set: valores atribuidos apenas via construtor
    public string Nome { get; private set; }
    public string ImagemUrl { get; private set; }
    public ICollection<Produto> Produtos { get; private set; }

    private void ValidateDomain(string nome, string imagemUrl)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Nome inválido. O nome é obrigatório");
        DomainExceptionValidation.When(string.IsNullOrEmpty(imagemUrl), "Nome inválido. O nome é obrigatório");
        DomainExceptionValidation.When(nome.Length < 3, "Nome deve ter no mínimo 3 caracteres");
        DomainExceptionValidation.When(imagemUrl.Length < 5, "Nome deve ter no mínimo 5 caracteres");

        Nome = nome;
        ImagemUrl = imagemUrl;
    }
}