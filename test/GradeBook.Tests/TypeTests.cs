using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Kevin";
            var upper = MakeUppercase(name);

            Assert.Equal("Kevin", name);
            Assert.Equal("KEVIN", upper);
        }

        private string MakeUppercase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            var y = GetInt();

            SetIntRef(ref x);
            SetInt(y);

            Assert.Equal(42, x);
            Assert.Equal(3, y);
        }

        private void SetInt(int y)
        {
            y = 42;
        }

        private void SetIntRef(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByOutParam()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByOut(out book1, "New Name");
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByOut(out Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameByRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetNameByRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotEqual(book1.Name, book2.Name);
            Assert.NotSame(book1, book2);
            Assert.False(Object.ReferenceEquals(book1, book2));
        }

        [Fact]
        public void TwoVariablesCanReferenceSameObject()
        {
            // arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // act

            // assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 1", book2.Name);
            Assert.Equal(book1.Name, book2.Name);
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}