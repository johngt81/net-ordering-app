using MediatR;

public record CreateProductCommand(string Name, decimal Price) : IRequest<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
{
  public Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
  {
    throw new NotImplementedException();
  }
}