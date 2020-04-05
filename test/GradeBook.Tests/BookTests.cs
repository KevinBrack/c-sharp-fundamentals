using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {

            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.1);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.5, result.Average, 1);
            Assert.Equal(90.1, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }

        [Fact]
        public void BookDoesNotAcceptInvalidValues()
        {
            var book = new Book("Valid");

            book.AddGrade(80);
            book.AddGrade(105);
            book.AddGrade(-3);

            var result = book.GetStatistics();

            Assert.Equal(80, result.Average);
        }
    }
}