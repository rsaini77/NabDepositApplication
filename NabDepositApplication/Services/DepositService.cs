using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NabDepositApplication.Data;
using NabDepositApplication.Interfaces;
using NabDepositApplication.Models;


namespace NabDepositApplication.Services
{
	public class DepositService : IDepositService
	{
		private readonly IDepositRepository _itemRepository;

		public DepositService(IDepositRepository itemRepository)
		{
			_itemRepository = itemRepository ?? throw new ArgumentNullException(nameof(itemRepository));
		}

		void IDepositService.AddDeposits()
		{
			throw new NotImplementedException();
		}

		void IDepositService.DeleteDeposits()
		{
			throw new NotImplementedException();
		}

		List<Deposit> IDepositService.GetAllDeposits()
		{
			throw new NotImplementedException();
		}

		double IDepositService.GetTotalMaturityValue()
		{
			throw new NotImplementedException();
		}
	}
}