using System;

namespace TAFESA_Enrolment_System.DataStructures
{
    /// <summary>
    /// Node for a binary search tree
    /// </summary>
    /// <typeparam name="T">Any comparable type</typeparam>
    public class Node<T> where T : IComparable<T>
    {
        /// <summary>Value stored in this node</summary>
        public T Data { get; set; }

        /// <summary>Left child (values less than Data)</summary>
        public Node<T>? LeftNode { get; set; }

        /// <summary>Right child (values greater than Data)</summary>
        public Node<T>? RightNode { get; set; }

        /// <summary>
        /// No-arg constructor
        /// </summary>
        public Node() { }

        /// <summary>
        /// Construct with a value
        /// </summary>
        public Node(T data)
        {
            Data = data;
        }
    }

    /// <summary>
    /// Binary search tree
    /// </summary>
    /// <typeparam name="T">Any comparable type</typeparam>
    public class BinaryTree<T> where T : IComparable<T>
    {
        /// <summary>Tree root (null when empty)</summary>
        public Node<T>? Root { get; set; }

        /// <summary>
        /// Add a value to the BST (returns false if duplicate)
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// before = null
        /// after = Root
        /// while after != null:
        ///   before = after
        ///   if value < after.Data: after = after.LeftNode
        ///   else if value > after.Data: after = after.RightNode
        ///   else: return false
        /// newNode = Node(value)
        /// if Root == null: Root = newNode
        /// else if value < before.Data: before.LeftNode = newNode
        /// else: before.RightNode = newNode
        /// return true
        /// </remarks>
        public bool Add(T value)
        {
            // track the last non-null node visited
            Node<T>? before = null;

            // walker starting from root
            Node<T>? after = Root;

            // walk down until we hit a null slot
            while (after != null)
            {
                before = after;

                if (value.CompareTo(after.Data) < 0)
                {
                    // go left
                    after = after.LeftNode;
                }
                else if (value.CompareTo(after.Data) > 0)
                {
                    // go right
                    after = after.RightNode;
                }
                else
                {
                    // duplicate
                    return false;
                }
            }

            // make the new node
            var newNode = new Node<T>(value);

            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                // attach under 'before'
                if (value.CompareTo(before!.Data) < 0)
                {
                    before.LeftNode = newNode;
                }
                else
                {
                    before.RightNode = newNode;
                }
            }

            return true;
        }

        /// <summary>
        /// Find a node by value starting from root (returns null if not found)
        /// </summary>
        public Node<T>? Find(T value)
        {
            return Find(value, Root);
        }

        /// <summary>
        /// Recursive find starting from a selected parent node
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// if parent == null: return null
        /// if value == parent.Data: return parent
        /// if value < parent.Data: return Find(value, parent.LeftNode)
        /// else: return Find(value, parent.RightNode)
        /// </remarks>
        private Node<T>? Find(T value, Node<T>? parent)
        {
            if (parent != null)
            {
                if (value.CompareTo(parent.Data) == 0)
                {
                    return parent;
                }

                if (value.CompareTo(parent.Data) < 0)
                {
                    // search left
                    return Find(value, parent.LeftNode);
                }

                // search right
                return Find(value, parent.RightNode);
            }

            // not found
            return null;
        }

        /// <summary>
        /// Remove a value from the tree, starting from root
        /// </summary>
        public void Remove(T value)
        {
            Root = Remove(Root, value);
        }

        /// <summary>
        /// Recursive remove; returns the (possibly new) subtree root
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// if parent == null: return parent
        /// cmp = key.CompareTo(parent.Data)
        /// if cmp < 0: parent.LeftNode = Remove(parent.LeftNode, key)
        /// else if cmp > 0: parent.RightNode = Remove(parent.RightNode, key)
        /// else:
        ///   if parent.LeftNode == null: return parent.RightNode
        ///   if parent.RightNode == null: return parent.LeftNode
        ///   parent.Data = MinValue(parent.RightNode)
        ///   parent.RightNode = Remove(parent.RightNode, parent.Data)
        /// return parent
        /// </remarks>
        private Node<T>? Remove(Node<T>? parent, T key)
        {
            if (parent == null)
            {
                return parent;
            }

            int cmp = key.CompareTo(parent.Data);

            if (cmp < 0)
            {
                // go left
                parent.LeftNode = Remove(parent.LeftNode, key);
            }
            else if (cmp > 0)
            {
                // go right
                parent.RightNode = Remove(parent.RightNode, key);
            }
            else
            {
                // found it

                // case: 0 or 1 child on the left
                if (parent.LeftNode == null)
                {
                    return parent.RightNode;
                }

                // case: 1 child on the right
                if (parent.RightNode == null)
                {
                    return parent.LeftNode;
                }

                // case: 2 children
                // replace with inorder successor (smallest in right subtree)
                parent.Data = MinValue(parent.RightNode);

                // delete that successor from the right subtree
                parent.RightNode = Remove(parent.RightNode, parent.Data);
            }

            return parent;
        }

        /// <summary>
        /// Smallest value in a (non-null) subtree
        /// </summary>
        /// <remarks>
        /// Pseudocode=
        /// current = node
        /// while current.LeftNode != null:
        ///   current = current.LeftNode
        /// return current.Data
        /// </remarks>
        private T MinValue(Node<T> node)
        {
            // walk left until we can't
            var current = node;
            while (current.LeftNode != null)
            {
                current = current.LeftNode;
            }

            return current.Data;
        }

        /// <summary>
        /// Get the depth/height of the tree from root
        /// </summary>
        public int GetTreeDepth()
        {
            return GetTreeDepth(Root);
        }

        /// <summary>
        /// Get the depth/height from a selected node
        /// </summary>
        private int GetTreeDepth(Node<T>? current)
        {
            return current == null
                ? 0
                : Math.Max(GetTreeDepth(current.LeftNode), GetTreeDepth(current.RightNode)) + 1;
        }

        /// <summary>
        /// Preorder traverse (Node, Left, Right)
        /// </summary>
        public void TraversePreOrder(Node<T>? parent)
        {
            if (parent != null)
            {
                Console.Write(parent.Data + " ");
                TraversePreOrder(parent.LeftNode);
                TraversePreOrder(parent.RightNode);
            }
        }

        /// <summary>
        /// Inorder traverse (Left, Node, Right)
        /// </summary>
        public void TraverseInOrder(Node<T>? parent)
        {
            if (parent != null)
            {
                TraverseInOrder(parent.LeftNode);
                Console.Write(parent.Data + " ");
                TraverseInOrder(parent.RightNode);
            }
        }

        /// <summary>
        /// Postorder traverse (Left, Right, Node)
        /// </summary>
        public void TraversePostOrder(Node<T>? parent)
        {
            if (parent != null)
            {
                TraversePostOrder(parent.LeftNode);
                TraversePostOrder(parent.RightNode);
                Console.Write(parent.Data + " ");
            }
        }
    }
}
