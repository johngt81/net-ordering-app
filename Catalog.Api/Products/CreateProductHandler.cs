using BuildingBlocks;
using Marten;

public record CreateProductCommand(string Name, decimal Price) : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler(IDocumentSession session) 
    :  ICommandHandler<CreateProductCommand, CreateProductResult>
{
  public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken)
  {
    var product = new Product{
        Name =  command.Name,
        Price = command.Price
    };
    session.Store(product);
    await session.SaveChangesAsync(cancellationToken);
    return new CreateProductResult(product.Id);
  }
}