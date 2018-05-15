namespace Experiment.Tree
{
    public interface IBst<T>
    {
        void Insert(int key, T data);
        void Remove(int key);
        T Lookup(int key);
        void TraverseInOrder(IVisitor<T> visitor);
    }
}
