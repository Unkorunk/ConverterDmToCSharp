using ConverterDmToCSharp.Parsing.Node.Expression;

namespace ConverterDmToCSharp.Parsing.Node;

public class ProcedureParameter : NodeBase
{
  public ProcedureParameter(IdentifierNode name, TypeNode type, ExpressionNodeBase? filter)
    : base(nameof(ProcedureParameter))
  {
    Name = name;
    Type = type;
    Filter = filter;
  }

  public IdentifierNode Name { get; }
  public TypeNode Type { get; }
  public ExpressionNodeBase? Filter { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}