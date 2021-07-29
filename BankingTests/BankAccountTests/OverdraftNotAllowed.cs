using BankingDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace BankingTests.BankAccountTests
{
    public class OverdraftNotAllowed
    {

        // balance cannot go below zero.
        // account.Withdraw(1000000);
        // - no money is taken from your account.

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            try
            {
                account.Withdraw(openingBalance + 1);
            }
            catch (OverdraftNotAllowedException)
            {

                // Gulp! I'm kind of expecting this, but I want to make sure we
                // didn't decrement the balance on overdraft.
            }

            Assert.Equal(openingBalance, account.GetBalance());
        }

        // we should throw an exception.

        [Fact]
        public void OverdraftThrowsException()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();

            Assert.Throws<OverdraftNotAllowedException>(
                () => account.Withdraw(openingBalance + 1)
                );
        }
    }
}
