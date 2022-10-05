namespace ConverterDmToCSharp;

public class Token
{
  private readonly string myName;

  protected Token(string name)
  {
    myName = name;
  }

  public static readonly Token NewLine = new(nameof(NewLine));
  public static readonly Token Indent = new(nameof(Indent));
  public static readonly Token Dedent = new(nameof(Dedent));
  public static readonly Token Div = new(nameof(Div));
  public static readonly Token Dot = new(nameof(Dot));

  public override string ToString()
  {
    return myName;
  }
}

public class Identifier : Token
{
  public string Name { get; }

  public Identifier(string name) : base(nameof(Identifier))
  {
    Name = name;
  }

  public override string ToString()
  {
    return base.ToString() + "(" + Name + ")";
  }
}

public class Literal : Token
{
  public Literal() : base(nameof(Literal))
  {
    throw new NotImplementedException();
  }
}