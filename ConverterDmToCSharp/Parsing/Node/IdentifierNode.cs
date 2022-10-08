using ConverterDmToCSharp.Lexing;

namespace ConverterDmToCSharp.Parsing.Node;

public class IdentifierNode : NodeBase
{
  public IdentifierNode(Identifier identifier) : base(nameof(IdentifierNode))
  {
    Identifier = identifier;
  }

  public Identifier Identifier { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}