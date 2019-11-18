using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    class StackTests
    {
        private Stack<string> _stack;
        [SetUp]
        public void Setup()
        {
            _stack = new Stack<string>();
        }

        //Checking Count Property

        [Test]
        public void Count_EmptyStack_ReturnZero()
        {
            Assert.That(_stack.Count, Is.EqualTo(0));
        }

        //Pushing Empty Element into Stack
        [Test]
        public void Push_ArguementIsNull_ThrowsArguementNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        //Pushing Elements into Stack

        [Test]
        public void Push_ValidObject_ObjectIsStoredInTheStack()
        {
            _stack.Push("One");
            Assert.That(_stack.Count, Is.EqualTo(1));
            Assert.That(_stack.Peek(), Is.EqualTo("One"));      //Just For Extra Verfication
            _stack.Push("Two");
            Assert.That(_stack.Count, Is.EqualTo(2));
            Assert.That(_stack.Peek(), Is.EqualTo("Two"));      //Just For Extra Verfication

        }

        //Popping elements from Empty Stack
        [Test]
        public void Pop_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }


        //This Is MY Solution

        //[Test]
        //public void Pop_StackWithObjects_ReturnsTopElement()
        //{
        //    //Pushing values into Stack
        //    _stack.Push("One");
        //    _stack.Push("Two");

        //    //Counting total Values
        //    Assert.That(_stack.Count, Is.EqualTo(2));

        //    //Popping On Element
        //    var firstElement = _stack.Pop();
        //    Assert.That(firstElement, Is.EqualTo("Two"));

        //    Assert.That(_stack.Count, Is.EqualTo(1));

        //    //Popping Second Element
        //    var secondElement = _stack.Pop();

        //    Assert.That(secondElement, Is.EqualTo("One"));
        //    Assert.That(_stack.Count, Is.EqualTo(0));

        //}

        //Breaking above Solution into two test Part- 1
        [Test]
        public void Pop_StackWithObjects_ReturnsTopElement()
        {
            _stack.Push("One");
            _stack.Push("Two");
           
            var firstElement = _stack.Pop();
            Assert.That(firstElement, Is.EqualTo("Two"));
        }

        //Part - 2
        [Test]
        public void Pop_StackWithObjects_RemovesElementsFromTheList()
        {
            _stack.Push("One");
            _stack.Push("Two");

            _stack.Pop();
            Assert.That(_stack.Count, Is.EqualTo(1));
        }



        [Test]
        public void Peek_EmptyStack_ThrowsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.InvalidOperationException);
        }

        [Test]
        public void Peek_StackWithObjects_ReturnsTopElement()
        {
            _stack.Push("One");
            _stack.Push("Two");
            Assert.That(_stack.Peek(), Is.EqualTo("Two"));
        }

        [Test]
        public void Peek_StackWithObjects_DoesNotRemoveObjectFromList()
        {
            _stack.Push("One");
            _stack.Push("Two");
            _stack.Peek();
            Assert.That(_stack.Count, Is.EqualTo(2));

        }


    }
}
