namespace ConverterDmToCSharp;

public class Reader
{
  private readonly string myText;
  private int myIndex;

  public bool IsEof => myIndex >= myText.Length;

  public Reader(string text)
  {
    myText = text;
    myIndex = 0;
  }

  public char Peek() => myText[myIndex];
  public char Next() => myText[myIndex++];

  public bool TryPeek(out char ch)
  {
    if (IsEof)
    {
      ch = '\0';
      return false;
    }

    ch = Peek();
    return true;
  }

  public bool TryNext(out char ch)
  {
    var result = TryPeek(out ch);
    myIndex++;
    return result;
  }

  public void Back(int length)
  {
    if (myIndex - length < 0)
      throw new ArgumentException(null, nameof(length));

    myIndex -= length;
  }
}