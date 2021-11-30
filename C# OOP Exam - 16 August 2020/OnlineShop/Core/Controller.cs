namespace OnlineShop.Core
{
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Computers;
    using OnlineShop.Models.Products.Peripherals;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class Controller : IController
    {
        private List<string> validComponentTypesNames;
        private List<string> validPeripheralTypesNames;

        private List<Component> componentsRepo;
        private List<Computer> computersRepo;
        private List<Peripheral> peripheralsRepo;

        public Controller()
        {
            validComponentTypesNames = GetValidEntityNamesOfType<Component>();
            validPeripheralTypesNames = GetValidEntityNamesOfType<Peripheral>();

            componentsRepo = new List<Component>();
            computersRepo = new List<Computer>();
            peripheralsRepo = new List<Peripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            if (!IsComponentTypeValid(componentType))
            {
                throw new ArgumentException("Component type is invalid.");
            }

            if (ComponentExistsInRepo(id))
            {
                throw new ArgumentException("Component with this id already exists.");
            }

            var component = GenerateComponent(componentType, id, manufacturer, model, price, overallPerformance, generation);

            computersRepo
                .First(x => x.Id == computerId)
                .AddComponent(component);

            componentsRepo.Add(component);

            return $"Component {componentType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            throw new NotImplementedException();
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            if (!IsPeripheralTypeValid(peripheralType))
            {
                throw new ArgumentException("Peripheral type is invalid.");
            }

            if (PeripheralExistsInRepo(id))
            {
                throw new ArgumentException("Peripheral with this id already exists.");
            }

            var peripheral = GeneratePeripheral(peripheralType, id, manufacturer, model, price, overallPerformance, connectionType);

            computersRepo
                .First(x => x.Id == computerId)
                .AddPeripheral(peripheral);
            peripheralsRepo.Add(peripheral);

            return $"Peripheral {peripheralType} with id {id} added successfully in computer with id {computerId}.";
        }

        public string BuyBest(decimal budget)
        {
            throw new NotImplementedException();
        }

        public string BuyComputer(int id)
        {
            throw new NotImplementedException();
        }

        public string GetComputerData(int id)
        {
            throw new NotImplementedException();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            computersRepo
                .FirstOrDefault(x => x.Id == computerId)
                .RemoveComponent(componentType);

            var componentToRemove = componentsRepo
                .FirstOrDefault(x => x.GetType().Name == componentType);

            componentsRepo.Remove(componentToRemove);

            return $"Successfully removed {componentType} with id {componentToRemove.Id}.";
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            computersRepo
                .FirstOrDefault(x => x.Id == computerId)
                .RemovePeripheral(peripheralType);

            var peripheralToRemove = peripheralsRepo
                .FirstOrDefault(x => x.GetType().Name == peripheralType);

            peripheralsRepo.Remove(peripheralToRemove);

            return $"Successfully removed {peripheralType} with id {peripheralToRemove.Id}.";
        }

        private bool ComputerExistsInRepo(Computer computer)
        {
            return computersRepo.Any(x => x.Id == computer.Id);
        }

        private bool ComponentExistsInRepo(int componentId)
        {
            return componentsRepo.Any(x => x.Id == componentId);
        }

        private bool PeripheralExistsInRepo(int peripheralId)
        {
            return peripheralsRepo.Any(x => x.Id == peripheralId);
        }

        private bool IsComponentTypeValid(string componentType)
        {
            return validComponentTypesNames.Contains(componentType);
        }

        private bool IsPeripheralTypeValid(string peripheralType)
        {
            return validPeripheralTypesNames.Contains(peripheralType);
        }

        private Component GenerateComponent(string componentType,
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            int generation)
        {
            if (componentType == "CentralProcessingUnit")
            {
                return new CentralProcessingUnit(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "Motherboard")
            {
                return new Motherboard(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "PowerSupply")
            {
                return new PowerSupply(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "RandomAccessMemory")
            {
                return new RandomAccessMemory(id, manufacturer, model, price, overallPerformance, generation);
            }
            else if (componentType == "SolidStateDrive")
            {
                return new SolidStateDrive(id, manufacturer, model, price, overallPerformance, generation);
            }
            else
            {
                return new VideoCard(id, manufacturer, model, price, overallPerformance, generation);
            }
        }


        private Peripheral GeneratePeripheral(string peripheralType,
            int id,
            string manufacturer,
            string model,
            decimal price,
            double overallPerformance,
            string connectionType)
        {
            if (peripheralType == "Headset")
            {
                return new Headset(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Keyboard")
            {
                return new Keyboard(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else if (peripheralType == "Monitor")
            {
                return new Monitor(id, manufacturer, model, price, overallPerformance, connectionType);
            }
            else
            {
                return new Mouse(id, manufacturer, model, price, overallPerformance, connectionType);
            }
        }

        private List<string> GetValidEntityNamesOfType<T>()
        {
            var type = typeof(T);
            return Assembly.GetExecutingAssembly()
                       .GetTypes()
                       .Where(t => t.IsClass
                       && t != type
                       && !t.IsAbstract
                       && !t.IsInterface
                       && t.IsSubclassOf(type))
                       .Select(t => t.Name)
                       .Distinct()
                       .ToList();
        }
    }
}
