using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    /// <summary>
    /// Düğüm Sınıfı
    /// </summary>
    public class Node
    {
        public int data;
        public Node? left, right;

        public Node(int item)
        {
            data = item;
            left = right = null;
        }
    }
}
