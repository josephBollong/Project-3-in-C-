using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine {
    public class Bash {
        

        public void writeToConsole(String output) {
            Console.WriteLine(output);
        }
        public List<String> readFromConsole() {
            String input = Console.ReadLine();
            List<String> command = input.Split(null).ToList();
            return command;
        }
     }
}
