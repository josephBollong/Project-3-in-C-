using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.datatypes {
    class SavingsAccount : Account {

        private Double fee = 0.50;

        public SavingsAccount(string _accountName, double _amount, long _userId, string _comment) : base(_accountName, _amount, _userId, _comment) {
        }

        public override string deposit(Double _amount, String _comment) {
            this.transaction = new Transaction(this.balance, _amount, _comment, true);
            this.balance = this.transaction.getBalance();
            this.listOfTransactions.Add(this.transaction);
            String str = "Deposit Done." + "\n\r" + this.transaction.getAmount(0) + " deposited." + "\n\r" + this.transaction.getBalance(0) + " is you new balance.";
            return str;
        }

        public override String getAirMiles() {
            String airMiles = "";
            return airMiles; ;
        }

        public override string withdraw(Double _amount, String _comment) {
            String str = "";
            if (_amount <= balance) {
                this.transaction = new Transaction(this.balance, _amount, _comment, false);
                this.balance = this.transaction.getBalance();
                this.listOfTransactions.Add(this.transaction);
                this.transaction = new Transaction(this.balance, fee, "Withdraw Fee", false);
                this.balance = this.transaction.getBalance();
                this.listOfTransactions.Add(this.transaction);
                str = "Withdraw Done.";
            } else {
                str = "The amount requested is greater than the current account balance. Try a different amount.";
            }
            return str;
        }
    }
}
