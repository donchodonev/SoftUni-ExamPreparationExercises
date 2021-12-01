namespace Robots.Tests
{
    using NUnit.Framework;
    using System;

    public class RobotsTests
    {
        private string name;
        private int batteryCapacity;
        private int managerCapacity;

        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void Initialize()
        {
            name = "pishlyo";
            batteryCapacity = 69;
            managerCapacity = 5;

            robot = new Robot(name, batteryCapacity);
            robotManager = new RobotManager(managerCapacity);
        }

        [Test]
        public void Ctor_Should_Initialize_Object()
        {
            Assert.IsNotNull(new RobotManager(managerCapacity));
        }

        [Test]
        public void Ctor_Should_Initialize_Object_With_Correct_Internal_Capacity()
        {
            int expectedCapacity = managerCapacity;
            int actualCapacity = robotManager.Capacity;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }

        [Test]
        public void Capacity_Should_Throw_ArgumentException_WhenNegative()
        {
            int expectedCapacity = managerCapacity;
            int actualCapacity = robotManager.Capacity;

            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void Capacity_Should_Return_Correct_Value()
        {
            int expectedCapacity = managerCapacity + 5;
            int actualCapacity = robotManager.Capacity + 5;

            Assert.AreEqual(expectedCapacity, actualCapacity);
        }
        [Test]
        public void Count_Should_Return_Correct_Amount_Of_Internal_Objects()
        {
            robotManager.Add(robot);

            int expectedResult = 1;
            int actualResult = robotManager.Count;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void Add_Should_Throw_Exception_When_It_Already_Contains_Robot_Being_Added()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot), $"There is already a robot with name {robot.Name}!");
        }

        [Test]
        public void Add_Should_Throw_Exception_When_It_Is_At_Full_Capacity()
        {
            var robotManager = new RobotManager(1);
            robotManager.Add(robot);
            var newRobot = new Robot("nqkoi si tam", 15);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(newRobot), "Not enough capacity!");
        }

        [Test]
        public void Add_Should_Add_Robot_To_Internal_Collection()
        {
            int robotsCountBeforeAddingRobot = robotManager.Count;

            robotManager.Add(robot);

            int robotsCountAfterAddingRobot = robotManager.Count;

            Assert.AreNotEqual(robotsCountBeforeAddingRobot, robotsCountAfterAddingRobot);
        }

        [Test]
        public void Remove_Should_Throw_Exception_When_Robot_With_Given_Name_Doesnt_Exist()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Remove("sashko"));
        }

        [Test]
        public void Remove_Should_Remove_Robot_When_Name_Is_Valid()
        {
            robotManager.Add(robot);

            int countWithOneRobot = robotManager.Count;

            robotManager.Remove(robot.Name);

            int countWithOneRobotRemoved = robotManager.Count;

            Assert.AreNotEqual(countWithOneRobot, countWithOneRobotRemoved);
        }

        [Test]
        public void Work_Should_Throw_Exception_When_Robot_With_Given_Name_Doesnt_Exist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "asd", 1), $"Robot with the name {robot.Name} doesn't exist!");
        }

        [Test]
        public void Work_Should_Throw_Exception_When_Robot_Doesnt_Have_Enough_Battery()
        {
            robotManager.Add(robot);
            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "asd", 70), $"{robot.Name} doesn't have enough battery!");
        }

        [Test]
        public void Work_Should_Reduce_Robot_Battery_After_Work_Is_Done()
        {
            robotManager.Add(robot);

            int robotBatteryBeforeWork = robot.Battery;

            robotManager.Work(robot.Name, "somejob", 68);

            int robotBatteryAfterWork = robot.Battery;

            Assert.AreNotEqual(robotBatteryBeforeWork,robotBatteryAfterWork);
        }

        [Test]
        public void Charge_Should_Throw_Exception_When_Robot_With_Given_Name_Doesnt_Exist()
        {
            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(robot.Name), $"Robot with the name {robot.Name} doesn't exist!");
        }

        [Test]
        public void Charge_Should_Charge_Robot_Battery_To_Battery_Maximum()
        {
            robotManager.Add(robot);

            robotManager.Work(robot.Name, "", 50);

            Assert.That(robot.Battery < robot.MaximumBattery);

            robotManager.Charge(robot.Name);

            Assert.AreEqual(robot.Battery, robot.MaximumBattery);
        }
    }
}
