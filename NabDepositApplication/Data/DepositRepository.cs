using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using NabDepositApplication.Helpers;
using NabDepositApplication.Interfaces;
using NabDepositApplication.Models;

namespace NabDepositApplication.Data
{
	public class DepositRepository : IDepositRepository
	{
		private static readonly List<Deposit> _items;
		private const int NUMBER_OF_INITIAL_DEPOSITS = 50;

		public List<Deposit> GetAllDeposits()
		{
			//Return all the items.
			return _items;
		}

		public double GetTotalMaturityValue()
		{
			//Return the total maturity value.
			return _items.Sum(x => x.MaturityAmount);
		}

		public Deposit GenerateSingleDeposit()
		{
			//Generate a single deposit
			var modelFaker = new Faker<Deposit>()
				.RuleFor(o => o.Principal, f => f.Random.Double(3 * 1000000, 5 * 1000000))
				.RuleFor(o => o.StartDate, f => f.Date.PastOffset(60, DateTime.Now.AddYears(-5)).Date.ToShortDateString())
				.RuleFor(o => o.EndDate, f => f.Date.PastOffset(1, DateTime.Now.AddYears(5)).Date.ToShortDateString())
				.RuleFor(o => o.InterestRate, f => f.Random.Int(2, 5))
				.RuleFor(o => o.Term, f => f.Random.Int(2, 5))
				.RuleFor(o => o.MaturityAmount, f => f.Random.Double(3 * 1000000, 5 * 1000000));
			return (modelFaker.Generate());
		}

		public void AddSingleDeposit(Deposit deposit)
		{
			//Add the deposit
			_items.Add(deposit);

		}

		public void DeleteSingleDeposit()
		{
			//Remove the deposit
			_items.RemoveAt(0);

		}

		static DepositRepository()
		{
			_items = new List<Deposit>();

			//Fake the values.
			var modelFaker = new Faker<Deposit>()
			   .RuleFor(o => o.Principal, f => f.Random.Double(.5 * 1000000, 1 * 1000000))
			   .RuleFor(o => o.StartDate, f => f.Date.PastOffset(60, DateTime.Now.AddYears(-5)).Date.ToShortDateString())
			   .RuleFor(o => o.EndDate, f => f.Date.PastOffset(1, DateTime.Now.AddYears(5)).Date.ToShortDateString())
			   .RuleFor(o => o.InterestRate, f => f.Random.Int(2, 5))
			   .RuleFor(o => o.Term, f => f.Random.Int(2, 5))
			   .RuleFor(o => o.MaturityAmount, f => f.Random.Double(1.5 * 1000000, 2 * 1000000));

			//Generate the initial 50 deposits.
			for (int i = 0; i < NUMBER_OF_INITIAL_DEPOSITS; i++)
			{
				_items.Add(modelFaker.Generate());
			}
		}
	}
}