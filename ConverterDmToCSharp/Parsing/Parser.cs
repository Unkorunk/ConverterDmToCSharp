using ConverterDmToCSharp.Lexing;
using ConverterDmToCSharp.Parsing.Node;
using ConverterDmToCSharp.Parsing.Node.Expression;
using Object = ConverterDmToCSharp.Parsing.Node.Object;
using Path = ConverterDmToCSharp.Parsing.Node.Path;

namespace ConverterDmToCSharp.Parsing;

public class Parser
{
  private readonly Lexer myLexer;
  private bool isEof;
  private Token? myCurrentToken;

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

  private ExpressionNodeBase GetExpressions()
  {
    throw new NotImplementedException();
  }

  private IReadOnlyCollection<ProcedureParameter> GetParameters()
  {
    var parameters = new List<ProcedureParameter>();
    var parameter = GetProcedureParameter();
    if (parameter != null)
    {
      parameters.Add(parameter);
      if (Accept(Token.Comma))
      {
        parameter = GetProcedureParameter();
        if (parameter == null)
          throw new InvalidOperationException();
      }
    }

    return parameters;
  }

  private ProcedureScope GetProcedureScope()
  {
    throw new NotImplementedException();
  }

  private ProcedureParameter? GetProcedureParameter()
  {
    if (!Accept<Identifier>(out var paramName))
      return null;

    Expect(Token.As);
    Expect<Identifier>(out var typeName);
    var typeNameIdentNode = new IdentifierNode(typeName);

    var paramTypes = new List<IdentifierNode> { typeNameIdentNode };
    while (Accept(Token.Or))
    {
      Expect<Identifier>(out typeName);
      typeNameIdentNode = new IdentifierNode(typeName);
      paramTypes.Add(typeNameIdentNode);
    }

    ExpressionNodeBase? filter = null;
    if (Accept(Token.In)) filter = GetExpressions();

    var paramIdentNode = new IdentifierNode(paramName!);
    var paramTypeNode = new TypeNode(paramTypes);
    var param = new ProcedureParameter(paramIdentNode, paramTypeNode, filter);

    return param;
  }

  private bool AcceptScopeItem(out NodeBase? node)
  {
    while (Accept(Token.NewLine))
    {
    }

    if (Accept<Identifier>(out var identifier))
    {
      if (Accept(Token.LParen))
      {
        var parameters = GetParameters();
        Expect(Token.RParen);

        var scopeNode = GetProcedureScope();
        var identifierNode = new IdentifierNode(identifier!);
        var procedureNode = new Procedure(identifierNode, parameters, scopeNode);

        node = procedureNode;
      }
      else
      {
        Expect(Token.NewLine);
        var scope = ObjectScope.Empty;
        if (Accept(Token.Indent))
        {
          scope = GetScope();
          Expect(Token.Dedent);
        }

        var identifierNode = new IdentifierNode(identifier!);
        var pathNode = new Path(identifierNode);

        node = new Object(pathNode, scope);
      }

      return true;
    }

    node = null;
    return false;
  }

  private ObjectScope GetScope()
  {
    if (!AcceptScopeItem(out var node))
      throw new InvalidOperationException();

    var nodes = new List<NodeBase> { node! };
    while (AcceptScopeItem(out node))
      nodes.Add(node!);

    return new ObjectScope(nodes);
  }

  public AbstractSyntaxTree Parse()
  {
    var nodes = new List<NodeBase>();
    while (AcceptScopeItem(out var node))
      nodes.Add(node!);

    return new AbstractSyntaxTree(new ObjectScope(nodes));
  }
}