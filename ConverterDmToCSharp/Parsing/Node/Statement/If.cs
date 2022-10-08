using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class If : StatementNodeBase
{
  public If(ExpressionNodeBase expression, ProcedureScope ifScope, ProcedureScope? elseScope)
    : base(nameof(If))
  {
    Expression = expression;
    IfScope = ifScope;
    ElseScope = elseScope;
  }

  public ExpressionNodeBase Expression { get; }
  public ProcedureScope IfScope { get; }
  public ProcedureScope? ElseScope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}