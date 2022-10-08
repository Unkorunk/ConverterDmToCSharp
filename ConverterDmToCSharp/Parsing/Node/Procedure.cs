namespace ConverterDmToCSharp.Parsing.Node;

public class Procedure : NodeBase
{
  public Procedure(IdentifierNode name, IReadOnlyCollection<ProcedureParameter> parameters, ProcedureScope scope)
    : base(nameof(Procedure))
  {
    Name = name;
    Parameters = parameters;
    Scope = scope;
  }

  public IdentifierNode Name { get; }
  public IReadOnlyCollection<ProcedureParameter> Parameters { get; }
  public ProcedureScope Scope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}