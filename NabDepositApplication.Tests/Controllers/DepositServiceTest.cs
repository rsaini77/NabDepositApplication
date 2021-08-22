using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabDepositApplication.Data;
using NabDepositApplication.Interfaces;
using NabDepositApplication.Services;

namespace NabDepositApplication.Tests.Controllers
{
    [TestClass]
    public class DepositServiceTest
    {
        IDepositRepository _itemRepository;
        IDepositService _depositService;
        public DepositServiceTest()
        {
            _itemRepository = new DepositRepository();
            _depositService = new DepositService(_itemRepository);
        }

        [TestMethod]
        public void AddDepositGeneratesMaturityAmountMoreThan120Million()
        {

            _depositService.AddDeposits();
            var deposit = _depositService.GetTotalMaturityValue();
            Assert.IsTrue(deposit >= 120 * 1000000);
        }

        [TestMethod]
        public void DeleteDepositGeneratesMaturityAmountMoreThan120Million()
        {

            _depositService.DeleteDeposits();
            var deposit = _depositService.GetTotalMaturityValue();
            Assert.IsTrue(deposit <= 50 * 1000000);
        }

        [TestMethod]
        public void NumberOfItemsInServiceIsGreaterThanZero()
        {

            var items = _depositService.GetAllDeposits();
            Assert.IsTrue(items.Count > 0);
        }
        [TestMethod]
        public void TotalMaturityValueInServiceIsGreaterThanZero()
        {

            var maturityValue = _depositService.GetTotalMaturityValue();
            Assert.IsTrue(maturityValue > 0);
        }

    }
}
