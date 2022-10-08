namespace ConverterDmToCSharp.Lexing;

public class Token
{
  public static readonly Token NewLine = new(nameof(NewLine));
  public static readonly Token Indent = new(nameof(Indent));
  public static readonly Token Dedent = new(nameof(Dedent));
  public static readonly Token Div = new(nameof(Div));
  public static readonly Token Dot = new(nameof(Dot));
  public static readonly Token LParen = new(nameof(LParen));
  public static readonly Token RParen = new(nameof(RParen));
  public static readonly Token As = new(nameof(As));
  public static readonly Token In = new(nameof(In));
  public static readonly Token Or = new(nameof(Or));
  public static readonly Token Comma = new(nameof(Comma));
  public static readonly Token LSquare = new(nameof(LSquare));
  public static readonly Token RSquare = new(nameof(RSquare));
  public static readonly Token LBrace = new(nameof(LBrace));
  public static readonly Token RBrace = new(nameof(RBrace));
  public static readonly Token For = new(nameof(For));
  public static readonly Token If = new(nameof(If));
  public static readonly Token Else = new(nameof(Else));
  public static readonly Token While = new(nameof(While));
  public static readonly Token Do = new(nameof(Do));
  private readonly string myName;

  protected Token(string name)
  {
    myName = name;
  }

  public override string ToString()
  {
    return myName;
  }
}

public class Identifier : Token
{
  public Identifier(string name) : base(nameof(Identifier))
  {
    Name = name;
  }

  public string Name { get; }

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