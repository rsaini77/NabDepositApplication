using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NabDepositApplication.Models;

namespace NabDepositApplication.Interfaces
{
    public interface IDepositService
    {
        List<Deposit> GetAllDeposits();
        void AddDeposits();
        void DeleteDeposits();
        double GetTotalMaturityValue();
    }
}
