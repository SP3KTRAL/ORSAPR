using NUnit.Framework;
using System;

namespace Cover.UnitTests
{
    [TestFixture]
    public class CoverParameterTest
    {
        [TestCase(TestName = "Проверка геттера и сеттера у свойства" +
                             " CoverDiameter на внесение корректных" +
                             " значений")]
        public void TestCoverDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var coverParameter = new CoverParameter();
            
            //Act
            coverParameter.CoverDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.CoverDiameter);
        }

        [TestCase(10.0, TestName = "Проверка геттера и сеттера у свойства" +
                             " CoverDiameter на значения меньше 50")]
        [TestCase(510.0, TestName = "Проверка геттера и сеттера у свойства" +
                                 " CoverDiameter на значения больше 500")]
        public void TestSetCoverDiameter_IncorrectValue_ArgumentException(double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.CoverDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterSmallSteppedHoleCover на внесение " +
                             "корректных значений")]
        public void TestSetDiameterSmallSteppedHoleCover_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 200.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.DiameterSmallSteppedHoleCover = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.DiameterSmallSteppedHoleCover);
        }

        [TestCase(10.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterSmallSteppedHoleCover на " +
                             "значения меньше 15")]
        [TestCase(510.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterSmallSteppedHoleCover на " +
                             "значения больше максимального")]
        public void TestSetDiameterSmallSteppedHoleCover_IncorrectValue_ArgumentException(double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.CoverDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxDiameterSmallSteppedHoleCover на " +
                             "корректное значение")]
        public void TestSetMaxDiameterSmallSteppedHoleCover_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 200.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxDiameterSmallSteppedHoleCover = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxDiameterSmallSteppedHoleCover на " +
                             "значения больше максимального")]
        public void TestSetMaxDiameterSmallSteppedHoleCover_IncorrectValueLess0_ArgumentException()
        {
            //Setup
            var incorrectValue = -1.0;
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxDiameterSmallSteppedHoleCover = 
                    incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterLargeSteppedCoverHole на " +
                             "корректное значение")]
        public void TestSetDiameterLargeSteppedCoverHole_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 200.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.DiameterLargeSteppedCoverHole = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.DiameterLargeSteppedCoverHole);
        }

        [TestCase(10.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterLargeSteppedCoverHole на " +
                             "значение меньше 20")]
        [TestCase(500.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "DiameterLargeSteppedCoverHole на " +
                             "значение больше максимального")]
        public void TestSetDiameterLargeSteppedCoverHole_IncorrectValue_ArgumentException(double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.DiameterLargeSteppedCoverHole = 
                    incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxDiameterLargeSteppedCoverHole на " +
                             "корректное значение ")]
        public void TestSetMaxDiameterLargeSteppedCoverHole_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 200.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxDiameterLargeSteppedCoverHole = 
                correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.MaxDiameterLargeSteppedCoverHole);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxDiameterLargeSteppedCoverHole на " +
                             "значение меньше 0")]
        public void TestSetMaxDiameterLargeSteppedCoverHole_IncorrectValueLess0_ArgumentException()
        {
            //Setup
            var incorrectValue = -1.0;
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxDiameterLargeSteppedCoverHole = 
                    incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleDiameter на корректное значение")]
        public void TestSetSmallHoleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 20.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.SmallHoleDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.SmallHoleDiameter);
        }

        [TestCase(1.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleDiameter на значение меньше 2")]
        [TestCase(100.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleDiameter на значение больше" +
                             " максимального")]
        public void TestSetSmallHoleDiameter_IncorrectValue_ArgumentException(double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.SmallHoleDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxSmallHoleDiameter на корректное значение")]
        public void TestSetMaxSmallHoleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 20.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxSmallHoleDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.MaxSmallHoleDiameter);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxSmallHoleDiameter на значение меньше 0")]
        public void TestSetMaxSmallHoleDiameter_IncorrectValueLess0_ArgumentException()
        {
            //Setup
            var incorrectValue = -1.0;
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxSmallHoleDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleCircleDiameter на корректное" +
                             " значение")]
        public void TestSetSmallHoleCircleDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 100.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.SmallHoleCircleDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.SmallHoleCircleDiameter);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "OuterStepDiameter на корректное значение")]
        public void TestSetOuterStepDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 100.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.OuterStepDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.OuterStepDiameter);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleCircleDiameter на значение " +
                             "меньше 35")]
        public void TestSetSmallHoleCircleDiameter_IncorrectValueLess35_ArgumentException()
        {
            //Setup
            var incorrectValue = 10.0;
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.OuterStepDiameter = incorrectValue;
            });
        }
    }
}
