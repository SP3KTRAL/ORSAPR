using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Cover.UnitTests
{
    [TestFixture]
    public class CoverParameterTest
    {
        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "CoverDiameter на внесение корректных " +
                             "значений")]
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
        public void TestSetCoverDiameter_IncorrectValue_ArgumentException(
            double incorrectValue)
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

        [TestCase(TestName = "Проверка if OuterStepDiameter у свойства " +
                             "CoverDiameter на внесение корректных значений")]
        public void TestCoverDiameter_OuterStepDiameter0_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxOuterStepDiameter - 15, 
                coverParameter.MaxDiameterLargeSteppedCoverHole);
        }

        [TestCase(TestName = "Проверка if OuterStepDiameter у свойства " +
                             "CoverDiameter на внесение корректных значений")]
        public void TestCoverDiameter_OuterStepDiameterMoreMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var extrucValue = 350.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.OuterStepDiameter = extrucValue;
            coverParameter.CoverDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxOuterStepDiameter - 15,
                coverParameter.MaxDiameterLargeSteppedCoverHole);
        }

        [TestCase(TestName = "Проверка if OuterStepDiameter у свойства " +
                             "CoverDiameter на внесение некорректных значений")]
        public void TestCoverDiameter_OuterStepDiameterMore0LessMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 500.0;
            var extrucValue = 250.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverDiameter = correctValue;
            coverParameter.OuterStepDiameter = extrucValue;

            //Assert
            Assert.AreEqual(coverParameter.OuterStepDiameter - 15,
                coverParameter.MaxDiameterLargeSteppedCoverHole);
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole" +
                             " у свойства CoverDiameter на внесение " +
                             "некорректных значений")]
        public void TestCoverDiameter_DiameterLargeSteppedCoverHole0_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxDiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole " +
                             "у свойства CoverDiameter на внесение " +
                             "корректных значений")]
        public void TestCoverDiameter_DiameterLargeSteppedCoverHoleMoreMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var extrucValue = 335.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.DiameterLargeSteppedCoverHole = extrucValue;
            coverParameter.CoverDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxDiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole у свойства " +
                             "CoverDiameter на внесение некорректных значений")]
        public void TestCoverDiameter_DiameterLargeSteppedCoverHoleMore0LessMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 500.0;
            var extrucValue = 250.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverDiameter = correctValue;
            coverParameter.DiameterLargeSteppedCoverHole = extrucValue;

            //Assert
            Assert.AreEqual(coverParameter.DiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
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
        public void TestSetDiameterSmallSteppedHoleCover_IncorrectValue_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.DiameterSmallSteppedHoleCover = incorrectValue;
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
        public void TestSetDiameterLargeSteppedCoverHole_IncorrectValue_ArgumentException(
            double incorrectValue)
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
        public void TestSetSmallHoleDiameter_IncorrectValue_ArgumentException(
            double incorrectValue)
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

        [TestCase(10.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleCircleDiameter на значение " +
                             "меньше 35")]
        [TestCase(510.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "SmallHoleCircleDiameter на значение " +
                             "больше максимального")]
        public void TestSetOuterStepDiameter_IncorrectValue_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.OuterStepDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole у " +
                             "свойства OuterStepDiameter на внесение " +
                             "корректных значений")]
        public void TestOuterStepDiameter_DiameterLargeSteppedCoverHole0_ResultCorrectSet()
        {
            //Setup
            var correctValue = 350.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.OuterStepDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxDiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole у свойства " +
                             "OuterStepDiameter на внесение корректных значений")]
        public void TestOuterStepDiameter_DiameterLargeSteppedCoverHoleMoreMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 300.0;
            var extrucValue = 335.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.DiameterLargeSteppedCoverHole = extrucValue;
            coverParameter.OuterStepDiameter = correctValue;

            //Assert
            Assert.AreEqual(coverParameter.MaxDiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка if DiameterLargeSteppedCoverHole у свойства " +
                             "OuterStepDiameter на внесение некорректных значений")]
        public void TestOuterStepDiameter_DiameterLargeSteppedCoverHoleMore0LessMax_ResultCorrectSet()
        {
            //Setup
            var correctValue = 350.0;
            var extrucValue = 200.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.OuterStepDiameter = correctValue;
            coverParameter.DiameterLargeSteppedCoverHole = extrucValue;

            //Assert
            Assert.AreEqual(coverParameter.DiameterLargeSteppedCoverHole - 5,
                coverParameter.MaxDiameterSmallSteppedHoleCover);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                                   "MaxOuterStepDiameter на " +
                                   "корректное значение")]
        public void TestSetMaxOuterStepDiameter_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 100.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxOuterStepDiameter = correctValue;

            //Assert
            Assert.AreEqual(correctValue,
                coverParameter.MaxOuterStepDiameter);
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxOuterStepDiameter на значение меньше 0")]
        public void TestSetMaxOuterStepDiameter_CorrectValueLess0_ArgumentException()
        {
            //Setup
            var incorrectValue = -1.0;
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxOuterStepDiameter = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "CoverThickness на корректное значение")]
        public void TestSetCoverThickness_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 30.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverThickness = correctValue;

            //Assert
            Assert.AreEqual(correctValue,
                coverParameter.CoverThickness);
        }

        [TestCase(5.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "CoverThickness на значение меньше 6")]
        [TestCase(61.0, TestName = "Проверка геттера и сеттера у свойства " +
                             "CoverThickness на значение больше 60")]
        public void TestSetCoverThickness_IncorrectValue_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.CoverThickness = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "CoverStepHeight на корректное значение")]
        public void TestSetCoverStepHeight_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 30.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.CoverStepHeight = correctValue;

            //Assert
            Assert.AreEqual(correctValue, 
                coverParameter.CoverStepHeight);
        }

        [TestCase(3.0, TestName = "Проверка геттера и сеттера у свойства " +
                                  "CoverThickness на значение меньше 4")]
        [TestCase(61.0, TestName = "Проверка геттера и сеттера у свойства " +
                                   "CoverThickness на значение больше 40")]
        public void TestSetCoverStepHeight_IncorrectValue_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.CoverStepHeight = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                                   "MAXCoverStepHeight на корректное значение")]
        public void TestSetMaxCoverStepHeight_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 30.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxCoverStepHeight = correctValue;

            //Assert
            Assert.AreEqual(correctValue,
                coverParameter.MaxCoverStepHeight);
        }

        [TestCase(-1.0, TestName = "Проверка геттера и сеттера у свойства " +
                                   "MaxCoverStepHeight на значение меньше 0")]
        public void TestSetMaxCoverStepHeight_IncorrectValueLess0_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxCoverStepHeight = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "HeightInnerStepCover на корректное значение")]
        public void TestSetHeightInnerStepCover_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 30.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.HeightInnerStepCover = correctValue;

            //Assert
            Assert.AreEqual(correctValue,
                coverParameter.HeightInnerStepCover);
        }

        [TestCase(3.0, TestName = "Проверка геттера и сеттера у свойства " +
                                  "HeightInnerStepCover на значение меньше 5")]
        [TestCase(61.0, TestName = "Проверка геттера и сеттера у свойства " +
                                   "HeightInnerStepCover на значение больше 50")]
        public void TestSetHeightInnerStepCover_IncorrectValue_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.HeightInnerStepCover = incorrectValue;
            });
        }

        [TestCase(TestName = "Проверка геттера и сеттера у свойства " +
                             "MaxHeightInnerStepCover на корректное значение")]
        public void TestSetMaxHeightInnerStepCover_CorrectValue_ResultCorrectSet()
        {
            //Setup
            var correctValue = 30.0;
            var coverParameter = new CoverParameter();

            //Act
            coverParameter.MaxHeightInnerStepCover = correctValue;

            //Assert
            Assert.AreEqual(correctValue,
                coverParameter.MaxHeightInnerStepCover);
        }

        [TestCase(-1.0, TestName = "Проверка геттера и сеттера у свойства " +
                                   "MaxHeightInnerStepCover на значение меньше 0")]
        public void TestSetMaxHeightInnerStepCover_IncorrectValueLess0_ArgumentException(
            double incorrectValue)
        {
            //Setup
            var coverParameter = new CoverParameter();

            //Assert
            Assert.Throws<ArgumentException>(() =>
            {
                //Act
                coverParameter.MaxHeightInnerStepCover = incorrectValue;
            });
        }
    }
}
