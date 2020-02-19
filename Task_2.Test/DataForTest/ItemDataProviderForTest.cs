using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Test.DataForTest
{
    public class ItemDataProviderForTest : IDataProvider<Item, int>
    {
        private IEnumerable<Item> _items;

        public ItemDataProviderForTest(IEnumerable<Item> items)
        {
            _items = items;
        }

        public IEnumerable<Item> GetAll()
        {
            foreach (var item in _items)
            {
                yield return item;
            }
        }

        public Item GetById(int key)
        {
            return _items.Single<Item>(i => i.Id == key);
        }
    }
}
