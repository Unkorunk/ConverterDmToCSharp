using ConverterDmToCSharp.Parsing;

namespace ConverterDmToCSharp.SemanticAnalysis;

public class ConcreteSyntaxTree
{
  public ConcreteSyntaxTree(AbstractSyntaxTree ast)
  {
    AbstractSyntaxTree = ast;
  }

  public AbstractSyntaxTree AbstractSyntaxTree { get; }
}