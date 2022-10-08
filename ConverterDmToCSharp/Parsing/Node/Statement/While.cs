using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class While : StatementNodeBase
{
  public While(bool isPostTest, ExpressionNodeBase condition, ProcedureScope scope) : base(nameof(While))
  {
    IsPostTest = isPostTest;
    Condition = condition;
    Scope = scope;
  }

  // is do while loop?
  public bool IsPostTest { get; }
  public ExpressionNodeBase Condition { get; }
  public ProcedureScope Scope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}