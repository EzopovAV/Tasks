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

        private bool? _allBatchesIsNotCompleted;
        private IEnumerator<Item> _itemsEnumerator;

        public ProblemSolver(ItemDataProvider itemsDataProvider, BatchDataProvider batchesDataProvider)
        {
            _itemsDataProvider = itemsDataProvider;
            _batchesDataProvider = batchesDataProvider;
        }

        private void CheckForAllBatchesIsNotCompleted()
        {
            _allBatchesIsNotCompleted = true;
            foreach (var batch in _batchesDataProvider.GetAll())
            {
                if (batch.IsCompleted)
                {
                    _allBatchesIsNotCompleted = false;
                    break;
                }
            }
        }

        public IEnumerable<Item> GetItemsForCompletedBatches(int limit)
        {
            // TODO: add code
            if (_allBatchesIsNotCompleted == null) CheckForAllBatchesIsNotCompleted();

            if (_allBatchesIsNotCompleted == true) yield break;

            if (_itemsEnumerator == null) _itemsEnumerator = _itemsDataProvider.GetAll().GetEnumerator();

            for (int i = 0; i < limit; i++)
            {
                if (_itemsEnumerator.MoveNext())
                {
                    while (!_batchesDataProvider.GetById(_itemsEnumerator.Current.BatchId).IsCompleted)
                    {
                        if (!_itemsEnumerator.MoveNext())
                        {
                            _itemsEnumerator.Reset();
                            yield break;
                        }
                    }
                    yield return _itemsEnumerator.Current;
                }
                else
                {
                    _itemsEnumerator.Reset();
                    yield break;
                }
            }

            //throw new NotImplementedException();
        }
    }
}
