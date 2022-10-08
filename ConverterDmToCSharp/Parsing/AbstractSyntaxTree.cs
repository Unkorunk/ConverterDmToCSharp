using ConverterDmToCSharp.Parsing.Node;

namespace ConverterDmToCSharp.Parsing;

public class AbstractSyntaxTree
{
  public AbstractSyntaxTree(ObjectScope root)
  {
    Root = root;
  }

  public ObjectScope Root { get; }
}