using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine {
    class MainApp {
        static void Main(string[] args) {

            Bash bash = new Bash();
            Engine engine = new Engine();
            Interpreter interpreter = new Interpreter(bash, engine);
        }
    }
}
