using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class CustomerControllerTests
    {
        [Test]
        public void GetCustomer_IdIsZero_ReturnNotFound()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(0);

            //First Method - Checks if type is an instance of class only
            Assert.That(result, Is.TypeOf<NotFound>());

            //Second Method -- check if type is an instance of class or its derivatives
            Assert.That(result, Is.InstanceOf<NotFound>());

        }

        [Test]
        public void GetCustomer_IdIsNotZero_ReturnOk()
        {
            var controller = new CustomerController();
            var result = controller.GetCustomer(3);

            Assert.That(result, Is.TypeOf<Ok>());
            Assert.That(result, Is.InstanceOf<Ok>());
        }

    }
}
