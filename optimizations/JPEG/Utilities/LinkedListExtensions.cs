using System;
using System.Collections.Generic;
using System.Linq;

namespace JPEG.Utilities
{
	static class LinkedListExtensions
	{
		public static LinkedListNode<T> FindNodeWithMin<T>(this LinkedList<T> list, Func<T, int> selector)
		{
			var minVal = int.MaxValue;
			var minEl = (LinkedListNode<T>) null;
			var currentNode = list.First;

			while (currentNode is not null)
			{
				var selectedVal = selector(currentNode.Value);
				if (selectedVal <= minVal)
				{
					minEl = currentNode;
					minVal = selectedVal;
				}
				
				currentNode = currentNode.Next;
			}

			return minEl;
		}
	}
}