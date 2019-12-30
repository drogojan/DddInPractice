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

            using (ISession session = SessionFactory.OpenSession())
            {
                long id = 1;
                var snackMachine = session.Get<SnackMachine>(id);
            }
        }
    }
}
