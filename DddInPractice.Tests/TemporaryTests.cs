using System;
using System.Collections.Generic;
using System.Text;
using DddInPractice.Logic;
using NHibernate;
using Xunit;

namespace DddInPractice.Tests
{
    public class TemporaryTests
    {
        [Fact]
        public void Test()
        {
            SessionFactory.Init(@"Server=(localdb)\mssqllocaldb;Database=DddInPractice;Trusted_Connection=True;");

//            using (ISession session = SessionFactory.OpenSession())
//            {
//                long id = 1;
//                var snackMachine = session.Get<SnackMachine>(id);
//            }

            var repository = new SnackMachineRepository();
            SnackMachine snackMachine = repository.GetById(1);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.InsertMoney(Money.Dollar);
            snackMachine.BuySnack(1);
            repository.Save(snackMachine);
        }
    }
}
