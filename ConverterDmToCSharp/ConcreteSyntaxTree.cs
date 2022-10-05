namespace ConverterDmToCSharp;

public class ConcreteSyntaxTree
{
  public AbstractSyntaxTree AbstractSyntaxTree { get; }

  public ConcreteSyntaxTree(AbstractSyntaxTree ast)
  {
    AbstractSyntaxTree = ast;
  }
}