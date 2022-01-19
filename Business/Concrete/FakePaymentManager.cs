using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Concrete
{
    public class FakePaymentManager : IPaymentService
    {
        public IResult Pay(CreditCard creditCard)
        {
            if (creditCard.CardOwner == "Ömer Nalçacı" && creditCard.CardNumber == "0000000000000000" && creditCard.ExpirationMonth == 1 && creditCard.ExpirationYear == 22 && creditCard.CVV == "123")
            {
                return new SuccessResult(Messages.PaymentSuccessful);
            }

            else
            {
                return new ErrorResult(Messages.PaymentFailed);
            }
        }
    }
}
