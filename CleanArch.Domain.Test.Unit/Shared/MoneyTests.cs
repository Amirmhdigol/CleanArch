using CleanArch.Domain.Shared;
using CleanArch.Domain.Shared.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CleanArch.Domain.Test.Unit.Shared
{
    public class MoneyTests
    {
        [Fact]
        public void Constructor_Should_Set_Value_When_Value_Is_BiggerThanZero()
        {
            var money = new Money(10000);

            money.Value.Should().Be(10000);
        }
        [Fact]
        public void Constructor_Should_Throw_InvalidDataException_When_Value_Is_LessThanZero()
        {
            var money = () => new Money(-1);

            money.Should().ThrowExactly<InvalidDataException>();
        }
        [Fact]
        public void FromRial_Should_Create_New_Money()
        {
            var money = Money.FromRial(10000);

            money.Value.Should().Be(10000);
        }
        [Fact]
        public void FromTooman_Should_Create_New_Money_In_Tooman()
        {
            var money = Money.FromTooman(10000);

            money.Value.Should().Be(100000);
        }
        [Fact]
        public void Plus_Operator_Should_Sum_Values_And_Return_New_Money()
        {
            //Arrange
            var money = Money.FromRial(10000);
            var money2 = Money.FromRial(50000);

            //Act
            var result = money + money2;

            //Assert
            result.Value.Should().Be(60000);
        }
        [Fact]
        public void ToString_Should_Return_Money_Value_With_String_Format()
        {
            //Arrange
            var money = Money.FromRial(10000);
            
            //Act
            var result = money.ToString();

            //Assert
            result.Should().Be("10,000");
        } 
        [Fact]
        public void Minus_Operator_Should_Decreas_Values_And_Return_New_Money()
        {
            //Arrange
            var money = Money.FromRial(10000);
            var money2 = Money.FromRial(50000);

            //Act
            var result = money2 - money;

            //Assert
            result.Value.Should().Be(40000);
        }
    }
}
