using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CleanArch.Domain.OrdersAgg;
using FluentAssertions;
using NSubstitute;
using CleanArch.Domain.OrdersAgg.Services;
using CleanArch.Domain.OrdersAgg.Exceptions;
using CleanArch.Domain.Shared.Exceptions;

namespace CleanArch.Domain.Test.Unit.OrderAgg
{
    public class OrderTests
    {
        [Fact]
        public void Should_Create_Order()
        {
            var order = new OrdersAgg.Order(1);

            order.UserId.Should().Be(1);
            order.IsFinally.Should().Be(false);
        }
        [Fact]
        public void Should_Finally_Order_And_Add_DomainEvent()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            //Act
            order.Finallize();
            //Assert
            order.DomainEvents.Should().HaveCount(1);
        }

        [Fact]
        public void Add_Item_Should_Throw_ProductNotFoundException_When_Product_NotExist()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExists(Arg.Any<long>()).Returns(true);

            //Act
            var result = () => order.AddItem(1,2,30000,orderDomainService);

            //Assert
            result.Should().ThrowExactly<ProductNotFoundException>();
        } 
        [Fact]
        public void Add_Item_Should_Add_New_Item_To_Order()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExists(Arg.Any<long>()).Returns(false);

            //Act
            order.AddItem(1,2,30000,orderDomainService);

            //Assert
            order.TotalItems.Should().Be(2);
        }
        [Fact]
        public void Should_Not_Add_Item_To_Order_When_Product_Exist_In_Order()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExists(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 30000, orderDomainService);

            //Act
            order.AddItem(1,3,30000,orderDomainService);

            //Assert
            order.TotalItems.Should().Be(2);
        }
        [Fact]
        public void Remove_Item_Should_Throw_InvalidDomainDataException_When_Product_Doesnt_Exists_In_Order()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExists(Arg.Any<long>()).Returns(false);

            //Act
            var action = () => order.RemoveItem(2);

            //Assert
            action.Should().ThrowExactly<InvalidDomainDataException>();
        }
         [Fact]
        public void Remove_Item_Should_Remove_An_Item_From_Orders_When_Data_Is_Ok()
        {
            //Arrange
            var order = new OrdersAgg.Order(1);
            var orderDomainService = Substitute.For<IOrderDomainService>();
            orderDomainService.IsProductNotExists(Arg.Any<long>()).Returns(false);
            order.AddItem(1, 2, 30000, orderDomainService);

            //Act
            order.RemoveItem(1);

            //Assert
            order.TotalItems.Should().Be(0);
        }
    }
}
