using Calculator.Tests.Unit.ClassFixture;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Calculator.Tests.Unit
{
    public class ComputingTests : IClassFixture<ComputingClassFixture>
    {
        Computing computing1;
        public ComputingTests(ComputingClassFixture c)
        {
            computing1 = c.computing;
        }
        [Fact]
        public void OddOrEven_Should_Return_Odd_When_Input_Is_OddValue()
        {
            var computing = new Computing();
            var result = computing.CheckOddOrEven(7);

            result.Should().Be("Odd");
        }
        [Fact]
        public void OddOrEven_Should_Return_Even_When_Input_Is_EvenValue()
        {
            var computing = new Computing();
            var result = computing.CheckOddOrEven(6);

            result.Should().Be("Even");
        }
    }
}
