namespace ConverterDmToCSharp.Parsing.Node;

public interface INode
{
  public void Visit(IVisitor visitor);
}