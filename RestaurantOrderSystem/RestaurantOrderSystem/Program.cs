namespace RestaurantOrderSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant("Gourmet Haven");

            restaurant.Menu.AddMenuItem(new Food(1, "Салат Цезар", 120m, "Салати"));
            restaurant.Menu.AddMenuItem(new Food(2, "Піца Маргарита", 250m, "Основне блюдо"));
            restaurant.Menu.AddMenuItem(new Food(3, "Тірамісу", 150m, "Десерт"));
            restaurant.Menu.AddMenuItem(new Food(4, "Борщ", 100m, "Супи"));

            bool working = true;

            while (working)
            {
                Console.WriteLine("\n--- Головне меню ---");
                Console.WriteLine("1. Показати меню ресторану");
                Console.WriteLine("2. Створити нове замовлення");
                Console.WriteLine("3. Додати позицію до замовлення");
                Console.WriteLine("4. Видалити позицію з замовлення");
                Console.WriteLine("5. Показати всі замовлення");
                Console.WriteLine("6. Вийти");

                Console.Write("Виберіть опцію: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        restaurant.Menu.PrintMenu();
                        break;

                    case "2":
                        Console.WriteLine("Введіть номер столика:");
                        int tableNumber = int.Parse(Console.ReadLine());
                        var order = restaurant.CreateOrder(tableNumber);
                        Console.WriteLine($"Створено замовлення з ID: {order.Id} для столика №{tableNumber}");
                        break;

                    case "3":
                        Console.WriteLine("Введіть ID замовлення:");
                        int orderIdToAdd = int.Parse(Console.ReadLine());
                        var orderToAdd = restaurant.GetOrder(orderIdToAdd);
                        if (orderToAdd == null)
                        {
                            Console.WriteLine("Замовлення не знайдено.");
                            break;
                        }
                        Console.WriteLine("Введіть ID позиції меню для додавання:");
                        int menuItemIdToAdd = int.Parse(Console.ReadLine());
                        var menuItemToAdd = restaurant.Menu.Find(menuItemIdToAdd);
                        if (menuItemToAdd == null)
                        {
                            Console.WriteLine("Позиція меню не знайдена.");
                            break;
                        }
                        orderToAdd.AddItem(menuItemToAdd);
                        Console.WriteLine("Позиція додана до замовлення.");
                        break;

                    case "4":
                        Console.WriteLine("Введіть ID замовлення:");
                        int orderIdToRemove = int.Parse(Console.ReadLine());
                        var orderToRemove = restaurant.GetOrder(orderIdToRemove);
                        if (orderToRemove == null)
                        {
                            Console.WriteLine("Замовлення не знайдено.");
                            break;
                        }
                        orderToRemove.PrintItems();
                        Console.WriteLine("Введіть номер позиції для видалення:");
                        int itemIndexToRemove = int.Parse(Console.ReadLine()) - 1;
                        if (orderToRemove.RemoveItem(itemIndexToRemove))
                        {
                            Console.WriteLine("Позиція видалена з замовлення.");
                        }
                        else
                        {
                            Console.WriteLine("Невірний номер позиції.");
                        }
                        break;

                    case "5":
                        var allOrders = restaurant.GetAllOrders();
                        foreach (var ord in allOrders)
                        {
                            Console.WriteLine($"\n--- Замовлення ID: {ord.Id}, Столик №{ord.TableNumber}, Статус: {ord.Status} ---");
                            ord.PrintItems();
                            Console.WriteLine($"Загальна вартість: {ord.TotalPrice} грн");
                        }
                        break;

                    case "6":
                        working = false;
                        break;

                    default:
                        Console.WriteLine("Невірна опція. Спробуйте ще раз.");
                        break;
                }
            }
            Console.WriteLine("Дякуємо за використання системи замовлень ресторану!");
        }
    }
}
