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

		public List<Deposit> GetAllDeposits()
		{
			return _itemRepository.GetAllDeposits();

		}

		public void AddDeposits()
		{
			while (true)
			{
				
				if (_itemRepository.GetTotalMaturityValue() >= 120000000)
				{
					break;
				}
				var generateNewDeposit = _itemRepository.GenerateSingleDeposit();
				_itemRepository.AddSingleDeposit(generateNewDeposit);

				/*Commenting the sleep so that it can be run quickly*/
				//Thread.Sleep(5000);

			}

		}

		public void DeleteDeposits()
		{
			while (true)
			{
				if (_itemRepository.GetTotalMaturityValue() <= 50000000)
				{
					break;
				}
				_itemRepository.DeleteSingleDeposit();

				/*Commenting the sleep so that it can be run quickly*/
				//Thread.Sleep(5000);

			}
			
		}

		public double GetTotalMaturityValue()
		{
			return _itemRepository.GetTotalMaturityValue();
		}

	}
}