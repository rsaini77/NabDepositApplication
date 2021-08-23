using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Collections.Generic;
using NabDepositApplication.Models;
using NabDepositApplication.Services;

namespace NabDepositApplication.Controllers
{
    public class DepositsController : ApiController
    {
        private readonly DepositService _depositService;
               
        public DepositsController(DepositService depositsService)
        {
            _depositService = depositsService ?? throw new ArgumentNullException(nameof(depositsService));
        }

        [Route("api/Deposits")]
        [AcceptVerbs("GET")]
        public List<Deposit> Get()
        {
            List<Deposit> deposits = _depositService.GetAllDeposits();
            return deposits;
        }

        [Route("api/Deposits/Buy")]
        [AcceptVerbs("GET")]
        public List<Deposit> Buy()
        {
            _depositService.AddDeposits();
            List<Deposit> deposits = _depositService.GetAllDeposits();
            return deposits;
        }

        [Route("api/Deposits/Sell")]
        [AcceptVerbs("GET")]
        public List<Deposit> Sell()
        {
            _depositService.DeleteDeposits();
            List<Deposit> deposits = _depositService.GetAllDeposits();
            return deposits;
        }



    }
}