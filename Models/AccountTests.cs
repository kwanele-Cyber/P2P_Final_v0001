using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using P2P_Final_v0._001.Models;

namespace P2P_Final_v0._001.Models
{
    [TestClass]
    public class AccountTests
    {
        private MockRepository mockRepository;

        [TestInitialize]
        public void TestInitialize()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);


        }

        private Account CreateAccount()
        {
            return new Account();
        }

        [TestMethod]
        public void TestMethod1()
        {
            // Arrange
            var account = this.CreateAccount();

            // Act


            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
