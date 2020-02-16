using System;
using Task_2;
using Task_2.Data;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ProblemSolver service = new ProblemSolver(new ItemDataProvider(), new BatchDataProvider());
            var items = service.GetItemsForCompletedBatches(20);

            Console.WriteLine("Items for completed batches:");
            foreach(var item in items)
            {
                Console.WriteLine("Id = {0}, Name = {1}, BatchId = {2}", item.Id, item.Name, item.BatchId);
            }

            items = service.GetItemsForCompletedBatches(20);

            Console.WriteLine("Items for completed batches:");
            foreach (var item in items)
            {
                Console.WriteLine("Id = {0}, Name = {1}, BatchId = {2}", item.Id, item.Name, item.BatchId);
            }
            Console.ReadLine();
        }
    }
}
