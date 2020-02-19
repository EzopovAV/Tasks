using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Data;
using Task_2.Models;

namespace Task_2.Test.DataForTest
{
    public class BatchDataProviderForTest : IDataProvider<Batch, int>
    {
        private IEnumerable<Batch> _batchs;

        public BatchDataProviderForTest(IEnumerable<Batch> batchs)
        {
            _batchs = batchs;
        }

        public IEnumerable<Batch> GetAll()
        {
            foreach (var batch in _batchs)
            {
                yield return batch;
            }
        }

        public Batch GetById(int key)
        {
            return _batchs.Single<Batch>(b => b.Id == key);
        }
    }

}
