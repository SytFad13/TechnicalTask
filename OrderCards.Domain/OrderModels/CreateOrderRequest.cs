using OrderCards.Domain.PersonModels;
using System.ComponentModel.DataAnnotations;

namespace OrderCards.Domain.OrderModels
{
	public class CreateOrderRequest
	{
		private DateTime _orderDate;
		[Key]
		public DateTime OrderDate
		{
			get
			{
				return _orderDate;
			}
			set
			{
				_orderDate = DateTime.Now;
			}
		}
		public DateTime DeliveryDate { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public Person Person { get; set; }
	}
}
