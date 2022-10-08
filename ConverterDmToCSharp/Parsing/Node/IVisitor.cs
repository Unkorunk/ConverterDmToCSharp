using ConverterDmToCSharp.Parsing.Node.Expression;
using ConverterDmToCSharp.Parsing.Node.Statement;

namespace ConverterDmToCSharp.Parsing.Node;

public interface IVisitor
{
  public void Visit(AbstractSyntaxTree ast);
  public void Visit(Object node);
  public void Visit(ObjectScope node);
  public void Visit(Path node);
  public void Visit(Procedure node);
  public void Visit(ProcedureParameter node);
  public void Visit(IdentifierNode node);
  public void Visit(ProcedureScope node);
  public void Visit(Assignment node);
  public void Visit(Return node);
  public void Visit(If node);
  public void Visit(TernaryOperator node);
  public void Visit(ForList node);
  public void Visit(TypeNode node);
  public void Visit(ForConditional node);
  public void Visit(While node);
  public void Visit(BinaryOperator node);
  public void Visit(Call node);
  public void Visit(LiteralNode node);
  public void Visit(UnaryOperator node);
}