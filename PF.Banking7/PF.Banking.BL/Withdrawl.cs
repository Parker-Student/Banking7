using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.Banking.BL
{
    /*
    a.	CustomerId (int)
    b.	WithdrawalId (int)
    c.	WithdrawalAmount (decimal)
    d.	WithdrawalDate (datetime)
    */
    class Withdrawl
    {

		private int customerid;

		public int CustomerId
		{
			get { return customerid; }
			set { customerid = value; }
		}


		private int withdrawlid;

		public int WithdrawlId
		{
			get { return withdrawlid; }
			set { withdrawlid = value; }
		}

		private decimal withdrawlamount;

		public decimal WithdrawlAmount
		{
			get { return withdrawlamount; }
			set { withdrawlamount = value; }
		}

		private DateTime withdrawldate;

		public DateTime WithdrawlDate
		{
			get { return withdrawldate; }
			set { withdrawldate = value; }
		}
	}
}
