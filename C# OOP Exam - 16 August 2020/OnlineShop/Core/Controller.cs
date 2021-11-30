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
        private List<string> validComputerTypesNames;

        private List<IComponent> componentsRepo;
        private List<IComputer> computersRepo;
        private List<IPeripheral> peripheralsRepo;

        public Controller()
        {
            validComponentTypesNames = GetValidEntityNamesOfType<Component>();
            validPeripheralTypesNames = GetValidEntityNamesOfType<Peripheral>();
            validComputerTypesNames = GetValidEntityNamesOfType<Computer>();

            componentsRepo = new List<IComponent>();
            computersRepo = new List<IComputer>();
            peripheralsRepo = new List<IPeripheral>();
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

            if (!ComputerExistsInRepo(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
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
            if (ComputerExistsInRepo(id))
            {
                throw new ArgumentException("Computer with this id already exists.");
            }

            if (!IsComputerTypeValid(computerType))
            {
                throw new ArgumentException("Computer type is invalid.");
            }

            var computer = GenerateComputer(computerType, id, manufacturer, model, price);

            computersRepo.Add(computer);

            return $"Computer with id {id} added successfully.";
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

            if (!ComputerExistsInRepo(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
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
            var computers = computersRepo.Where(x => x.Price <= budget);

            if (computers.ToList().Count == 0)
            {
                throw new ArgumentException($"Can't buy a computer with a budget of ${budget}.");
            }

            var bestComputerForTheMoney = computers
                .OrderByDescending(x => x.OverallPerformance)
                .First();

            computersRepo.Remove(bestComputerForTheMoney);

            return bestComputerForTheMoney.ToString();
        }

        public string BuyComputer(int id)
        {
            if (!ComputerExistsInRepo(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var computer = computersRepo.First(x => x.Id == id);

            computersRepo.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            if (!ComputerExistsInRepo(id))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            return computersRepo.FirstOrDefault(x => x.Id == id).ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            if (!ComputerExistsInRepo(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

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
            if (!ComputerExistsInRepo(computerId))
            {
                throw new ArgumentException("Computer with this id does not exist.");
            }

            var peripheralToRemove = computersRepo
                .FirstOrDefault(x => x.Id == computerId)
                .RemovePeripheral(peripheralType);

            peripheralsRepo.Remove(peripheralToRemove);

            return $"Successfully removed {peripheralType} with id {peripheralToRemove.Id}.";
        }

        private bool ComponentExistsInRepo(int componentId)
        {
            return componentsRepo.Any(x => x.Id == componentId);
        }

        private bool ComputerExistsInRepo(int computerId)
        {
            return computersRepo.Any(x => x.Id == computerId);
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

        private bool IsComputerTypeValid(string computerType)
        {
            return validComputerTypesNames.Contains(computerType);
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

        private Computer GenerateComputer(string computerType,
            int id,
            string manufacturer,
            string model,
            decimal price)
        {
            if (computerType == "Laptop")
            {
                return new Laptop(id, manufacturer, model, price);
            }
            else
            {
                return new DesktopComputer(id, manufacturer, model, price);
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
