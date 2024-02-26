using System;
using System.ComponentModel.Design;


namespace InventoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Информация о товарах:");
            Console.WriteLine();

            Inventory inventory = new Inventory();

            Item apple = new Item();
            apple.name = "Яблоко";
            apple.price = 2;
            apple.id = 1;
            apple.PrintItemInfo();
            


            Item watermelon = new Item();
            watermelon.name = "Арбуз";
            watermelon.price = 10;
            watermelon.id = 2;
            watermelon.PrintItemInfo();
            
            

            Item banana = new Item();
            banana.name = "Банан";
            banana.price = 5;
            banana.id = 3;
            banana.PrintItemInfo();
            


            while (true)
            {
                Console.WriteLine();
                
                Console.WriteLine("1. Добавить товар в инвентарь");
                Console.WriteLine("2. Посмотреть инвентарь");
                Console.WriteLine("3. Выйти");
                Console.Write("Выберите действие: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Введите название товара: ");
                        string name = Console.ReadLine();
                        if (name.ToLower() == "яблоко")
                        {
                          inventory.AddItem(apple);
                        }
                        
                        else if (name.ToLower() == "арбуз")
                        {
                          inventory.AddItem(watermelon);
                        }
                        
                        else  if (name.ToLower() == "банан")
                        {
                          inventory.AddItem(banana);
                        }
                       
                        else 
                        { 
                            Console.WriteLine("Неверное значение. Попробуйте снова."); 
                        }
                        break;
                   
                    case "2":
                        Console.WriteLine();
                        Console.WriteLine("Инвентарь:");
                        inventory.DisplayInventory();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Неверное значение. Попробуйте снова..");
                        break;
                }
            }
        }
    }
    class Item
    {
        public string name = "Undefined";
        public int price;
        public int id;
        public int amount = 1;

        public void PrintItemInfo()
        {
            Console.WriteLine($"Наименование: {name} , Цена: {price} , Количество: {amount} , Идентификатор: {id}");
        }
    }

    class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine();
            Console.WriteLine("Товар добавлен в инвентарь.");
        }

        public int CountItems()
        {
            return items.Count;
        }

        public double CalculateTotalPrice()
        {
            double totalPrice = 0;
            foreach (Item item in items)
            {
                totalPrice += item.price;
            }
            return totalPrice;
        }

        public void DisplayInventory()
        {
            foreach (Item item in items)
            {
                Console.WriteLine($"Наименование: {item.name}, Цена: {item.price}");
            }
            Console.WriteLine($"Общее количество товаров: {CountItems()}, Общая цена: {CalculateTotalPrice()} рублей.");
        }
    }
}