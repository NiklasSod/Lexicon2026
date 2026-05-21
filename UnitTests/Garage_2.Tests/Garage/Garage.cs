using System;
using System.Collections.Generic;
using System.Text;
using Lexicon2026.Garage_2.VehicleTypes;
using Xunit;

namespace UnitTests.Garage_2.Tests.Garage
{
	public class GarageTests
	{
		[Fact]
		public void WhenCapacityIsZero_ShouldThrowArgumentException()
		{
			var exception = Assert.Throws<ArgumentException>(() => new Garage<Vehicle>(0));

			Assert.Equal("Capacity must be greater than zero.", exception.Message);
		}
	}
}