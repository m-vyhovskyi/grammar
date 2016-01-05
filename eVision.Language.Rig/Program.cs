using System;
using System.Diagnostics;
using System.IO;

using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

using eVision.Language.Grammar;
using eVision.Language.Rig.Grammar;

namespace eVision.Language.Rig
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader fileStream = new StreamReader(args[0]))
            {
                AntlrInputStream inputStream = new AntlrInputStream(fileStream);

                DomainLexer lexer = new DomainLexer(inputStream);
                CommonTokenStream commonTokenStream = new CommonTokenStream(lexer);
                DomainParser parser = new DomainParser(commonTokenStream);

                //parser.RemoveErrorListeners();
                //parser.AddErrorListener(new ErrorListener()); // add ours
                //var sw = new Stopwatch();
                //sw.Start();
                var tree = parser.prog();
                //DomainVisitor visitor = new DomainVisitor();
                //visitor.Visit(tree);
                //sw.Stop();
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //Console.WriteLine(res);
                ParseTreeWalker walker = new ParseTreeWalker();
                DomainListener listener = new DomainListener(parser);
                walker.Walk(listener,tree);
            }
        }
    }
}