using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using NabDepositApplication.Interfaces;
using NabDepositApplication.Models;

namespace NabDepositApplication.Data
{
	public class DepositRepository : IDepositRepository
	{
		void IDepositRepository.AddSingleDeposit(Deposit deposit)
		{
			throw new NotImplementedException();
		}

		void IDepositRepository.DeleteSingleDeposit()
		{
			throw new NotImplementedException();
		}

		Deposit IDepositRepository.GenerateSingleDeposit()
		{
			throw new NotImplementedException();
		}

		List<Deposit> IDepositRepository.GetAllDeposits()
		{
			throw new NotImplementedException();
		}

		double IDepositRepository.GetTotalMaturityValue()
		{
			throw new NotImplementedException();
		}
	}
}