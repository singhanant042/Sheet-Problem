using System;

namespace Problem_2
{
    public abstract class Loan
    {
        public int loan_amount;
        public int interest_rate;
        public int term_in_month;

       
        public Loan(int loan_amount, int interest_rate, int term_in_month)
        {
            this.loan_amount = loan_amount;
            this.interest_rate = interest_rate;
            this.term_in_month = term_in_month;
        }

      
        public abstract double Calculate_loan();  
    }
}
