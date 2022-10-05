namespace ConverterDmToCSharp.Nodes;

public abstract class Node
{
  private readonly string myName;

  protected Node(string name)
  {
    myName = name;
  }

  public override string ToString()
  {
    return myName;
  }

  public abstract void Visit(IVisitor visitor);
}