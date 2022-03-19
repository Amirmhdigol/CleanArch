using CleanArch.Domain.ProductsAgg;
using CleanArch.Domain.Shared.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Domain.Test.Unit.ProductAgg
{
    public class ProductImageTests
    {
        [Fact]
        public void Should_Create_New_ProductImage_When_Data_Is_Ok()
        {
            //Arrange
            var productImage = new ProductImage(1, "test.png");

            //Act

            //Assert
            productImage.ImageName.Should().Be("test.png");
        }
        [Fact]
        public void Ctor_Should_Throw_NullOrEmptyDomainDataException_When_ImageName_Is_Null()
        {
            //Arrange
            var result = () => new ProductImage(1, "");

            //Act

            //Assert
            result.Should().ThrowExactly<NullOrEmptyDomainDataException>().WithMessage("imageName is null or empty");
        }

    }
}
