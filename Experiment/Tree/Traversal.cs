namespace Experiment.Tree
{
    internal static class Traversal<T>
    {
        internal static void InOrder(INode<T> node, int depth, IVisitor<T> visitor)
        {
            if (node == null)
            {
                return;
            }

            InOrder(node.Left, depth + 1, visitor);
            visitor.Visit(node, depth);
            InOrder(node.Right, depth + 1, visitor);
        }
    }
}
