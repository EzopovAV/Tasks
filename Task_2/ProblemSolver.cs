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

			throw new NotImplementedException();
        }
    }
}
