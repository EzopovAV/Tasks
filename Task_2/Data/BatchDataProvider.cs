using System;
using System.Collections.Generic;
using System.Threading;
using Task_2.Models;

namespace Task_2.Data
{
    public sealed class BatchDataProvider : IDataProvider<Batch, int>
    {
        public IEnumerable<Batch> GetAll()
        {
            SetupConnection();  // pretend as to work with DB
            for (var i = 1; i < Utils.BatchesCount; i++)
            {
                yield return new Batch
                {
                    Id = i,
                    IsCompleted = Utils.GenerateIsCompletedByBatchId(i)
                };
            }
        }

        public Batch GetById(int key)
        {
            if (key <= 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            SetupConnection();  // pretend as to work with DB
            return new Batch
            {
                Id = key,
                IsCompleted = Utils.GenerateIsCompletedByBatchId(key)
            };
        }

        private void SetupConnection()
        {
            //Thread.Sleep(100);
        }
    }
}
