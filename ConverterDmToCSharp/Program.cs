namespace ConverterDmToCSharp
{
  internal static class ConverterDmToCSharp
  {
    public static void Main(string[] args)
    {
      var text = File.ReadAllText("input.dm");
      var reader = new Reader(text);

      var lexer = new Lexer(reader);
      // var lst = new List<Token>();
      // while (lexer.HasNext()) lst.Add(lexer.Next());

      var parser = new Parser(lexer);
      var ast = parser.Parse();

      var semanticAnalyzer = new SemanticAnalyzer();
      var cst = semanticAnalyzer.Analyze(ast);

      var translator = new CSharpTranslator(cst);
      var result = translator.Translate();

      File.WriteAllText("output.cs", result);
    }
  }
}