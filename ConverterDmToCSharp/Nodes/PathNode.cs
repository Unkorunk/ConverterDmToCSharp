namespace ConverterDmToCSharp.Nodes;

public class PathNode : Node
{
  public Identifier Identifier { get; }

  public PathNode(Identifier identifier) : base(nameof(PathNode))
  {
    Identifier = identifier;
  }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}