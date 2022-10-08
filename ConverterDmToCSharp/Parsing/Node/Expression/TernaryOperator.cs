namespace ConverterDmToCSharp.Parsing.Node.Expression;

public class TernaryOperator : ExpressionNodeBase
{
  public TernaryOperator(ExpressionNodeBase condition, ExpressionNodeBase trueExpression,
    ExpressionNodeBase falseExpression)
    : base(nameof(TernaryOperator))
  {
    Condition = condition;
    TrueExpression = trueExpression;
    FalseExpression = falseExpression;
  }

  public ExpressionNodeBase Condition { get; }
  public ExpressionNodeBase TrueExpression { get; }
  public ExpressionNodeBase FalseExpression { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}