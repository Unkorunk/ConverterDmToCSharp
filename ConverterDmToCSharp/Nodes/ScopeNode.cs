using System.Collections.Immutable;

namespace ConverterDmToCSharp.Nodes;

public class ScopeNode : Node
{
  public static readonly ScopeNode Empty = new(ImmutableArray<Node>.Empty);

  public IReadOnlyCollection<Node> Nodes { get; }

  public ScopeNode(IReadOnlyCollection<Node> nodes) : base(nameof(ScopeNode))
  {
    Nodes = nodes;
  }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}