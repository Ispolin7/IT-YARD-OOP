using IT_YARD.Models;
using IT_YARD.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using UnitTests.Stubs;

namespace UnitTests.Repositories
{
    [TestClass]
    public class RepositoryTests
    {
        Repository<Customer> TestRepository { get; set; }

        /// <summary>
        /// Init repository
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            TestRepository = new CustomerStubRepository().Customers;
        }

        /// <summary>
        /// Test index method
        /// </summary>
        [TestMethod]
        public void All_GetAllEntities_ExpectedCount3()
        {
            IEnumerable<Customer> collection = TestRepository.All();
            Assert.IsTrue(collection.Count() == 3, $"Emount of elements - {collection.Count()},expected - 3");
        }

        /// <summary>
        /// Test add new item
        /// </summary>
        [TestMethod]
        public void Insert_AddNewItem_ExpectedCountAs4()
        {
            this.TestRepository.Insert(new Customer("Owner", "Store", "owner@mail.com", 1));
            Assert.IsTrue(TestRepository.Items.Count == 4, $"Emount of elements - {TestRepository.Items.Count}, expected - 4");
        }

        /// <summary>
        /// Get entity from repository
        /// </summary>
        [TestMethod]
        public void GetById_GetEntity_ExpectedSecondCustomerEmail()
        {
            var customer = TestRepository.GetById(Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988"));
            Assert.IsTrue(customer.Email == "buyer@mail.com", $"Email - {customer.Email}, expected - buyer@mail.com");
        }

        /// <summary>
        /// Update entity in repository
        /// </summary>
        [TestMethod]
        public void Update_UpdateEntity_ExpectedSuccess()
        {
            var customer = new Customer()
            {
                Id = Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"),
                FirstName = "Test",
                LastName = "Test",
                Email = "test@mail.com",
                Gender = 1
            };
            Assert.IsTrue(TestRepository.Update(customer));
        }

        /// <summary>
        /// Remove entity from repository
        /// </summary>
        [TestMethod]
        public void Delete_RemoveEntity_ExpectedCountAs2()
        {
            TestRepository.Delete(Guid.Parse("edb050f5-ca3b-4381-a4ba-7b57ebeb108f"));
            Assert.IsTrue(TestRepository.Items.Count == 2, $"Emount of elements - {TestRepository.Items.Count}, expected - 2");
        }

        /// <summary>
        /// Check is there an entity in the repository
        /// </summary>
        [TestMethod]
        public void InRepository_IsEntityInRepository_ExpectedSuccess()
        {
            Assert.IsTrue(TestRepository.InRepository(Guid.Parse("02aaa926-2d33-4935-9e55-478d4b10d988")));
        }
    }
}
