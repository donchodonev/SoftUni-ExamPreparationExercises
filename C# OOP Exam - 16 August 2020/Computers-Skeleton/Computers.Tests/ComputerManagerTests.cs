using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers.Tests
{
    public class Tests
    {
        private Computer computer;
        private Computer computerB;
        private ComputerManager cm;

        [SetUp]
        public void Setup()
        {
            computer = new Computer("a", "a", 1);
            computerB = new Computer("b","b",1);

            cm = new ComputerManager();
        }

        [Test]
        public void ComputersCountReturnsCountOfComputersBackingField()
        {
            cm.AddComputer(computer);

            int expectedComputersCount = 1;
            int actualComputersCount = cm.Count;

            Assert.AreEqual(expectedComputersCount, actualComputersCount);
        }

        [Test]
        public void AddComputerThrowsArgNullExceptionWhenComputerParamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cm.AddComputer(null), "Can not be null!");
        }

        [Test]
        public void AddComputerThrowsArgExceptionWhenComputerManufacturerAndModelComboIsAlreadyContained()
        {
            cm.AddComputer(computer);

            Assert.Throws<ArgumentException>(() => cm.AddComputer(computer), "This computer already exists.");
        }

        [Test]
        public void AddComputerShouldAddComputerToInternalCollection()
        {
            cm.AddComputer(computer);

            int expectedComputerCount = 1;

            int actualComputerCount = cm.Computers.Count;

            Assert.AreEqual(expectedComputerCount, actualComputerCount);
            Assert.That(cm.Computers.Contains(computer));
        }

        [Test]
        public void RemoveComputerThrowsArgumentNullExceptionWhenManufacturerIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cm.RemoveComputer(null, computer.Model));
        }

        [Test]
        public void RemoveComputerThrowsArgumentNullExceptionWhenModelIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cm.RemoveComputer(computer.Manufacturer, null));
        }

        [Test]
        public void RemoveComputerShouldRemoveComputerWithSearchedParameters()
        {
            cm.AddComputer(computer);

            cm.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.That(!cm.Computers.Contains(computer));
        }

        [Test]
        public void RemoveComputerShouldReturnComputerWithSearchedParameters()
        {
            cm.AddComputer(computer);

            var returnedPc = cm.RemoveComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(returnedPc, computer);
        }

        [Test]
        public void GetComputerShouldReturnArgumentNullExceptionOnNullManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => cm.GetComputer(null, "a"));
        }

        [Test]
        public void GetComputerShouldReturnArgumentNullExceptionOnNullModelAndManufacturer()
        {
            Assert.Throws<ArgumentNullException>(() => cm.GetComputer("A", null));
        }

        [Test]
        public void GetComputerShouldReturnArgumentNullExceptionOnNullModel()
        {
            Assert.Throws<ArgumentNullException>(() => cm.GetComputer(null, null));
        }

        [Test]
        public void GetComputerShouldReturnArgumenExceptionIfNoComputerIsFound()
        {
            cm.AddComputer(computer);
            Assert.Throws<ArgumentException>(() => cm.GetComputer("b", "b"), "There is no computer with this manufacturer and model.");
        }

        [Test]
        public void GetComputerShouldReturnWantedCompterWhenPresent()
        {
            cm.AddComputer(computer);

            var expectedComputer = computer;
            var actualComputer = cm.GetComputer(computer.Manufacturer, computer.Model);

            Assert.AreEqual(expectedComputer, actualComputer);
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnArgumentNullExWhenMethodParamIsNull()
        {
            Assert.Throws<ArgumentNullException>(() => cm.GetComputersByManufacturer(null));
        }

        [Test]
        public void GetComputersByManufacturerShouldReturnOnlyComputersFromManufacturerPassedAsParameter() 
        {
            cm.AddComputer(computer);
            cm.AddComputer(computerB);

            var expectedResult = 1;
            var actualResult = cm.GetComputersByManufacturer(computer.Manufacturer).Count;

            Assert.AreEqual(expectedResult,actualResult);
        }

        [Test]
        public void ComputerManagerConstructorInitializesInternalCollectionSuccessfully()
        {
            Assert.IsNotNull(cm.Computers);
            Assert.IsNotNull(cm);
        }

        [Test]
        public void ComputersPropertyShouldReturnContainedComputers()
        {
            cm.AddComputer(computer);
            cm.AddComputer(computerB);

            var computerCollection = new List<Computer>() { computer,computerB};

            Assert.AreEqual(cm.Computers,computerCollection);
        }
    }
}