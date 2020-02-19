using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task_2.Data;
using Task_2.Models;
using Task_2.Test.DataForTest;

namespace Task_2.Test
{
    [TestClass]
    public class ProblemSolverTest
    {
        [TestMethod]
        public void GetItemsForCompletedBatches_limit_100()
        {
            int limit = 100;
            ProblemSolver service = new ProblemSolver(new ItemDataProvider(), new BatchDataProvider());
            var resultItems = service.GetItemsForCompletedBatches(limit);
            int count = 0;
            foreach (var item in resultItems)
            {
                count++;
            }
            Assert.AreEqual(limit, count);
        }
        [TestMethod]
        public void GetItemsForCompletedBatches_limit_101()
        {
            int limit = 101;
            ProblemSolver service = new ProblemSolver(new ItemDataProvider(), new BatchDataProvider());
            var resultItems = service.GetItemsForCompletedBatches(limit);
            int count = 0;
            foreach (var item in resultItems)
            {
                count++;
            }
            Assert.AreEqual(limit, count);
        }

        [TestMethod]
        public void GetItemsForCompletedBatches_fromTestBD1()
        {
            var batchDataProviderForTest = new BatchDataProviderForTest(new Batch[]
                {
                    new Batch { Id = 1, IsCompleted = true },
                    new Batch { Id = 2, IsCompleted = false },
                    new Batch { Id = 3, IsCompleted = false },
                    new Batch { Id = 4, IsCompleted = true }
                });

            var itemDataProviderForTest = new ItemDataProviderForTest(new Item[]
                {
                    new Item { Id = 1, Name = "Item_1", BatchId = 1},
                    new Item { Id = 2, Name = "Item_2", BatchId = 2},
                    new Item { Id = 3, Name = "Item_3", BatchId = 1},
                    new Item { Id = 4, Name = "Item_4", BatchId = 2},
                    new Item { Id = 5, Name = "Item_5", BatchId = 4},
                    new Item { Id = 6, Name = "Item_6", BatchId = 1},
                    new Item { Id = 7, Name = "Item_7", BatchId = 3},
                    new Item { Id = 8, Name = "Item_8", BatchId = 3},
                    new Item { Id = 9, Name = "Item_9", BatchId = 4}
                });

            int limit = 2;

            var expectItems = new Item[]
                {
                    new Item { Id = 1, Name = "Item_1", BatchId = 1},
                    new Item { Id = 3, Name = "Item_3", BatchId = 1}
                };

            ProblemSolver service = new ProblemSolver(itemDataProviderForTest, batchDataProviderForTest);

            var resultItems = service.GetItemsForCompletedBatches(limit);

            Assert.IsTrue(expectItems.Select(x => x.Id).SequenceEqual(resultItems.Select(x => x.Id)));
        }

        [TestMethod]
        public void GetItemsForCompletedBatches_fromTestBD2()
        {
            var batchDataProviderForTest = new BatchDataProviderForTest(new Batch[]
                {
                    new Batch { Id = 1, IsCompleted = true },
                    new Batch { Id = 2, IsCompleted = false },
                    new Batch { Id = 3, IsCompleted = false },
                    new Batch { Id = 4, IsCompleted = false },
                    new Batch { Id = 5, IsCompleted = false },
                    new Batch { Id = 6, IsCompleted = false },
                    new Batch { Id = 7, IsCompleted = true }
                });

            var itemDataProviderForTest = new ItemDataProviderForTest(new Item[]
                {
                    new Item { Id = 1, Name = "Item_1", BatchId = 1},
                    new Item { Id = 2, Name = "Item_2", BatchId = 2},
                    new Item { Id = 3, Name = "Item_3", BatchId = 1},
                    new Item { Id = 4, Name = "Item_4", BatchId = 2},
                    new Item { Id = 5, Name = "Item_5", BatchId = 4},
                    new Item { Id = 6, Name = "Item_6", BatchId = 1},
                    new Item { Id = 7, Name = "Item_7", BatchId = 3},
                    new Item { Id = 8, Name = "Item_8", BatchId = 3},
                    new Item { Id = 10, Name = "Item_10", BatchId = 5},
                    new Item { Id = 11, Name = "Item_11", BatchId = 5},
                    new Item { Id = 12, Name = "Item_12", BatchId = 5},
                    new Item { Id = 13, Name = "Item_13", BatchId = 6},
                    new Item { Id = 20, Name = "Item_20", BatchId = 7},
                    new Item { Id = 23, Name = "Item_23", BatchId = 3},
                    new Item { Id = 9, Name = "Item_9", BatchId = 4}
                });

            int limit = 20;

            var expectItems = new Item[]
                {
                    new Item { Id = 1, Name = "Item_1", BatchId = 1},
                    new Item { Id = 3, Name = "Item_3", BatchId = 1},
                    new Item { Id = 6, Name = "Item_6", BatchId = 1},
                    new Item { Id = 20, Name = "Item_20", BatchId = 7}
                };

            ProblemSolver service = new ProblemSolver(itemDataProviderForTest, batchDataProviderForTest);

            var resultItems = service.GetItemsForCompletedBatches(limit);

            Assert.IsTrue(expectItems.Select(x => x.Id).SequenceEqual(resultItems.Select(x => x.Id)));
        }

        [TestMethod]
        public void GetItemsForCompletedBatches_limit_lessThan1()
        {
            int limit = -7;
            ProblemSolver service = new ProblemSolver(new ItemDataProvider(), new BatchDataProvider());
            
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => service.GetItemsForCompletedBatches(limit).First());
        }
    }
}
