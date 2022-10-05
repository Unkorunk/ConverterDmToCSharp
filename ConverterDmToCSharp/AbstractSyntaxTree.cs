using ConverterDmToCSharp.Nodes;

namespace ConverterDmToCSharp;

public class AbstractSyntaxTree
{
  public ScopeNode Root { get; }

  public AbstractSyntaxTree(ScopeNode root)
  {
    Root = root;
  }
}