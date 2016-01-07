using System;
using System.IO;

using Antlr4.Runtime;

using eVision.Language.Definitions;
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
                var tree = parser.domain();
                DomainVisitor visitor = new DomainVisitor();
                DomainDefinition res = (DomainDefinition)visitor.Visit(tree);
                //sw.Stop();
                //Console.WriteLine(sw.ElapsedMilliseconds);
                //Console.WriteLine(res);
                //ParseTreeWalker walker = new ParseTreeWalker();
                //walker.Walk(new DomainListener(parser), tree);
                Console.WriteLine(res);
            }
        }
    }
}