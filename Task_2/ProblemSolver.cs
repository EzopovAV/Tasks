using System;
using System.Collections.Generic;
using Task_2.Data;
using Task_2.Models;

namespace Task_2
{
    public class ProblemSolver
    {
        private readonly ItemDataProvider _itemsDataProvider;
        private readonly BatchDataProvider _batchesDataProvider;

        public ProblemSolver(ItemDataProvider itemsDataProvider, BatchDataProvider batchesDataProvider)
        {
            _itemsDataProvider = itemsDataProvider;
            _batchesDataProvider = batchesDataProvider;
        }

        public IEnumerable<Item> GetItemsForCompletedBatches(int limit)
        {
            // TODO: add code
            
            var itemsEnumerator = _itemsDataProvider.GetAll().GetEnumerator();

            for (int i = 0; i < limit; i++)
            {
                if (itemsEnumerator.MoveNext())
                {
                    while (!_batchesDataProvider.GetById(itemsEnumerator.Current.BatchId).IsCompleted)
                    {
                        if (!itemsEnumerator.MoveNext())
                        {
                            yield break;
                        }
                    }
                    yield return itemsEnumerator.Current;
                }
                else
                {
                    yield break;
                }
            }

            //throw new NotImplementedException();
        }
    }
}
