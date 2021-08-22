using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabDepositApplication.Models;

namespace NabDepositApplication.Interfaces
{
    public interface IDepositRepository
    {
		double GetTotalMaturityValue();


		Deposit GenerateSingleDeposit();


		void AddSingleDeposit(Deposit deposit);


		void DeleteSingleDeposit();


		List<Deposit> GetAllDeposits();

	}
}
