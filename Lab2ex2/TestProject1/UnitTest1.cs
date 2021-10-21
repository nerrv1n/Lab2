using NUnit.Framework;
using Lab2ex2;

namespace DepositTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            double a = 5000;
            double b = 115;
            double c = 5150;
            int n = 12;

            var message = Logic.ExerciseA(a, b, n);
            Assert.AreEqual("Сумма ежемесячного увеличения вклада превысило значение В через 9 месяцев", message);

            message = Logic.ExerciseB(a, c, n);
            Assert.AreEqual("Размер вклада превысило значение C через 2 месяца", message);
        }
        [Test]
        public void Test2()
        {
            double a = 4000;
            double b = 2000;
            double c = 30000;
            int n = 20;

            var message = Logic.ExerciseA(a, b, n);
            Assert.AreEqual("Cумма ежемесячного увеличения вклада не превысила 2000", message);

            message = Logic.ExerciseB(a, c, n);
            Assert.AreEqual("Размер вклада не превысил 30000", message);
        }
        [Test]
        public void Test3()
        {
            double a = 100;
            double b = 2.04;
            double c = 102.04;
            int n = 40;

            var message = Logic.ExerciseA(a, b, n);
            Assert.AreEqual("Сумма ежемесячного увеличения вклада превысило значение В через 3 месяца", message);

            message = Logic.ExerciseB(a, c, n);
            Assert.AreEqual("124", message);
        }
    }
}
