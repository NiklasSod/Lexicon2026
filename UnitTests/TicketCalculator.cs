using Lexicon2026.Exercise_02;

namespace UnitTests
{
    public class TicketCalculator
    {
        [Fact]
        public void Test1()
        {
            int price = Lexicon2026.Exercise_02.TicketCalculator.TotalPrice(30);
            Assert.Equal(120, price);
        }
    }
}
