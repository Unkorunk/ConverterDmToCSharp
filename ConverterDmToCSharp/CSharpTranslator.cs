using System.Text;
using ConverterDmToCSharp.Parsing;
using ConverterDmToCSharp.SemanticAnalysis;
using Object = ConverterDmToCSharp.Parsing.Node.Object;

namespace ConverterDmToCSharp;

public class CSharpTranslator : DefaultVisitor
{
  private readonly ConcreteSyntaxTree myCst;
  private readonly StringBuilder mySb;

  private Object? myParent;

  public CSharpTranslator(ConcreteSyntaxTree cst)
  {
    myCst = cst;
    mySb = new StringBuilder();
  }

  public string Translate()
  {
    Visit(myCst.AbstractSyntaxTree);
    return mySb.ToString();
  }

  public override void Visit(Object node)
  {
    var parent = myParent;

    mySb.Append("class ");

    mySb.Append(node.Path.Identifier.Identifier.Name);
    if (parent != null)
    {
      mySb.Append(" : ");
      mySb.Append(parent.Path.Identifier.Identifier.Name);
    }

    mySb.AppendLine();
    mySb.AppendLine("{");

    myParent = node;
    base.Visit(node);
    myParent = parent;

    mySb.AppendLine("}");
  }
}