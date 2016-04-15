using Bank_Machine.Utils.commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.datatypes {
    abstract class Account {
        public long accountNumber;
        public String accountName;
        public Double balance = 0.0;
        public long ownerId;
        public List<Transaction> listOfTransactions;
        public Transaction transaction;

        public Account(String _accountName, Double _amount, Int64 _userId, String _comment) {

            accountNumber = DataManagement.account;
            DataManagement.account++;
            DataManagement.saveNums();
            accountName = _accountName;
            ownerId = _userId;
            listOfTransactions = new List<Transaction>();
            transaction = new Transaction(balance, _amount, _comment, true);
            balance = transaction.getBalance();
            listOfTransactions.Add(transaction);

        }

        public Double getBalance() {
            return balance;
        }

        public void setBalance(Double balance) {
            this.balance = balance;
        }

        public List<Transaction> getListOfTransactions() {
            return listOfTransactions;
        }

        public void setListOfTransactions(List<Transaction> _listOfTransactions) {
            listOfTransactions = _listOfTransactions;
        }

        public Int64 getAccountNumber() {
            return accountNumber;
        }

        public String getAccountName() {
            return accountName;
        }

        public Int64 getOwnerId() {
            return ownerId;
        }
        public abstract String deposit(Double _amount, String _comment);

        public abstract String withdraw(Double _amount, String _comment);

        public abstract string getAirMiles();

        public String getHistory() {
            String history = "--------------------HISTORY-------------------------" + "\n\r";
            Iterator<Transaction> itr = listOfTransactions.iterator();

            /*while (itr.hasNext()) {
                transaction = itr.next();
                history = history + "\n\r" + transaction.getReport(); 
            }*/
            String[] _l = listOfTransactions.stream().map(Transaction::getReport).toArray(String[]::new);
            history += Intercalate.intercalate(_l, "\n\r");
            return history;
        }
        @Override
    public String toString() {
            transaction = listOfTransactions.get(listOfTransactions.size() - 1);
            String str = transaction.getBalance(0);

            Optional<String> _airmiles = getAirMiles();
            String _print = _airmiles.isPresent() ? _airmiles.get() : "";
            //String _print=if _airmiles.isPresent() then _airmiles.get() else "";

            return getAccountNumber() + " \"" + getAccountName() + "\"" + str + _print;
        }
    }
}
