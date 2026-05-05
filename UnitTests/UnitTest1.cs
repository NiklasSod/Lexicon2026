using Lexicon2026.Exercise_02;

namespace UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int price = TicketCalculator.TotalPrice(30);
            Assert.Equal(120, price);
        }
    }
}
