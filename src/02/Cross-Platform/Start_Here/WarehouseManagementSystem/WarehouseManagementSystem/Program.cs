using WarehouseManagementSystem.Business;
using WarehouseManagementSystem.Domain;


public class WarehouseManagement
{

	static void Main(string[] args)
	{
		var order = new Order();
		Action<Order> SendMessageToWarehouse = (_) =>
			Console.WriteLine($"Please pack the order {order.OrderNumber}.");

		SendMessageToWarehouse += SendConfirmationEmail;
		SendMessageToWarehouse += SendConfirmationEmail;
		SendMessageToWarehouse += (_) => Console.WriteLine($"Poop on me with orer number{order.OrderNumber}");

		SendMessageToWarehouse?.Invoke(order);

		var processor = new OrderProcessor
		{
			OnOrderInitialized = SendMessageToWarehouse,
		};


	 	Action<Order> onCompleted  = (order) =>
		{
			Console.WriteLine($"Processed {order.OrderNumber}");
		};

		processor.Process(order);


		void SendConfirmationEmail(Order order)
		{
			Console.WriteLine($"Order Confirmation Email for order {order.OrderNumber}.");
		}
	}
}
