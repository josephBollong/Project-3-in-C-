using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Machine.Utils.datatypes {
    enum Operator {
        DEPOSIT("+") {

        @Override

        public double apply(double balance, double amount) {
        return balance + amount;
    }
},

    WITHDRAW("-") {
    @Override

        public double apply(double balance, double amount) {
    return balance - amount;
}
	};
	
	private final String text;
	
	private Operator(String _text) {
    text = _text;
}
public abstract double apply(double balance, double amount);

@Override
    public String toString() {
    return text;
}
    }
}
