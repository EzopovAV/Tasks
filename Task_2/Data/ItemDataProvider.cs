using System;
using System.Collections.Generic;
using System.Threading;
using Task_2.Models;

namespace Task_2.Data
{
    public sealed class ItemDataProvider : IDataProvider<Item, int>
    {
        public IEnumerable<Item> GetAll()
        {
            SetupConnection();  // pretend as to work with DB
            for (var i = 1; i < Utils.ItemsCount; i++)
            {
                yield return new Item
                {
                    Id = i,
                    Name = "Item_" + i,
                    BatchId = Utils.GenerateBatchIdByItemId(i)
                };
            }
        }

        public Item GetById(int key)
        {
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            SetupConnection();  // pretend as to work with DB
            return new Item
            {
                Id = key,
                Name = "Item_" + key,
                BatchId = Utils.GenerateBatchIdByItemId(key)
            };
        }

        private void SetupConnection()
        {
            //Thread.Sleep(100);
        }
    }
}
