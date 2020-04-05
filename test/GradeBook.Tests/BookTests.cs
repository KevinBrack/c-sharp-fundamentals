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
  }
}