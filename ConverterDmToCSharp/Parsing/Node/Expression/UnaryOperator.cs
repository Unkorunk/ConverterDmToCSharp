using ConverterDmToCSharp.Lexing;

namespace ConverterDmToCSharp.Parsing.Node.Expression;

public class UnaryOperator : ExpressionNodeBase
{
  public UnaryOperator(ExpressionNodeBase target, Token operation) : base(nameof(UnaryOperator))
  {
    Target = target;
    Operation = operation;
  }

  public ExpressionNodeBase Target { get; }
  public Token Operation { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}