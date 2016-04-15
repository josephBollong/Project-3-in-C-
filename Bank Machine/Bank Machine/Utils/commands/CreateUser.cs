using Bank_Machine.Utils.datatypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.commands {
    class CreateUser {
        User user;

        private String userName = null;
        private String password = null;
        private String screenName = null;


        private String _out = "";
	
	public CreateUser(String usr, String pass, String name) {

            setUserName(usr);
            setPassword(pass);
            setScreenName(name);

            user = new User(userName, password, screenName);
		
		_out = "User Name: " + userName + "\n\r" + "Password: " + getMaskedPassword(password) + "\n\r" + "Screen name: " + screenName + "\n\r" + "Welcome " + screenName;

        }
        private String getMaskedPassword(String password) {

            String mask = "";
            int x = 0;

            while (x < password.Length) {
                mask = mask + "*";
                x++;
            }
            return mask;
        }
        public String getOutput() {
            return _out;
        }

        private void setUserName(String _userName) {
            userName = _userName;
        }
        private void setPassword(String _password) {
            password = _password;
        }
        private void setScreenName(String _screenName) {
            screenName = _screenName;
        }
        public User getUser() {
            return user;
        }
    }
}
