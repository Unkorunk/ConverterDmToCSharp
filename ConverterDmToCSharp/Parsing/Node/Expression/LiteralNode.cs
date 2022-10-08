using ConverterDmToCSharp.Lexing;

namespace ConverterDmToCSharp.Parsing.Node.Expression;

public class LiteralNode : ExpressionNodeBase
{
  public LiteralNode(Literal literal) : base(nameof(LiteralNode))
  {
    Literal = literal;
  }

  public Literal Literal { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}