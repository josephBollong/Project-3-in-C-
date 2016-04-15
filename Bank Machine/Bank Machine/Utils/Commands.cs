using Bank_Machine.Utils.commands;
using Bank_Machine.Utils.datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils {
    class Commands {
        private CreateUser mkusr;
        private User user = null;
        private Account account = null;
        private Bash bash;
        private DataManagement manage;
        private LoginUser _login;

        public Commands(Bash _bash) {
            bash = _bash;
            manage = new DataManagement();
        }

        public String help(String location) {

            String h = "";
            

            switch (location) {

                case "LOGIN":
                    h = HelpGlossary.LOGIN_HELP;
                    break;
                case "CREATEUSER":
                    h = HelpGlossary.CREATE_USER_HELP;
                    break;
                case "START":
                    h = HelpGlossary.START_PAGE_HELP;
                    break;
            }

            return h;
        }
        public String login(String _user, String _pass) {
            String str = "";
            if (user == null) {
                _login = new LoginUser(_user, _pass, manage);
                if (_login._usernameValid) {
                    if (_login._passwordValid) {
                        user = _login.getUser();
                        str = "Logged in Sucessfully.";
                    } else {
                        str = "Password not valid.";
                    }
                } else {
                    str = "Username not valid";
                }
            } else {
                str = "Command not valid at this time. You are already logged in.";
            }
            return str;
        }
        public String logout() {

            String str;
            if (!(user == null)) {
                user = null;
                str = "Logged out sucessfully.";
            } else {
                str = "Command not valid at this time. You are already logged out";
            }

            return str;
        }
        public String createUser(String _user, String _pass, String _name) {
            String str = "";
            if (user == null) {
                mkusr = new CreateUser(_user, _pass, _name);
                str = mkusr.getOutput();
                user = mkusr.getUser();
                manage.setUserAccount(user);
                DataManagement.saveData();
            } else {
                str = "Command not valid at this time. Log out first to create a new user.";
            }
            return str;
        }
        public String removeUser(String _user, String _password) {
            String str = "";
            if (user == null) {
                str = login(_user, _password);
                if (!(user == null)) {
                    Int64 id = user.getUserId();
                    str = "User sucessfully removed";
                    DataManagement.deleteData(id);
                } else {
                    return str;
                }
            } else {
                str = "Command not valid at this time. Log out first to remove a user.";
            }
            return str;
        }

        //public String resume() {
        //    return currentOutput;
        //}
        public String transaction(Boolean transactionType, Double amount, String comment) {
            String str = "";
            if (!(account == null)) {
                if (transactionType == true) {
                    str = account.deposit(amount, comment);
                } else if (transactionType == false) {
                    str = account.withdraw(amount, comment);
                }
            } else {
                str = "Command not valid at this time. First select an account to perform a transaction with.";
            }
            return str;
        }
        public String selectAccount(int x) {
            String str = user.SelectAccount(x);
            account = user.getAccount();
            return str;
        }
        public String deselectAccount() {
            String str = "";
            if (!(account == null)) {
                account = null;
                str = "account has been deselected.";
            } else {
                str = "Command not valid at this time. An account is not currently selected.";
            }
            return str;
        }
        public String createAccount(Boolean accountType, String _name, Double _amount, String _comment) {
            String str = "";
            if (account == null) {
                if (accountType == true) {
                    user.addSavingsAccount(_name, _amount, _comment);
                    str = "Created a Savings Account.";
                } else if (accountType == false) {
                    user.addAirMilesSavingsAccount(_name, _amount, _comment);
                    str = "Created an Air Miles Savings Account.";
                } else {
                    str = "not a valid account.";
                }
            } else {
                str = "Command not valid at this time. First deselect acount to create a new one.";
            }
            return str;
        }
        public String removeAccount(int x) {
            String str = "";
            if (account == null) {
                str = user.SelectAccount(x);
                str = user.removeAccount(x);
            } else {
                str = "Command not valid at this time. First deselect account to remove one.";
            }
            return str;
        }
        public String listAccounts() {
            return user.listAccounts();
        }
        public String getHistory() {
            String str = "";
            if (!(account == null)) {
                str = account.getHistory();
            } else {
                str = "Command is not valid at this time. Account must be selected to display the transaction history.";
            }
            return str;
        }
    }
}
