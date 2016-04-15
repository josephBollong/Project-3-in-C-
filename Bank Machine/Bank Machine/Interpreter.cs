using Bank_Machine.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_Machine {
    class Interpreter {
        private Bash bash;
        private Engine engine;
        private List<String> commands;
        private String currentLocation = "START";
        private String contents;
        private Commands commandList;
        private Boolean hasCommand = true;


        public Interpreter(Bash _bash, Engine _engine) {
            bash = _bash;
            engine = _engine;
            commandList = new Commands(bash);


        }

        public void getCommands() { 
            commands = bash.readFromConsole();
        }

        public String checkForHelpOptions(List<String> _command, int idx) {
            String command = _command.ElementAt(idx);
            String position = "";

            switch (command) {
                case "LOGIN":
                    position = command;
                    break;
                case "LOGOUT":
                    position = command;
                    break;
                case "CREATEUSER":
                    position = command;
                    break;
                case "REMOVEUSER":
                    position = command;
                    break;
                case "CLEAR":
                    position = command;
                    break;
                case "EXIT":
                    position = command;
                    break;
                case "HOME":
                    position = command;
                    break;
                case "WITHDRAW":
                    position = command;
                    break;
                case "DEPOSIT":
                    position = command;
                    break;
                case "CREATEACCOUNT":
                    position = command;
                    break;
                case "SELECTACCOUNT":
                    position = command;
                    break;
                case "REMOVEACCOUNT":
                    position = command;
                    break;
                default:
                    position = "no such location known";
                    break;
            }
            return position;
        }

        public String checkForCommands(List<String> _command) {

            String output = "";

            String command = _command.ElementAt(0);

            if (checkForValidCommands(command) == false) {
                output = "This command cannot be used at this time.";
                return output;
            }

            switch (command) {

                case "HELP":

                    if (_command.Count() > 1) {
                        String tempCurrentPosition = checkForHelpOptions(_command, 1);
                        output = commandList.help(tempCurrentPosition);
                    } else {
                        output = commandList.help(currentLocation);
                    }
                    break;
                case "LOGIN":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.login(_command.ElementAt(1), _command.ElementAt(2));
                        currentLocation = "HOME";
                    }
                    break;
                case "LOGOUT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.logout();
                        currentLocation = "START";
                    }
                    break;
                case "CREATEUSER":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {

                        if (_command.Count() < 4) {
                            output = "The command " + "\"" + _command.ElementAt(0) + "\"" + " does not contain all required arguments.";
                            currentLocation = command;
                            break;
                        } else {
                            output = commandList.createUser(_command.ElementAt(1), _command.ElementAt(2), _command.ElementAt(3));
                            currentLocation = "HOME";
                            break;
                        }
                    }
                case "REMOVEUSER":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.removeUser(_command.ElementAt(1), _command.ElementAt(2));
                    }
                    break;
                case "HOME":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {

                    }
                    break;
                case "CREATEACCOUNT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        if (_command.Count() > 1) {
                            if (_command.Count() > 2) {
                                switch (_command.ElementAt(1)) {
                                    case "SAVINGS":
                                        try {
                                            output = commandList.createAccount(true, _command.ElementAt(2), Double.Parse(_command.ElementAt(3)), _command.ElementAt(4));
                                        } catch (FormatException e) {
                                            output = "The amount specified is invalid. Please enter a new amount";
                                        }
                                        break;
                                    case "AIRMILES":
                                        try {
                                            output = commandList.createAccount(false, _command.ElementAt(2), Double.Parse(_command.ElementAt(3)), _command.ElementAt(4));
                                        } catch (FormatException e) {
                                            output = "The amount specified is invalid. Please enter a new amount";
                                        }
                                        break;
                                }
                            } else {
                                output = "Command does not contain all required arguments." + "\n\r" + "Please define a name for the account, an amount to deposit, " + "\n\r" + "and a reason for the deposit.";
                            }

                        } else {
                            output = "Command does not contain all required arguments. " + "\n\r" + "Plese define what type of account.";
                        }

                    }
                    break;
                case "SELECTACCOUNT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        try {
                            output = commandList.selectAccount(Int32.Parse(_command.ElementAt(1)));
                        } catch (FormatException e) {
                            output = "The second command is not a valid number. Please enter a valid number.";
                        }
                    }
                    break;
                case "REMOVEACCOUNT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        try {
                            output = commandList.removeAccount(Int32.Parse(_command.ElementAt(1)));
                        } catch (FormatException e) {
                            output = "The second command is not a valid number. Please enter a valid number.";
                        }
                    }
                    break;
                case "DESELECTACCOUNT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.deselectAccount();
                    }
                    break;
                case "WITHDRAW":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        try {
                            commandList.transaction(false, Double.Parse(_command.ElementAt(1)), _command.ElementAt(2));
                        } catch (FormatException e) {
                            output = "The specified amount given is not a valid argument.";
                        }
                    }
                    break;
                case "DEPOSIT":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        try {
                            commandList.transaction(true, Double.Parse(_command.ElementAt(1)), _command.ElementAt(2));
                        } catch (FormatException e) {
                            output = "The specified amount given is not a valid argument.";
                        }
                    }
                    break;
                case "HISTORY":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.getHistory();
                    }
                    break;
                case "LISTACCOUNT":
                    output = commandList.listAccounts();
                    break;
                case "CLEAR":
                    Console.Clear();
                    break;
                case "UNDO":
                    commands.Clear();
                    commands.Add(currentLocation);
                    getResult();
                    break;
                case "EXIT":
                    System.Environment.Exit(1);
                    break;
                case "Q":
                    if (checkForValidCommands(command) == false) {
                        output = "This command cannot be used at this time.";
                        return output;
                    } else {
                        output = commandList.resume();
                    }
                    break;

                default:
                    output = "The command " + "\"" + _command.ElementAt(0) + "\"" + " is not recognized as an valid command.";
                    hasCommand = false;
                    break;
            }
            return output;
        }
        public Boolean checkForValidCommands(String command) {

            Boolean result = true;
            Regex r;
            Match m;

            switch (currentLocation) {
                case "LOGIN":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "LOGOUT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "CREATEUSER":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "REMOVEUSER":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "START":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGOUT|HOME|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "HOME":
                    r = new Regex("^CREATEUSER|REMOVEUSER|LOGIN|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "WITHDRAW":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "DEPOSIT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "SELECTACCOUNT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "CREATEACCOUNT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "REMOVEACCOUNT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
                case "DESELECTACCOUNT":
                    r = new Regex("^WITHDRAW|DEPOSIT|HISTORY|CREATEUSER|REMOVEUSER|CREATEACCOUNT|SELECTACCOUNT|REMOVEACCOUNT|LOGIN|LOGOUT|Q$");
                    m = r.Match(command);
                    if (m.Success) {
                        result = false;
                    } else {
                        result = true;
                    }
                    break;
            }
            return result;
        }

        public void getResult() {

            String _out = checkForCommands(commands);

            if (hasCommand = false) {
                return;
            } else {

                Boolean firstLine = true;
                String s;

                bash.writeToConsole(_out);

                commands.Clear();
            }
        }
    }
}
