using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pyratron.Frameworks.Commands.Parser;

namespace SmartArchive_Util {
    class Program {

        static void Main(string[] args) {
            var parser = CommandParser.CreateNew("--");
            parser.AddCommand(Command.Create("Hello").AddAlias("hello").SetDescription("Prints: 'Hello World!'")
                .SetAction((arguments, data) => {
                    Console.WriteLine("Hello World!");
                }));
            if (args.Length != 0) {
                parser.Parse(args[0]);
            }
        }
    }
}