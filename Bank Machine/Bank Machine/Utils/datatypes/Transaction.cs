using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.datatypes {
    class Transaction {
        private long transactionId;
        private Double amount;
        private Double balance;
        private String comment;
        private String date;
        private Boolean transactionType = null;
        private Locale locale = new Locale("en", "US");
        private NumberFormat cur = NumberFormat.getCurrencyInstance(locale);;
	
	public Transaction(Double _balance, Double _amount, String _comment, Boolean _transactionType) {

            transactionId = DataManagement.trans;
            DataManagement.trans++;
            DataManagement.saveNums();
            balance = _balance;
            comment = _comment;
            amount = _amount;
            transactionType = _transactionType;

            date = new SimpleDateFormat("yyyy-MM-dd").format(Calendar.getInstance().getTime());

            if (transactionType == true) {
                balance = Double.valueOf(calculate(Operator.DEPOSIT, balance, amount));

            } else if (transactionType == false) {
                balance = Double.valueOf(calculate(Operator.WITHDRAW, balance, amount));

            }
        }
        public String calculate(Operator op, double _balance, double _amount) {

            return String.valueOf(op.apply(_balance, _amount));
        }

        public Long getTransactionId() {
            return transactionId;
        }
        public Double getBalance() {
            return balance;
        }
        public String getBalance(int num) {
            String str = cur.format(balance);
            return str;
        }
        public Double getAmount() {
            return amount;
        }
        public String getAmount(int num) {
            String str = cur.format(amount);
            return str;
        }
        public String getComment() {
            return comment;
        }
        public String getDate() {
            return date;
        }
        public Boolean getTransactionType() {
            return transactionType;
        }
        public String getTransactionType(int num) {

            String str = null;
            if (transactionType == true) {
                str = "Deposit";

            } else if (transactionType == false) {
                str = "Withdraw";
            }
            return str;
        }

        public String getReport() {
            //throw new UnsupportedOperationException();
            String str = Intercalate.intercalate(" ", getDate(), getTransactionId().toString(), getComment(), getTransactionType(1), getAmount(1), getBalance(1));
            //String str = getDate() + " " + getTransactionId().toString() + " " + getComment() + " " + getTransactionType(1) + " " + getAmount(1) + " " + getBalance(1) ;
            return str;
        }
    }
}
