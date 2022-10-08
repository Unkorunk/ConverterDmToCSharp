using ConverterDmToCSharp.Lexing;

namespace ConverterDmToCSharp.Parsing.Node.Expression;

public class BinaryOperator : ExpressionNodeBase
{
  public BinaryOperator(ExpressionNodeBase left, ExpressionNodeBase right, Token operation)
    : base(nameof(BinaryOperator))
  {
    Left = left;
    Right = right;
    Operation = operation;
  }

  public ExpressionNodeBase Left { get; }
  public ExpressionNodeBase Right { get; }
  public Token Operation { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}