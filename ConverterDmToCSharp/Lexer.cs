using System.Text;

namespace ConverterDmToCSharp;

public class Lexer
{
  private readonly Reader myReader;
  private int myPrevIndentLevel;
  private bool isNewLine;
  private bool myIsFirstLastDedent;

  private readonly Queue<Token> myQueue = new();

  public Lexer(Reader reader)
  {
    myReader = reader;
    myPrevIndentLevel = 0;
    isNewLine = true;
    myIsFirstLastDedent = true;
  }

  public bool HasNext()
  {
    return myQueue.Count != 0 || !myReader.IsEof || myPrevIndentLevel != 0;
  }

  public Token Next()
  {
    if (myReader.IsEof && myPrevIndentLevel != 0)
    {
      if (myIsFirstLastDedent)
      {
        myIsFirstLastDedent = false;
        return Token.NewLine;
      }

      myPrevIndentLevel--;
      return Token.Dedent;
    }

    if (myQueue.Count != 0) return myQueue.Dequeue();

    if (!isNewLine && myReader.Peek() != ' ')
    {
      isNewLine = false;

      var ch = myReader.Next();
      if (ch == '/') return Token.Div;
      if (ch == '.') return Token.Dot;

      if (ch == '\n')
      {
        isNewLine = true;
        return Token.NewLine;
      }

      if (ch == '\r' && myReader.Peek() == '\n')
      {
        myReader.Next();
        isNewLine = true;
        return Token.NewLine;
      }

      myReader.Back(1);
      return GetIdentifier();
    }

    if (isNewLine)
    {
      var whitespaceCount = 0;
      var ch = myReader.Peek();
      while (ch == ' ' || ch == '\t')
      {
        if (ch == ' ') whitespaceCount++;
        else if (ch == '\t') whitespaceCount += 4;

        myReader.Next();
        ch = myReader.Peek();
      }

      if (whitespaceCount % 4 != 0)
        throw new InvalidOperationException();

      isNewLine = false;
      var currentIndentLevel = whitespaceCount / 4;

      Token token;
      if (currentIndentLevel > myPrevIndentLevel)
      {
        token = Token.Indent;
      }
      else if (currentIndentLevel < myPrevIndentLevel)
      {
        token = Token.Dedent;
      }
      else
      {
        return Next();
      }

      var count = Math.Abs(currentIndentLevel - myPrevIndentLevel);
      for (var i = 0; i < count; i++)
      {
        myQueue.Enqueue(token);
      }

      myPrevIndentLevel = currentIndentLevel;
      return myQueue.Dequeue();
    }

    throw new InvalidOperationException();
  }

  private Identifier GetIdentifier()
  {
    // [_A-Za-z] [_A-Za-z0-9]*

    var ch = myReader.Next();
    if (ch != '_' && !char.IsLetter(ch))
      throw new InvalidOperationException();

    var sb = new StringBuilder();
    sb.Append(ch);

    if (!myReader.TryPeek(out ch))
      return new Identifier(sb.ToString());

    while (ch == '_' || char.IsLetterOrDigit(ch))
    {
      sb.Append(ch);
      myReader.Next();

      if (!myReader.TryPeek(out ch))
        return new Identifier(sb.ToString());
    }

    return new Identifier(sb.ToString());
  }
}