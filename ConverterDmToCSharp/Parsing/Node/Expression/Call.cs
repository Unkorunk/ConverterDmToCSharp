namespace ConverterDmToCSharp.Parsing.Node.Expression;

public class Call : ExpressionNodeBase
{
  public Call(IdentifierNode name, IReadOnlyCollection<ExpressionNodeBase> arguments)
    : base(nameof(Call))
  {
    Name = name;
    Arguments = arguments;
  }

  public IdentifierNode Name { get; }
  public IReadOnlyCollection<ExpressionNodeBase> Arguments { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}