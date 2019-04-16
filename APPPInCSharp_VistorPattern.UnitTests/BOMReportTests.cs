using System;
using NUnit.Framework;
using System.Collections.Generic;

namespace APPPInCSharp_VistorPattern.UnitTests
{
    [TestFixture]
    public class BOMReportTests
    {
        private PiecePart p1;
        private PiecePart p2;
        private Assembly a;

        [SetUp]
        public void SetUp()
        {
            p1 = new PiecePart("997624", "MyPart", 3.20);
            p2 = new PiecePart("7734", "Hell", 666);
            a = new Assembly("5879", "MyAssembly");
        }

        [Test]
        public void CreatePart()
        {
            Assert.AreEqual("997624", p1.PartNumber);
            Assert.AreEqual("MyPart", p1.Description);
            Assert.AreEqual(3.20, p1.Cost, .01);
        }

        [Test]
        public void CreateAssembly()
        {
            Assert.AreEqual("5879", a.PartNumber);
            Assert.AreEqual("MyAssembly", a.Description);
        }

        [Test]
        public void Assembly()
        {
            a.Add(p1);
            a.Add(p2);
            Assert.AreEqual(2, a.Parts.Count);

            PiecePart p = a.Parts[0] as PiecePart;
            Assert.AreEqual(p, p1);

            p = a.Parts[1] as PiecePart;
            Assert.AreEqual(p, p2);
        }

        [Test]
        public void AssemblyOfAssemblies()
        {
            Assembly subAssembly = new Assembly("1234", "SubAssembly");
            subAssembly.Add(p1);
            a.Add(subAssembly);

            Assert.AreEqual(subAssembly, a.Parts[0]);
        }

        private class TestingVisitor : PartVisitor
        {
            public IList<Part> visitedParts = new List<Part>();

            public void Visit(Assembly a)
            {
                visitedParts.Add(a);
            }

            public void Visit(PiecePart pp)
            {
                visitedParts.Add(pp);
            }
        }

        [Test]
        public void VisitorCoverage()
        {
            a.Add(p1);
            a.Add(p2);

            TestingVisitor visitor = new TestingVisitor();
            a.Accept(visitor);

            Assert.IsTrue(visitor.visitedParts.Contains(p1));
            Assert.IsTrue(visitor.visitedParts.Contains(p2));
            Assert.IsTrue(visitor.visitedParts.Contains(a));
        }

        private Assembly cellphone;

        private void SetUpReportDatabase()
        {
            cellphone = new Assembly("CP-7734", "Cell Phone");
            PiecePart display = new PiecePart("DS-1428", "LCD Display", 14.37);
            PiecePart speaker = new PiecePart("SP-92", "Speaker", 3.50);
            PiecePart microphone = new PiecePart("MC-28", "Microphone", 5.30);
            PiecePart cellRadio = new PiecePart("CR-56", "Cell Radio", 30);
            PiecePart frontCover = new PiecePart("FC-77", "Front Cover", 1.4);
            PiecePart backCover = new PiecePart("RC-77", "RearCover", 1.2);

            Assembly keypad = new Assembly("KP-62", "Keypad");
            Assembly button = new Assembly("B52", "Button");

            PiecePart buttonCover = new PiecePart("CV-15", "Cover", .5);
            PiecePart buttonContact = new PiecePart("CN-2", "Contact", 1.2);

            button.Add(buttonCover);
            button.Add(buttonContact);
            for (int i = 0; i < 15; i++)
            {
                keypad.Add(button);
            }

            cellphone.Add(display);
            cellphone.Add(speaker);
            cellphone.Add(microphone);
            cellphone.Add(cellRadio);
            cellphone.Add(frontCover);
            cellphone.Add(backCover);
            cellphone.Add(keypad);
        }

        [Test]
        public void ExplodedCost()
        {
            SetUpReportDatabase();
            ExplodedCostVisitor v = new ExplodedCostVisitor();
            cellphone.Accept(v);

            Assert.AreEqual(81.27, v.Cost, .001);
        }

        [Test]
        public void PartCount()
        {
            SetUpReportDatabase();
            PartCountVisitor v = new PartCountVisitor();
            cellphone.Accept(v);

            Assert.AreEqual(36, v.PieceCount);
            Assert.AreEqual(8, v.PartNumberCount);
            Assert.AreEqual(1, v.GetCountForPart("DS-1428"), "DS-1428");
            Assert.AreEqual(1, v.GetCountForPart("SP-92"), "SP-92");
            Assert.AreEqual(1, v.GetCountForPart("MC-28"), "MC-28");
            Assert.AreEqual(1, v.GetCountForPart("CR-56"), "CR-56");
            Assert.AreEqual(1, v.GetCountForPart("RC-77"), "RC-77");
            Assert.AreEqual(15, v.GetCountForPart("CV-15"), "CV-15");
            Assert.AreEqual(15, v.GetCountForPart("CN-2"), "CN-2");
            Assert.AreEqual(0, v.GetCountForPart("Bob"), "Bob");
        }
    }
}