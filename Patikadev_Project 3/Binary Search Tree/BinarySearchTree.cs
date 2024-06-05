using System;
namespace Binary_Search_Tree
{
    /// <summary>
    /// Ağaç Sınıfı
    /// </summary>
    public class BinarySearchTree
    {
        public Node? root; // Kök

        public int step = 0;

        /// <summary>
        /// Default Yapıcı Metot
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
        }

        /// <summary>
        /// Ağaca yeni eleman eklemesinden sorumludur
        /// <example>
        /// Kullanım:
        /// <code>
        /// var searchTree = new BinarySearchTree();
        /// searchTree.Insert(7);
        /// </code>
        /// </example>
        /// </summary>
        public void Insert(int key)
        {
            step++;
            root = InsertNode(root, key);
        }

        /// <summary>
        /// Recursive node ekleme işlemidir
        /// </summary>
        /// <param name="node">Düğüm Instance</param>
        /// <param name="key">Eklenecek Değer</param>
        /// <returns></returns>
        public Node InsertNode(Node? node, int key)
        {
            if (node == null)
            {
                node = new Node(key);
                return node;
            }

            // Kök'ün sağına veya soluna bakma işlemleri
            // Sağ tarafında kendinden büyük, sol tarafında kendinden küçük elemanlar yerleştirilir.
            if (key < node.data)
            {
                node.left = InsertNode(node.left, key); // Yinelemeli sola ekleme işlemi

                Console.WriteLine($"Aşama {step}: {key} < {node.data} için {node.data} soluna eklenir.");
            }
            else if (key > node.data)
            {
                node.right = InsertNode(node.right, key); // Yinelemeli sağa ekleme işlemi

                Console.WriteLine($"Aşama {step}: {key} < {node.data} için {node.data} sağına eklenir.");
            }

            return node;
        }

        /// <summary>
        /// Belirli bir anahtarı ve kök düğümünü arayan metot
        /// </summary>
        /// <param name="key">Aranacak Değer</param>
        /// <returns></returns>
        public (Node?, Node?) Search(int key)
        {
            return SearchNode(root, null, key);
        }

        /// <summary>
        /// Recursive arama işlemi
        /// </summary>
        /// <param name="node">Düğüm Instance</param>
        /// <param name="parent">Ebeveyn Düğüm</param>
        /// <param name="key">Aranacak Değer</param>
        /// <returns></returns>
        public (Node?, Node?) SearchNode(Node? node, Node? parent, int key)
        {
            // Mevcut düğüm var mı?
            if (node == null)
            {
                return (null, parent);
            }

            if (node.data == key)
            {
                // Anahtar mevcut düğümün verisine eşitse
                return (node, parent);
            }

            if (key < node.data)
            {
                // Sol küçük taraf kontrolü
                return SearchNode(node.left, node, key);
            }
            else
            {
                // Sağ büyük taraf kontrolü
                return SearchNode(node.right, node, key);
            }
        }
        /// <summary>
        /// Ağacı metin olarak yazdıran metot
        /// </summary>
        /// <param name="node">Başlangıç düğümü</param>
        /// <param name="indent">Girinti seviyesi</param>
        /// <param name="last">Son düğüm olup olmadığı</param>
    }
}
