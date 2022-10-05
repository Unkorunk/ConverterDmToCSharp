using ConverterDmToCSharp.Nodes;

namespace ConverterDmToCSharp;

public class Parser
{
  private readonly Lexer myLexer;
  private Token? myCurrentToken;
  private bool isEof;

  public Parser(Lexer lexer)
  {
    myLexer = lexer;
    Next();
  }

  private void Next()
  {
    if (!myLexer.HasNext())
    {
      myCurrentToken = null;
      isEof = true;
    }
    else
    {
      myCurrentToken = myLexer.Next();
      isEof = false;
    }
  }

  private bool Accept(Token token)
  {
    if (!isEof && token == myCurrentToken)
    {
      Next();
      return true;
    }

    return false;
  }

  private bool Accept<T>(out T? result) where T : Token
  {
    if (!isEof && myCurrentToken is T temp)
    {
      result = temp;
      Next();
      return true;
    }

    result = null;
    return false;
  }

  private void Expect(Token token)
  {
    if (!Accept(token))
      throw new InvalidOperationException();
  }

  private void Expect<T>(out T result) where T : Token
  {
    if (!Accept(out result!))
      throw new InvalidOperationException();
  }

  private bool AcceptScopeItem(out Node? node)
  {
    while (Accept(Token.NewLine))
    {
    }

    if (Accept<Identifier>(out var identifier))
    {
      Expect(Token.NewLine);
      var scope = ScopeNode.Empty;
      if (Accept(Token.Indent))
      {
        scope = GetScope();
        Expect(Token.Dedent);
      }

      var pathNode = new PathNode(identifier!);
      node = new ObjectNode(pathNode, scope);
      return true;
    }

    node = null;
    return false;
  }

  private ScopeNode GetScope()
  {
    if (!AcceptScopeItem(out var node))
      throw new InvalidOperationException();

    var nodes = new List<Node> {node!};
    while (AcceptScopeItem(out node))
      nodes.Add(node!);

    return new ScopeNode(nodes);
  }

  public AbstractSyntaxTree Parse()
  {
    var nodes = new List<Node>();
    while (AcceptScopeItem(out var node))
      nodes.Add(node!);

    return new AbstractSyntaxTree(new ScopeNode(nodes));
  }
}