using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceOrder
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //15,24 x 15,24 x 10,16cm
            //6"x6"x4"x
        }
    }


    #region .: Services :.

    public interface IOrderService
    {
        IEnumerable<Item> GetPriorityOrders();
        IEnumerable<Order> GetOrders(bool AutomaticallyProcessed);
    }

    #endregion

    #region .: Domain :.

    public class Order
    {
        private bool CanBeProcessed { get; set; }
        private DateTime DateCreated { get; set; }
        private Location Location { get; set; }
        private List<Item> Items { get; set; }

        public Order()
        {

        }

        public class OrderBuilder
        {
            private readonly Order _order = new Order();

            public OrderBuilder Order(DateTime? dateCreated, Location location = Location.NonUsLocation)
            {
                _order.DateCreated = dateCreated ?? DateTime.Now;
                _order.Location = location;
                _order.Items = new List<Item>();
                _order.CanBeProcessed = location == Location.UsLocation ? true : false;
                return this;
            }

            public OrderBuilder AddItem(Item item)
            {
                _order.Items.Add(item);
                return this;
            }

            public OrderBuilder AddRange(List<Item> items)
            {
                _order.Items.AddRange(items);
                return this;
            }

            public Order Build()
            {
                return _order;
            }
        }
    }

    public class Item
    {
        public bool CanBeShipped { get; private set; }
        public Lazy<List<Item>> DependentItems { get; private set; }
        public DependentItemStatus DependentItemStatus { get; private set; }

        public Item(DependentItemStatus dependentItemStatus = DependentItemStatus.NotDependent)
        {
            DependentItemStatus = dependentItemStatus;
            DependentItemsCanBeShipped();
        }

        public void AddDependentItem(Item item)
        {
            this.DependentItems.Value.Add(item);
        }

        public void AddDependentItemRange(List<Item> items)
        {
            this.DependentItems.Value.AddRange(items);
        }

        private void DependentItemsCanBeShipped()
        {
            if (this.DependentItems != null)
            {
                var allItemsAreAllowdToDispatch = this.DependentItems.Value.Any(x => x.CanBeShipped == false);
                if (allItemsAreAllowdToDispatch)
                {
                    if (DependentItemStatus == DependentItemStatus.NotDependent)
                        CanBeShipped = true;
                    else
                        CanBeShipped = false;
                }
                else
                {
                    CanBeShipped = true;
                }
            }
            else
            {
                this.DependentItems = new Lazy<List<Item>>();
            }
        }
    }

    public enum Location
    {
        UsLocation,
        NonUsLocation
    }

    public enum DependentItemStatus
    {
        Dependent,
        NotDependent
    }

    #endregion
}
