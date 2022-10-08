namespace ConverterDmToCSharp.Parsing.Node;

public abstract class NodeBase : INode
{
  private readonly string myName;

  protected NodeBase(string name)
  {
    myName = name;
  }

  public abstract void Visit(IVisitor visitor);

  public override string ToString()
  {
    return myName;
  }
}