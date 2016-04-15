using Bank_Machine.Utils.datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.commands {
    class LoginUser {
        private DataManagement data;
        private Dictionary<String, Int64> table;
        private User user = null;
        public Boolean _usernameValid;
        public Boolean _passwordValid;
        public LoginUser(String userName, String password, DataManagement _data) {
            data = _data;
            table = data.getTable();
            userNameValid(userName, password);
        }
        public void userNameValid(String _user, String _pass) {
            if (table.ContainsKey(_user)) {
                _usernameValid = true;
                passwordValid(_user, _pass);
            } else {
                _usernameValid = false;
                return;
            }
        }
        public void passwordValid(String _username, String _pass) {
            Int64 userId = table[_username];
            User _user;
            DataManagement.loadData(userId);
            _user = data.getUserAccount();
            String salt = _user.getSalt();
            SecurityUtils security = _user.getSecurity();
            String hash = security.getHashedPassword(_pass, salt);

            if (hash.Equals(_user.getHash())) {
                user = _user;
                _passwordValid = true;
            } else {
                user = null;
                _passwordValid = false;
            }
        }
        public User getUser() {
            return user;
        }
    }
}
