using System;

namespace NabDepositApplication.Models
{
	public class Deposit
	{
		public double Principal { get; set; }

		public string StartDate { get; set; }

		public string EndDate { get; set; }

		public double InterestRate { get; set; }
		public int Term { get; set; }
		public double MaturityAmount { get; set; }
	}
}