namespace ConverterDmToCSharp.Nodes;

public class ObjectNode : Node
{
  public PathNode Path { get; }
  public ScopeNode Scope { get; }

  public ObjectNode(PathNode path, ScopeNode scope) : base(nameof(ObjectNode))
  {
    Path = path;
    Scope = scope;
  }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}