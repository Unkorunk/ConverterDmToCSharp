namespace ConverterDmToCSharp.Parsing.Node;

public class Path : NodeBase
{
  public Path(IdentifierNode identifier) : base(nameof(Path))
  {
    Identifier = identifier;
  }

  public IdentifierNode Identifier { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}