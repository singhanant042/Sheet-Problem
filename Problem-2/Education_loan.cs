using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem_2
{
     public class Education_loan:Loan
    {
        public Education_loan(int loan_amount, int interest_rate, int term_in_month)
            : base(loan_amount, interest_rate, term_in_month) { }

        public override double Calculate_loan()
        {
            double rEducationLoan = interest_rate / 12 / 100;  // Monthly interest rate
            int nEducationLoan = term_in_month * 12;  // Total number of installments (months)
            double EMIEducationLoan = (loan_amount * rEducationLoan * Math.Pow(1 + rEducationLoan, nEducationLoan)) / (Math.Pow(1 + rEducationLoan, nEducationLoan) - 1);
            return EMIEducationLoan;
        }
    }
}
