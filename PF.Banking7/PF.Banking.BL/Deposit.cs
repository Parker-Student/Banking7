using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PF.Banking.BL
{
    /*
     a.	CustomerId (int)
    b.	DepositId (int)
    c.	DepositAmount (decimal)
    d.	DepositDate (datetime)

         */
    public class Deposit
    {

		private int customerid;

		public int CustomerId
		{
			get { return customerid; }
			set { customerid = value; }
		}


		private int depositid;

		public int DepositId
		{
			get { return depositid; }
			set { depositid = value; }
		}

		private decimal depositamount;

		public decimal DepositAmount
		{
			get { return depositamount; }
			set { depositamount = value; }
		}

		private DateTime depositdate;

		public DateTime DepositDate
		{
			get { return depositdate; }
			set { depositdate = value; }
		}

	}
}
