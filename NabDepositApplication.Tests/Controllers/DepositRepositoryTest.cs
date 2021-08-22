using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabDepositApplication.Interfaces;
using NabDepositApplication.Data;

namespace NabDepositApplication.Tests.Controllers
{
    [TestClass]
    public class DepositRepositoryTest
    {
        IDepositRepository _depositRepository;

        public DepositRepositoryTest()
        {
            _depositRepository = new DepositRepository();

        }
        [TestMethod]
        public void InitialDepositGeneratesMaturityAmountBetween70To100Million()
        {

           // _itemRepository.ClearDeposit();
            var totalMaturityValue = _depositRepository.GetTotalMaturityValue();
            Assert.IsTrue(totalMaturityValue >= 70 * 1000000 && totalMaturityValue <= 100 * 1000000);
        }
        [TestMethod]
        public void NewDepositGeneratesMaturityAmountBetween3To5Million()
        {

            var deposit = _depositRepository.GenerateSingleDeposit();
            Assert.IsTrue(deposit.MaturityAmount >= 3 * 1000000 && deposit.MaturityAmount <= 5 * 1000000);
        }

        [TestMethod]
        public void NumberOfItemsInRepositoryIsGreaterThanZero()
        {

            var items = _depositRepository.GetAllDeposits();
            Assert.IsTrue(items.Count > 0);
        }
        [TestMethod]
        public void TotalMaturityValueInRepositoryIsGreaterThanZero()
        {

            var maturityValue = _depositRepository.GetTotalMaturityValue();
            Assert.IsTrue(maturityValue > 0);
        }
    }
}
