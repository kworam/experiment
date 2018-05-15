using System;
using System.Collections.Generic;
using System.Text;
using Experiment.Tree;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExperimentUnitTest.Tree
{
    [TestClass]
    public class TreeUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(Experiment.Tree.KeyNotFoundException))]
        public void EmptyTreeLookup()
        {
            KevinBst<string> stringTree = new KevinBst<string>();
            int key = 0;
            stringTree.Lookup(key);
        }

        [TestMethod]
        [ExpectedException(typeof(Experiment.Tree.KeyNotFoundException))]
        public void EmptyTreeRemove()
        {
            KevinBst<string> stringTree = new KevinBst<string>();
            int key = 0;
            stringTree.Remove(key);
        }

        [TestMethod]
        public void SingletonTreeSuccessfulLookup()
        {
            KevinBst<string> stringTree = new KevinBst<string>();
            int key = 20;
            string value = key.ToString();
            stringTree.Insert(key, value);
            Assert.AreEqual(stringTree.Lookup(key), value);
        }

        [TestMethod]
        [ExpectedException(typeof(Experiment.Tree.KeyNotFoundException))]
        public void SingletonTreeFailedLookup()
        {
            KevinBst<string> stringTree = new KevinBst<string>();
            int key = 20;
            string value = key.ToString();
            stringTree.Insert(key, value);
            stringTree.Lookup(key + 1);
        }

        [TestMethod]
        public void TestTreeToString()
        {
            KevinBst<string> testTree = BuildTestTree();
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveLeftChildLeafNode()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 5);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveRightChildLeafNode()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 15);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveLeftChildOnlyHasLeftChild()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 15);
            // now 10 only has left child 5
            testTree.Remove(key: 10);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveLeftChildOnlyHasRightChild()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 5);
            // now 10 only has right child 15
            testTree.Remove(key: 10);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveRightChildOnlyHasLeftChild()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 35);
            // now 30 only has left child 25
            testTree.Remove(key: 30);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveRightChildOnlyHasRightChild()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 25);
            // now 30 only has right child 35
            testTree.Remove(key: 30);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        [TestMethod]
        public void RemoveRoot()
        {
            KevinBst<string> testTree = BuildTestTree();
            testTree.Remove(key: 20);
            IVisitor<string> visitor = new StringBuilderVisitor();
            testTree.TraverseInOrder(visitor);
            Console.WriteLine(visitor.ToString());
        }

        private KevinBst<string> BuildTestTree()
        {
            KevinBst<string> bst = new KevinBst<string>();
            List<int> keys = new List<int>()
            {
                20,
                10,
                30,
                5,
                15,
                25,
                35
            };
            foreach (int key in keys)
            {
                bst.Insert(key, key.ToString());
            }

            return bst;
        }

        private class StringBuilderVisitor : IVisitor<string>
        {
            private StringBuilder sb = new StringBuilder();
            public void Visit(INode<string> node, int depth)
            {
                for (int i = 0; i < depth; i++)
                {
                    sb.Append("-");
                }
                sb.AppendLine(string.Format("key={0}, data={1}", node.Key, node.Data));
            }

            public override string ToString()
            {
                return sb.ToString();
            }
        }
    }
}
