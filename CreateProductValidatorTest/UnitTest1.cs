using ECommerceAPI.Application.Validators.Products;
using ECommerceAPI.Application.ViewModels.Products;

namespace CreateProductValidatorTest
{
    public class Tests
    {
        [TestFixture]
        public class CreateProductValidatorTests
        {
            private CreateProductValidator _validator;

            [SetUp]
            public void SetUp()
            {
                _validator = new CreateProductValidator();
            }

            [Test]
            public void Should_Return_Error_When_Name_Is_Null()
            {
                // Arrange
                var vm = new VM_Create_Product
                {
                    Name = null,
                    Stock = 10,
                    Price = 20
                };

                // Act
                var result = _validator.Validate(vm);

                // Assert
                Assert.IsFalse(result.IsValid);
                Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage.Contains("Please do not leave the product name blank.")));
            }

            [Test]
            public void Should_Return_Error_When_Stock_Is_Negative()
            {
                // Arrange
                var vm = new VM_Create_Product
                {
                    Name = "Test Product",
                    Stock = -10,
                    Price = 20
                };

                // Act
                var result = _validator.Validate(vm);

                // Assert
                Assert.IsFalse(result.IsValid);
                Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage.Contains("Stock information cannot be less than zero.")));
            }

            [Test]
            public void Should_Return_Error_When_Price_Is_Negative()
            {
                // Arrange
                var vm = new VM_Create_Product
                {
                    Name = "Test Product",
                    Stock = 10,
                    Price = -20
                };

                // Act
                var result = _validator.Validate(vm);

                // Assert
                Assert.IsFalse(result.IsValid);
                Assert.IsTrue(result.Errors.Any(e => e.ErrorMessage.Contains("Price information cannot be less than zero.")));
            }

            [Test]
            public void Should_Return_Success_When_All_Fields_Are_Valid()
            {
                // Arrange
                var vm = new VM_Create_Product
                {
                    Name = "Test Product",
                    Stock = 10,
                    Price = 20
                };

                // Act
                var result = _validator.Validate(vm);

                // Assert
                Assert.IsTrue(result.IsValid);
            }
        }
    }
}