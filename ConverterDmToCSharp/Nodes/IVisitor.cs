namespace ConverterDmToCSharp.Nodes;

public interface IVisitor
{
  public void Visit(AbstractSyntaxTree ast);
  public void Visit(ObjectNode node);
  public void Visit(ScopeNode node);
  public void Visit(PathNode node);
}