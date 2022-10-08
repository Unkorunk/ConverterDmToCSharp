using ConverterDmToCSharp.Parsing.Node;
using ConverterDmToCSharp.Parsing.Node.Expression;
using ConverterDmToCSharp.Parsing.Node.Statement;
using Object = ConverterDmToCSharp.Parsing.Node.Object;
using Path = ConverterDmToCSharp.Parsing.Node.Path;

namespace ConverterDmToCSharp.Parsing;

public class DebugVisitor : IVisitor
{
  private readonly TextWriter myWriter;
  private int myIndentLevel;

  public DebugVisitor(TextWriter writer)
  {
    myWriter = writer;
  }

  public int IndentSize { get; set; } = 4;

  public void Visit(AbstractSyntaxTree ast)
  {
    Dedent();
    Visit(ast.Root);
  }

  public void Visit(Object node)
  {
    PrintIndentLevel();
    Visit(node.Path);
    myWriter.WriteLine();
    Visit(node.Scope);
  }

  public void Visit(ObjectScope node)
  {
    Indent();
    foreach (var scopeItem in node.Nodes)
      scopeItem.Visit(this);
    Dedent();
  }

  public void Visit(Path node)
  {
    Visit(node.Identifier);
  }

  public void Visit(Procedure node)
  {
    PrintIndentLevel();

    Visit(node.Name);
    myWriter.Write('(');
    if (node.Parameters.Count != 0)
    {
      Visit(node.Parameters.Single());
      foreach (var parameter in node.Parameters.Skip(1))
      {
        myWriter.Write(", ");
        Visit(parameter);
      }
    }

    myWriter.Write(')');

    Visit(node.Scope);
  }

  public void Visit(ProcedureParameter node)
  {
    Visit(node.Name);
    myWriter.Write(" as ");
    Visit(node.Type);

    node.Filter?.Visit(this);
  }

  public void Visit(IdentifierNode node)
  {
    myWriter.Write(node.Identifier.Name);
  }

  public void Visit(ProcedureScope node)
  {
    foreach (var statement in node.Statements)
      statement.Visit(this);
  }

  public void Visit(Assignment node)
  {
    Visit(node.Path);
    myWriter.Write(" = ");
    node.Expression.Visit(this);
  }

  public void Visit(Return node)
  {
    myWriter.Write("return ");
    node.Expression?.Visit(this);
  }

  public void Visit(If node)
  {
    myWriter.Write("if (");
    node.Expression.Visit(this);
    myWriter.WriteLine(')');
    Visit(node.IfScope);

    if (node.ElseScope != null)
    {
      myWriter.WriteLine("else");
      Visit(node.ElseScope);
    }
  }

  public void Visit(TernaryOperator node)
  {
    node.Condition.Visit(this);
    myWriter.Write(" ? ");
    node.TrueExpression.Visit(this);
    myWriter.Write(" : ");
    node.FalseExpression.Visit(this);
  }

  public void Visit(ForList node)
  {
    myWriter.Write("for (");
    Visit(node.Name);
    myWriter.Write(" as ");
    Visit(node.Type);
    myWriter.Write(" in ");
    node.List.Visit(this);
    myWriter.WriteLine(')');
    Visit(node.Scope);
  }

  public void Visit(TypeNode node)
  {
    Visit(node.Types.Single());
    foreach (var identifierNode in node.Types.Skip(1))
    {
      myWriter.Write('|');
      Visit(identifierNode);
    }
  }

  public void Visit(ForConditional node)
  {
    myWriter.Write("for (");
    node.InitStatement.Visit(this);
    myWriter.Write("; ");
    node.Condition.Visit(this);
    myWriter.Write("; ");
    node.IterStatement.Visit(this);
    myWriter.WriteLine(')');
    Visit(node.Scope);
  }

  public void Visit(While node)
  {
    if (node.IsPostTest)
    {
      myWriter.WriteLine("do");
      Visit(node.Scope);
      PrintIndentLevel();
      myWriter.Write("while (");
      node.Condition.Visit(this);
      myWriter.Write(')');
    }
    else
    {
      myWriter.Write("while (");
      node.Condition.Visit(this);
      myWriter.WriteLine(')');
      Visit(node.Scope);
    }
  }

  public void Visit(BinaryOperator node)
  {
    myWriter.Write(node.Operation);
    myWriter.Write('(');
    node.Left.Visit(this);
    myWriter.Write(", ");
    node.Right.Visit(this);
    myWriter.Write(')');
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
    myWriter.Write(node.Operation);
    myWriter.Write('(');
    node.Target.Visit(this);
    myWriter.Write(')');
  }

  private void PrintIndentLevel()
  {
    myWriter.Write(new string(' ', myIndentLevel * IndentSize));
  }

  private void Indent()
  {
    myIndentLevel++;
  }

  private void Dedent()
  {
    myIndentLevel--;
  }
}