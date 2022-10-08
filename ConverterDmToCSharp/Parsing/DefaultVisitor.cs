using ConverterDmToCSharp.Parsing.Node;
using ConverterDmToCSharp.Parsing.Node.Expression;
using ConverterDmToCSharp.Parsing.Node.Statement;
using Object = ConverterDmToCSharp.Parsing.Node.Object;
using Path = ConverterDmToCSharp.Parsing.Node.Path;

namespace ConverterDmToCSharp.Parsing;

public abstract class DefaultVisitor : IVisitor
{
  public virtual void Visit(AbstractSyntaxTree ast)
  {
    Visit(ast.Root);
  }

  public virtual void Visit(Object node)
  {
    Visit(node.Path);
    Visit(node.Scope);
  }

  public virtual void Visit(ObjectScope node)
  {
    foreach (var scopeItem in node.Nodes) scopeItem.Visit(this);
  }

  public virtual void Visit(Path node)
  {
    node.Identifier.Visit(this);
  }

  public virtual void Visit(Procedure node)
  {
    node.Name.Visit(this);
    foreach (var parameter in node.Parameters) parameter.Visit(this);
    node.Scope.Visit(this);
  }

  public virtual void Visit(ProcedureParameter node)
  {
    Visit(node.Name);
    Visit(node.Type);
    node.Filter?.Visit(this);
  }

  public virtual void Visit(IdentifierNode node)
  {
  }

  public virtual void Visit(ProcedureScope node)
  {
    foreach (var statement in node.Statements)
      statement.Visit(this);
  }

  public virtual void Visit(Assignment node)
  {
    Visit(node.Path);
    node.Expression.Visit(this);
  }

  public void Visit(Return node)
  {
    node.Expression?.Visit(this);
  }

  public void Visit(If node)
  {
    node.Expression.Visit(this);
    Visit(node.IfScope);
    if (node.ElseScope != null)
      Visit(node.ElseScope);
  }

  public void Visit(TernaryOperator node)
  {
    node.Condition.Visit(this);
    node.TrueExpression.Visit(this);
    node.FalseExpression.Visit(this);
  }

  public void Visit(ForList node)
  {
    Visit(node.Name);
    Visit(node.Type);
    node.List.Visit(this);
    Visit(node.Scope);
  }

  public void Visit(TypeNode node)
  {
    foreach (var type in node.Types)
      Visit(type);
  }

  public void Visit(ForConditional node)
  {
    node.InitStatement.Visit(this);
    node.Condition.Visit(this);
    node.IterStatement.Visit(this);
    Visit(node.Scope);
  }

  public void Visit(While node)
  {
    if (node.IsPostTest)
    {
      Visit(node.Scope);
      node.Condition.Visit(this);
    }
    else
    {
      node.Condition.Visit(this);
      Visit(node.Scope);
    }
  }

  public void Visit(BinaryOperator node)
  {
    node.Left.Visit(this);
    node.Right.Visit(this);
  }

  public void Visit(Call node)
  {
    Visit(node.Name);
    foreach (var argument in node.Arguments)
      argument.Visit(this);
  }

  public void Visit(LiteralNode node)
  {
  }

  public void Visit(UnaryOperator node)
  {
    node.Target.Visit(this);
  }
}