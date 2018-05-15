namespace Experiment.Tree
{
    public interface INode<T>
    {
        INode<T> Left { get; set; }
        INode<T> Right { get; set; }
        int Key { get; set; }
        T Data { get; set; }
        bool IsLeaf();
    }
}
