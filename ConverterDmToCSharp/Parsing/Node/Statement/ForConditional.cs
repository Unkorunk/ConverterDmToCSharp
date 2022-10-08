using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class ForConditional : StatementNodeBase
{
  public ForConditional(StatementNodeBase initStatement, ExpressionNodeBase condition, StatementNodeBase iterStatement,
    ProcedureScope scope)
    : base(nameof(ForConditional))
  {
    InitStatement = initStatement;
    Condition = condition;
    IterStatement = iterStatement;
    Scope = scope;
  }

  public StatementNodeBase InitStatement { get; }
  public ExpressionNodeBase Condition { get; }
  public StatementNodeBase IterStatement { get; }
  public ProcedureScope Scope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}