using System.Collections.Immutable;

namespace ConverterDmToCSharp.Parsing.Node;

public class ObjectScope : NodeBase
{
  public static readonly ObjectScope Empty = new(ImmutableArray<NodeBase>.Empty);

  public ObjectScope(IReadOnlyCollection<NodeBase> nodes) : base(nameof(ObjectScope))
  {
    Nodes = nodes;
  }

  public IReadOnlyCollection<NodeBase> Nodes { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}