using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class Return : StatementNodeBase
{
  public Return(ExpressionNodeBase expression) : base(nameof(Return))
  {
    Expression = expression;
  }

  public ExpressionNodeBase? Expression { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}