using System;
using System.IO;

using Antlr4.Runtime;

using eVision.Language.Definitions;
using eVision.Language.Grammar;
using Antlr4.Runtime.Tree;

namespace eVision.Language.Rig
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileStream = new StreamReader(args[0]))
            {
                AntlrInputStream inputStream = new AntlrInputStream(fileStream);

                var lexer = new DomainLexer(inputStream);
                var commonTokenStream = new CommonTokenStream(lexer);
                DomainParser parser = new DomainParser(commonTokenStream);

                //parser.RemoveErrorListeners();
                //parser.AddErrorListener(new ErrorListener()); // add ours
                //var sw = new Stopwatch();
                //sw.Start();
                var tree = parser.domain();
                //sw.Stop();
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //Console.WriteLine(res);
                ParseTreeWalker walker = new ParseTreeWalker();
                var listener = new DomainListener();
                walker.Walk(listener, tree);
            }
        }
    }
}