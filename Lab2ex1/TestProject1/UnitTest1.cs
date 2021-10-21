using NUnit.Framework;
using Lab2ex1;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TrainTestStay()
        {
            int a = 13;
            int b = 55;
            int c = 14;
            int d = 00;
            int n = 13;
            int m = 56;

            var message = Logic.Compare(a, b, c, d, n, m);

            Assert.AreEqual("Поезд на станции!", message);
        }
        [Test]
        public void TrainTestAway()
        {
            int a = 13;
            int b = 55;
            int c = 14;
            int d = 00;
            int n = 14;
            int m = 05;

            var message = Logic.Compare(a, b, c, d, n, m);

            Assert.AreEqual("Поезд не на станции!", message);
        }
    }
}
