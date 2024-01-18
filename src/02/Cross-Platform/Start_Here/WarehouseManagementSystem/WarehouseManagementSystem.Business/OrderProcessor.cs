using WarehouseManagementSystem.Domain;

namespace WarehouseManagementSystem.Business
{
	public class OrderCreatedEventArgs : EventArgs
	{
		public Order Order {get; set;}
		public decimal OldTotal {get; set;}
		public decimal NewCost {get; set;}
	}

	public class OrderProcessor
	{
		public Action<Order> OnOrderInitialized { get; set; }
		public Action<Order> ProcessCompleted { get; set; }


		public event EventHandler<OrderCreatedEventArgs> OrderCreated;

		private void Initialize(Order order)
		{
			ArgumentNullException.ThrowIfNull(order);
			Console.WriteLine("In here");

		}

		public void Process(Order order)
		{
			Initialize(order);
			OrderCreatedEventArgs args = new()
			{
				NewCost = 80,
				OldTotal = 100,
				Order = order,
			};
			
			OnOrderCreated(args);
			// How do I produce a shipping label?
		}


		protected virtual void OnOrderCreated(OrderCreatedEventArgs args)
		{
			OrderCreated?.Invoke(this, args);
			Console.WriteLine("The order was created");
		}
	}
}
