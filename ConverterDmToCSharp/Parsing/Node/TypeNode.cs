namespace ConverterDmToCSharp.Parsing.Node;

public class TypeNode : NodeBase
{
  public TypeNode(IReadOnlyCollection<IdentifierNode> types) : base(nameof(TypeNode))
  {
    Types = types;
  }

  public IReadOnlyCollection<IdentifierNode> Types { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}