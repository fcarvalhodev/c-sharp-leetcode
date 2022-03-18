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
        IEnumerable<Order> GetOrders();
        int GetNumberOfBoxes();
    }

    #endregion

    #region .: Domain :.

    public class Order
    {
        public bool CanBeProcessed { get; private set; }
        public DateTime DateCreated { get; private set; }
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
        private Lazy<List<Item>> DependentItems { get; set; }
        private DependentItemStatus DependentItemStatus { get; set; }
        public float[] Size { get; private set; }

        public Item()
        {
        }

        public class ItemBuilder
        {
            private readonly Item _item = new Item();

            public ItemBuilder Item(DependentItemStatus dependentItemStatus = DependentItemStatus.NotDependent, bool canBeShipped = false)
            {
                this._item.DependentItemStatus = dependentItemStatus;
                this._item.CanBeShipped = canBeShipped;
                this._item.DependentItems = new Lazy<List<Item>>();
                this._item.Size = new float[3];
                return this;
            }

            public ItemBuilder SetItemSize(float[] itemSize)
            {
                if (itemSize.Length != 3)
                    throw new ArgumentException("The 'itemSize' length is invalid", "itemSize");

                this._item.Size = itemSize;

                return this;
            }

            public ItemBuilder AddDependentItem(Item item)
            {
                this._item.DependentItems.Value.Add(item);
                return this;
            }

            public ItemBuilder AddRangeDependentItem(List<Item> items)
            {
                this._item.DependentItems.Value.AddRange(items);
                return this;
            }

            private void DependentItemsCanBeShipped()
            {
                if (this._item.DependentItems.Value.Count > 0)
                {
                    var allItemsAreAllowdToDispatch = this._item.DependentItems.Value.Any(x => x.CanBeShipped == false);
                    if (!allItemsAreAllowdToDispatch)
                    {
                        _item.CanBeShipped = true;
                    }
                    else
                    {
                        if (this._item.DependentItemStatus == DependentItemStatus.NotDependent)
                            _item.CanBeShipped = true;
                        else
                            _item.CanBeShipped = false;
                    }
                }
            }

            public Item Build()
            {
                this.DependentItemsCanBeShipped();
                return _item;
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
