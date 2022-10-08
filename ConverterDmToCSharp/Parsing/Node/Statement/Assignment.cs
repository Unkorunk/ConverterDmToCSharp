using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class Assignment : StatementNodeBase
{
  public Assignment(Path path, ExpressionNodeBase expression) : base(nameof(Assignment))
  {
    Path = path;
    Expression = expression;
  }

  public Path Path { get; }
  public ExpressionNodeBase Expression { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}