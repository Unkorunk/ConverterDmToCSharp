namespace ConverterDmToCSharp.Nodes;

public abstract class DefaultVisitor : IVisitor
{
  public virtual void Visit(AbstractSyntaxTree ast)
  {
    Visit(ast.Root);
  }

  public virtual void Visit(ObjectNode node)
  {
    Visit(node.Scope);
  }

  public virtual void Visit(ScopeNode node)
  {
    foreach (var scopeItem in node.Nodes)
    {
      scopeItem.Visit(this);
    }
  }

  public void Visit(PathNode node)
  {
  }
}