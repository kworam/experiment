namespace Experiment.Tree
{
    public interface IVisitor<T>
    {
        void Visit(INode<T> node, int depth);
    }
}
