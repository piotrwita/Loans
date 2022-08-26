using CsvHelper;
using CsvHelper.Configuration;
using Loans.Domain.Applications;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Loans.Tests
{
    public class LoanTermShould
    {
        [TestCase(1)]
        public void LoanTermYearEqualTo(int param)
        {
            //Act
            var loanTerm1 = new LoanTerm(param);
            var loanTerm2 = new LoanTerm(param);

            //Assert
            Assert.That(loanTerm2, Is.EqualTo(loanTerm1));
        }

        [TestCase(1)]
        public void LoanTermYearNotSame(int param)
        {
            //Act
            var loanTerm1 = new LoanTerm(param);
            var loanTerm2 = new LoanTerm(param);
            var loanTerm3 = loanTerm1;

            //Assert
            Assert.That(loanTerm2, Is.Not.SameAs(loanTerm1));
            Assert.That(loanTerm1, Is.SameAs(loanTerm3));
        }

        [Test]
        public void ComopareTwoString()
        {
            //Act
            var list1 = new List<string>();
            var list2 = new List<string>();
            var list3 = list1;

            //Assert
            Assert.That(list1, Is.SameAs(list3));
        }

        [TestCase(1)]
        public void CompareLoanTermMonths(int param)
        {
            //Act
            var loanTerm1 = new LoanTerm(param);
            var loanTerm2 = new LoanTerm(param);

            //Arrange
            var months1 = loanTerm1.ToMonths();
            var months2 = 12;

            //Assert
            Assert.That(months1, Is.SameAs(months2),"err");
        }

        [Test]
        public void CompareTwoDouble()
        {
            //Act
            var d1 = 0.1;
            var d2 = 0.2;

            //Assert
            Assert.That(d1 + d2, Is.EqualTo(0.3).Within(0.1));
        }

        [Test]
        public void CompareDivTwoDouble()
        {
            //Act
            var d1 = 1.0;
            var d2 = 3.0;

            //Assert
            Assert.That(d1 / d2, Is.EqualTo(0.3333).Within(0.0001));
        }

        [Test]
        public void ShouldMethodReturnTheSameElementCount()
        {
            //Act
            var list = new List<LoanProduct>() { new LoanProduct(1,"A", 10) ,
                                                 new LoanProduct(2, "B", 20) , 
                                                 new LoanProduct(3, "C", 30) };

            var loanAmount = new LoanAmount("PLN", 100);

            var productComparer = new ProductComparer(loanAmount, list);
            var loanTerm = new LoanTerm(30);

            //Arrange
            var loanTermList = productComparer.CompareMonthlyRepayments(loanTerm);

            //Assert
            Assert.That(loanTermList, Has.Exactly(list.Count).Items);

        }

        [Test]
        public void ShouldMethodReturnUniqueElementCount()
        {
            //Act
            var list = new List<LoanProduct>() { new LoanProduct(1,"A", 10) ,
                                                 new LoanProduct(2, "B", 20) ,
                                                 new LoanProduct(3, "C", 30) };

            var loanAmount = new LoanAmount("PLN", 100);

            var productComparer = new ProductComparer(loanAmount, list);
            var loanTerm = new LoanTerm(30);

            //Arrange
            var loanTermList = productComparer.CompareMonthlyRepayments(loanTerm);

            //Assert
            Assert.That(loanTermList, Is.Unique);
        }

        [Test]
        public void ShouldMethodReturnCorrectFirstValue()
        {
            //Act
            var list = new List<LoanProduct>() { new LoanProduct(1,"A", 10) ,
                                                 new LoanProduct(2, "B", 20) ,
                                                 new LoanProduct(3, "C", 30) };

            var loanAmount = new LoanAmount("PLN", 100);

            var productComparer = new ProductComparer(loanAmount, list);
            var loanTerm = new LoanTerm(30);

            //Arrange
            var loanTermList = productComparer.CompareMonthlyRepayments(loanTerm);

            //Assert
            Assert.That(loanTermList, Has.Exactly(1).Matches<MonthlyRepaymentComparison>(name => name.ProductName.Equals("A")));
        }

        [Test]
        public void ShouldMethodReturnCorrectFirstValueParams()
        {
            //Act
            var list = new List<LoanProduct>() { new LoanProduct(1,"A", 10) ,
                                                 new LoanProduct(2, "B", 20) ,
                                                 new LoanProduct(3, "C", 30) };

            var loanAmount = new LoanAmount("PLN", 100);

            var productComparer = new ProductComparer(loanAmount, list);
            var loanTerm = new LoanTerm(30);

            //Arrange
            var loanTermList = productComparer.CompareMonthlyRepayments(loanTerm);

            //Assert
            Assert.That(loanTermList, Has.Exactly(1).Matches<MonthlyRepaymentComparison>(p => 
                    p.ProductName.Equals("A") && 
                    p.InterestRate.Equals(10) && 
                    p.MonthlyRepayment > 0));
        }

        [Test]
        public void ShoudBeLoanTermIsException()
        {
            //Assert
            Assert.That(() => new LoanTerm(0), Throws.TypeOf<ArgumentOutOfRangeException>()
             .With
             .Message
             .EqualTo("Please specify a value greater than 0. (Parameter 'years')")); 
        }

        [TestCaseSource(typeof(MonthlyRepaymentCsvData), "GetTestCases", new object[] { "Data.csv" })]
        public void TestMethodCalculateMonthlyRepayment(decimal principal, decimal interestRate, int termInYears, decimal expectedMonthlyPayment)
        {
            var sut = new LoanRepaymentCalculator();

            var monthlyPayment = sut.CalculateMonthlyRepayment(
                                        new LoanAmount("USD", principal),
                                        interestRate,
                                        new LoanTerm(termInYears));

            Assert.That(monthlyPayment, Is.EqualTo(expectedMonthlyPayment));
        }
    }

    public class MonthlyRepaymentCsvData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var testData = new List<TestCaseData>();

            string[] data = File.ReadAllLines(csvFileName);

            foreach (string s in data)
            {
                // decimal decimal int decimal
                string[] parts = s.Split(",", StringSplitOptions.RemoveEmptyEntries);
                testData.Add(new TestCaseData(
                    Decimal.Parse(parts[0].Trim(), CultureInfo.InvariantCulture),
                    Decimal.Parse(parts[1].Trim(), CultureInfo.InvariantCulture),
                    Int32.Parse(parts[2].Trim()),
                    Decimal.Parse(parts[3].Trim(), CultureInfo.InvariantCulture)
                    ));
            }

            return testData;
        }
    }
}
