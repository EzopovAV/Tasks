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

        private List<int> _listBatchIdIsCompleted = new List<int>();
        private List<int> _listBatchIdIsNotCompleted = new List<int>();

        public ProblemSolver(ItemDataProvider itemsDataProvider, BatchDataProvider batchesDataProvider)
        {
            _itemsDataProvider = itemsDataProvider;
            _batchesDataProvider = batchesDataProvider;
        }

        private bool CheckIsCompletedBatchById(int batchId)
        {
            if (_listBatchIdIsCompleted.Contains(batchId)) return true;

            if (_listBatchIdIsNotCompleted.Contains(batchId)) return false;

            if (_batchesDataProvider.GetById(batchId).IsCompleted)
            {
                _listBatchIdIsCompleted.Add(batchId);
                return true;
            }
            else
            {
                _listBatchIdIsNotCompleted.Add(batchId);
                return false;
            }
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
                    while (!CheckIsCompletedBatchById(_itemsEnumerator.Current.BatchId))
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
