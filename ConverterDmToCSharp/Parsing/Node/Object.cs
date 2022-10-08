namespace ConverterDmToCSharp.Parsing.Node;

public class Object : NodeBase
{
  public Object(Path path, ObjectScope scope) : base(nameof(Object))
  {
    Path = path;
    Scope = scope;
  }

  public Path Path { get; }
  public ObjectScope Scope { get; }

  public override void Visit(IVisitor visitor)
  {
    visitor.Visit(this);
  }
}