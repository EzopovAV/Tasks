using System;
using System.Collections.Generic;
using Task_2.Data;
using Task_2.Models;

namespace Task_2
{
    public class ProblemSolver
    {
        private readonly IDataProvider<Item, int> _itemsDataProvider;
        private readonly IDataProvider<Batch, int> _batchesDataProvider;

        private bool? _allBatchesIsNotCompleted;

        private List<int> _listBatchIdIsCompleted;
        private List<int> _listBatchIdIsNotCompleted;

        public ProblemSolver(IDataProvider<Item, int> itemsDataProvider, IDataProvider<Batch, int> batchesDataProvider)
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
            if (limit < 1) throw new ArgumentOutOfRangeException("limit", "Limit cannot be less than 1");

            if (_allBatchesIsNotCompleted == null) CheckForAllBatchesIsNotCompleted();

            if (_allBatchesIsNotCompleted == true) yield break;

            var _itemsEnumerator = _itemsDataProvider.GetAll().GetEnumerator();

            _listBatchIdIsCompleted = new List<int>();
            _listBatchIdIsNotCompleted = new List<int>();

            for (int i = 0; i < limit; i++)
            {
                if (_itemsEnumerator.MoveNext())
                {
                    while (!CheckIsCompletedBatchById(_itemsEnumerator.Current.BatchId))
                    {
                        if (!_itemsEnumerator.MoveNext())
                        {
                            ClearUpResources();
                            yield break;
                        }
                    }
                    yield return _itemsEnumerator.Current;
                }
                else
                {
                    ClearUpResources();
                    yield break;
                }
            }
            //throw new NotImplementedException();
        }

        private void ClearUpResources()
        {
            _listBatchIdIsCompleted = null;
            _listBatchIdIsNotCompleted = null;
        }

    }
}
