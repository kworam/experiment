namespace Experiment.Tree
{
    public class KevinNode<T> : INode<T>
    {
        public INode<T> Left { get; set; }
        public INode<T> Right { get; set; }
        public int Key { get; set; }
        public T Data { get; set;  }

        public KevinNode(int key, T data)
        {
            this.Key = key;
            this.Data = data;
        }

        public bool IsLeaf()
        {
            return this.Left == null && this.Right == null;
        }

        public override string ToString()
        {
            return this.Key.ToString();
        }
    }
}
