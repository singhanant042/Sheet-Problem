using System;


namespace Problem_2
{
     public class Car_loan : Loan
    {
         public Car_loan(int loan_amount, int interest_rate, int term_in_month):base(loan_amount, interest_rate, term_in_month) { }

        public override double Calculate_loan()
        {

            double rCarLoan = interest_rate / 12 / 100;  
            int nCarLoan = term_in_month * 12; 
            double EMICarLoan = (loan_amount* rCarLoan * Math.Pow(1 + rCarLoan, nCarLoan)) / (Math.Pow(1 + rCarLoan, nCarLoan) - 1);
            return EMICarLoan;

        }
    }
}
