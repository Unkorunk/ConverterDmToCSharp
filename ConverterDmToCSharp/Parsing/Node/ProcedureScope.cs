using ConverterDmToCSharp.Parsing.Node.Statement;

namespace ConverterDmToCSharp.Parsing.Node;

public class ProcedureScope : NodeBase
{
  public ProcedureScope(IReadOnlyCollection<StatementNodeBase> statements)
    : base(nameof(ProcedureScope))
  {
    Statements = statements;
  }

  public IReadOnlyCollection<StatementNodeBase> Statements { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}