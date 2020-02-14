using System;

namespace Task_2.Data
{
	static class Utils
	{
		private const int ProblemSize = 1000000;
		private static readonly Random Rnd = new Random();

		internal static readonly int ItemsCount = ProblemSize;
		internal static readonly int BatchesCount = ProblemSize;

		private static readonly int Shifting = Rnd.Next(BatchesCount / 2);

		internal static int GenerateBatchIdByItemId(int itemId)
		{
			return (itemId + Shifting) % BatchesCount;
		}

		internal static bool GenerateIsCompletedByBatchId(int batchId)
		{
			return batchId % 7 == 0 || batchId % 13 == 0;
		}
	}
}
