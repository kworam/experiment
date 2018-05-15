using System.Collections.Generic;

namespace Experiment.ExLinkedList
{
	public class ExLinkedList<T>
	{
		public static Node<T> Reverse(Node<T> node)
		{
			if (node == null)
			{
				return node;
			}

			return InternalReverse(null, node);
		}

		public static Node<T> FromEnumerable(IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				return null;
			}

			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			Node<T> head = null;
			Node<T> prev = null;
			while (enumerator.MoveNext())
			{
				Node<T> current = new Node<T>()
				{
					Data = enumerator.Current,
					Next = null
				};

				if (head == null)
				{
					head = current;
				}

				if (prev != null)
				{
					prev.Next = current;
				}

				prev = current;
			}

			return head;
		}

		public static bool EqualsEnumerable(Node<T> node, IEnumerable<T> enumerable)
		{
			if (enumerable == null)
			{
				return node == null;
			}

			IEnumerator<T> enumerator = enumerable.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (node == null)
				{
					// exlinkedlist is empty, but enumerator is not
					return false;
				}

				if (!enumerator.Current.Equals(node.Data))
				{
					// data of nodes in same position are not equal
					return false;
				}

				node = node.Next;
			}

			if (node != null)
			{
				// enumerator is empty, but exlinkedlist is not
				return false;
			}

			return true;
		}

		private static Node<T> InternalReverse(Node<T> prev, Node<T> current)
		{
			// invariant: prev is the reversed prefix of the list prior to current
			if (current == null)
			{
				return prev;
			}

			Node<T> next = current.Next;
			current.Next = prev;
			return InternalReverse(current, next);
		}

	}
}
