using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using MatrixMultiplication;


namespace MatrixTests
{
    using NUnit.Framework;
    using System.Diagnostics;
    [TestFixture]
    public class MatrixTest
    {
        Matrix aMatrix;
        Matrix bMatrix;

        [SetUp]
        public void TestSetup()
        {
            List<List<int>> temp = new List<List<int>>();
            List<List<int>> temp2 = new List<List<int>>();
            temp.Add(new List<int>{1,-2});
            temp.Add(new List<int> { 3, -4 });
            aMatrix = new Matrix(temp);
            temp2.Add(new List<int> { -5, 6});
            temp2.Add(new List<int> { 7, -8});
            bMatrix = new Matrix(temp2);
        }
        [Test]
        public void ShouldExist()
        {
            Assert.NotNull(aMatrix);
            Assert.NotNull(bMatrix);
        }
        [Test]
        public void ShouldBeEqual()
        {
            Assert.IsTrue(aMatrix.Equals(aMatrix));
        }
        [Test]
        public void ShouldMultiplyTwoMatricies()
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int> { -19, 22 });
            temp.Add(new List<int> { -43, 50 });
            Matrix expected = new Matrix(temp);
            Matrix result = aMatrix * bMatrix;
            Assert.IsTrue(expected.Equals(result));
        }
        [Test]
        public void ShouldAddTwoMatricies()
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int>{-4,4});
            temp.Add(new List<int>{10,-12});
            Matrix expected = new Matrix(temp);
            Matrix result = aMatrix + bMatrix;
            Assert.IsTrue(expected.Equals(result));
        }
        
        [Test]
        public void ShouldMultiplyScalar()
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int> { 2, -4 });
            temp.Add(new List<int> { 6, -8});
            Matrix expected = new Matrix(temp);
            aMatrix.scalarMultiply(2);
            Assert.IsTrue(expected.Equals(aMatrix));
        }
        [Test]
        public void ShouldGetMatrix()
        {
            List<List<int>> expected = new List<List<int>>();
            expected.Add(new List<int> { 1, -2 });
            expected.Add(new List<int> { 3, -4 });
            List<List<int>> accual = aMatrix.getMatrix();
            Assert.AreEqual(expected, accual);
        }
        [Test]
        public void ShouldSetMatrix()
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int> { 2, -4 });
            temp.Add(new List<int> { 6, -8 });
            Matrix expected = new Matrix(temp);
            aMatrix.setMatrix(temp);
            Assert.IsTrue(expected.Equals(aMatrix));
        }
        [Test]
        public void ShouldPrintMatrix()
        {
            string expected = "[[1,3],[-2,-4]]";
            Assert.AreEqual(expected,aMatrix.ToString());
        }
        [Test]
        public void testListAreEqual()
        {
            List<List<int>> temp = new List<List<int>>();
            temp.Add(new List<int> { 2, -4 });
            temp.Add(new List<int> { 6, -8 });
            List<List<int>> temp2 = new List<List<int>>();
            temp2.Add(new List<int> { 2, -4,3 });
            temp2.Add(new List<int> { 6, -8,5 });
            List<List<int>> temp3 = new List<List<int>>();
            temp3.Add(new List<int> { 2, -2 });
            temp3.Add(new List<int> { 6, -8 });
            List<List<int>> nullLists = new List<List<int>>();
            nullLists.Add(null);
            nullLists.Add(null);
            List<List<int>> zeroLists = new List<List<int>>();
            zeroLists.Add(new List<int>());
            zeroLists.Add(new List<int>());
            Matrix expected = new Matrix();
            Matrix actual = new Matrix();
            expected.setMatrix(null);
            Assert.IsTrue(!expected.Equals(actual));
            actual.setMatrix(null);
            Assert.IsTrue(expected.Equals(actual));
            expected.setMatrix(temp);
            Assert.IsTrue(!expected.Equals(actual));
            actual.setMatrix(temp3);
            Assert.IsTrue(!expected.Equals(actual));
            actual.setMatrix(temp2);
            Assert.IsTrue(!expected.Equals(actual));
            Assert.IsTrue(!expected.Equals(null));
            Assert.IsTrue(!expected.Equals(5));
            expected.setMatrix(nullLists);
            Assert.IsTrue(!expected.Equals(actual));
            Assert.IsTrue(!actual.Equals(expected));
            actual.setMatrix(nullLists);
            Assert.IsTrue(expected.Equals(actual));
            expected.setMatrix(zeroLists);
            Assert.IsTrue(!expected.Equals(actual));
            actual.setMatrix(zeroLists);
            Assert.IsTrue(expected.Equals(actual));
            expected.setMatrix(temp3);
            Assert.IsTrue(!expected.Equals(actual));
        }
        [TearDown]
        public void TestTearDown()
        {
            aMatrix = null;
            bMatrix = null;
        }
    }
}
