using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node.Statement;

public class ForList : StatementNodeBase
{
  public ForList(IdentifierNode name, TypeNode type, ExpressionNodeBase list, ProcedureScope scope)
    : base(nameof(ForList))
  {
    Name = name;
    Type = type;
    List = list;
    Scope = scope;
  }

  public IdentifierNode Name { get; }
  public TypeNode Type { get; }
  public ExpressionNodeBase List { get; }
  public ProcedureScope Scope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}