namespace Ch04Ex02PrimeFactorsTests
{
    public class FactorsTests
    {
        [Fact]
        public void Test1()
        {
            int number = 1;
            string actual = PrimeFactors(number);
            string expected = "1";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test30()
        {
            int number = 30;
            string actual = PrimeFactors(number);
            string expected = "2x3x5x1";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test37()
        {
            int number = 37;
            string actual = PrimeFactors(number);
            string expected = "37";
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void Test99()
        {
            int number = 99;
            string actual = PrimeFactors(number);
            string expected = "3x3x11";
            Assert.Equal(expected, actual);
        }
    }
}