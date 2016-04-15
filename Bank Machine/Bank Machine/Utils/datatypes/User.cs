using Bank_Machine.Utils.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.datatypes {
    class User {
        private Int64 userId;
        private String userName;
        private String password;
        private String hash;
        private String salt;
        private List<Account> listOfAccounts;
        private String screenName;
        private SecurityUtils security;
	private Account account;



        public User(String _userName, String _password, String _screenName) {
            security = new SecurityUtils();
            userId = DataManagement.user;
            DataManagement.user++;
            DataManagement.saveNums();
            userName = _userName;
            List<String> keys = security.getHashedPassword(_password);
            hash = keys.ElementAt(0);
            salt = keys.ElementAt(1);
            screenName = _screenName;
            listOfAccounts = new List<Account>();

        }

        public Int64 getUserId() {
            return userId;
        }

        public String getUserName() {
            return userName;
        }

        public String getHash() {
            return hash;
        }

        public String getSalt() {
            return salt;
        }

        public String getScreenName() {
            return screenName;
        }
        public SecurityUtils getSecurity() {
            return security;
        }
        public List<Account> getAccountList() {
            return listOfAccounts;
        }
        public String addSavingsAccount(String _name, Double _amount, String _comment) {
            SavingsAccount save = new SavingsAccount(_name, _amount, userId, _comment);
            listOfAccounts.add(save);
            String str = "Created new Savings Account" + "\"" + _name + "\".";
            return str;
        }
        public String addAirMilesSavingsAccount(String _name, Double _amount, String _comment) {
            AirMilesSavingsAccount air = new AirMilesSavingsAccount(_name, _amount, userId, _comment);
            listOfAccounts.add(air);
            String str = "Created new Air Miles Savings Account" + "\"" + _name + "\".";
            return str;
        }
        public String SelectAccount(int idx) {
            int x = idx - 1;
            account = listOfAccounts.get(x);
            String str = "Selected Account " + account.toString();
            return str;
        }
        public String removeAccount(int x) {

            listOfAccounts.remove(x + 1);
            String str = "Removed Account " + account.toString();
            return str;
        }
        public Account getAccount() {
            return account;
        }

        private String accountToString(Account _account) {
            String _index = String.valueOf(listOfAccounts.indexOf(account) + 1);
            return _index + ". " + _account.toString();
        }

        public String listAccounts() {
            String str = "";
            Iterator<Account> itr = listOfAccounts.iterator();
            int x = 1;
            while (itr.hasNext()) {
                account = itr.next();
                str = str + "\n\r" + x + ". " + account.toString();
                x++;
            }
            // convert list to stream than run the accountToString method on every element on the list than build a new array 
            // based on the results of the changes made to the previous list
            // Intercalate works by appending an object at the end of every element in the list
            // ex. List<String> {a, b, c, d, e} + String "-" = String "a-b-c-d-e"
            //str = Intercalate.intercalate(listOfAccounts.stream().map(this::accountToString).toArray(String[]::new),"\n\r");

            if (str.length() == 0) {
                str = "You have no accounts to show.";
            }
            return str;
        }
    }
}
