using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace binary_tree
{
    public partial class Form1 : Form
    {
        public BinaryTree tree;
        public Random random;
        public BinaryTree negativeTree;
        public BinaryTree positiveTree;
        public BinaryTree.BPlusTreeNode bPlusRoot;
        private RedBlackNode root;
        public Form1()
        {
            InitializeComponent();
            tree = new BinaryTree();
            random = new Random();
            this.Paint += Form1_Paint;
            radioButton1.Checked = true;
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }
        public int NodeRadius = 14;
        public int FormWidth = 1000;
        public int FormHeight = 500;
        public int NodeRadius11 = 20;
        public int VerticalSpacing = 50;
        private void ClearGraphics()
        {
            using (Graphics graphics = this.CreateGraphics())
            {
                graphics.Clear(this.BackColor); // Очищает графику цветом фона формы
            }
        }
        private void построитьБинарноеДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            ClearGraphics();
            int n = 99; // Количество узлов
            int D_min = -99; // Минимальное значение ключа
            int D_max = 78; // Максимальное значение ключа

            tree.Clear(); // Очистка дерева перед генерацией новых узлов

            for (int i = 0; i < n; i++)
            {
                int key = random.Next(D_min, D_max + 1); // Генерация случайного ключа в указанном диапазоне
                if (key == 0)
                {
                    i--;
                    continue;
                }
                tree.Insert(key); // Вставка узла с сгенерированным ключом в дерево
                GenerateRedBlackTree(root, 6, D_min, D_max); // Генерируем красно-черное дерево с 6 уровнями глубины
            }
            Invalidate();
        }
        private void GenerateRedBlackTree(RedBlackNode parent, int depth, int minKey, int maxKey)
        {
            if (depth <= 0)
                return;

            for (int i = 0; i < 10; i++) // Генерируем 10 узлов на каждом уровне
            {
                int key = random.Next(minKey, maxKey + 1); // Генерация случайного ключа в указанном диапазоне
                if (key == 0)
                {
                    i--;
                    continue;
                }
                RedBlackNode newNode = new RedBlackNode(key); // Создаем новый узел
                RedBlackInsert(ref root, newNode); // Вставляем узел в красно-черное дерево
            }

            // Рекурсивно вызываем этот метод для генерации узлов на следующем уровне
            GenerateRedBlackTree(parent, depth - 1, minKey, maxKey);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawTree(e.Graphics);
        }
        public void DrawTree(Graphics g)
        {
            int levels = 6; // Количество уровней дерева для отображения
            DrawNode(g, tree.GetRootNode(), FormWidth / 2, 50, levels, 1);
        }

        private void DrawNode(Graphics g, TreeNode node, int x, int y, int maxLevels, int currentLevel)
        {
            if (node == null || currentLevel > maxLevels)
                return;

            int offsetX = FormWidth / (int)Math.Pow(2, currentLevel + 1);
            int offsetY = 100;

            // Рисуем текущий узел
            g.FillEllipse(Brushes.Coral, x - NodeRadius, y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
            g.DrawEllipse(Pens.Black, x - NodeRadius, y - NodeRadius, NodeRadius * 2, NodeRadius * 2);
            g.DrawString(node.Value.ToString(), new Font("Arial", 8), Brushes.Black, x - 10, y - 10);

            // Рисуем левого потомка
            if (node.Left != null)
            {
                int leftX = x - offsetX;
                int leftY = y + offsetY;
                g.DrawLine(Pens.Black, x, y + NodeRadius, leftX, leftY - NodeRadius);
                DrawNode(g, node.Left, leftX, leftY, maxLevels, currentLevel + 1);
            }

            // Рисуем правого потомка
            if (node.Right != null)
            {
                int rightX = x + offsetX;
                int rightY = y + offsetY;
                g.DrawLine(Pens.Black, x, y + NodeRadius, rightX, rightY - NodeRadius);
                DrawNode(g, node.Right, rightX, rightY, maxLevels, currentLevel + 1);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
            if (listBox1.SelectedIndex == 0)
            {
                int sum = tree.SumOfElements();
                MessageBox.Show("Сумма всех элементов в бинарном дереве: " + sum.ToString());
            }
            else if (listBox1.SelectedIndex == 1)
            {
                int product = tree.ProductOfElementsDivisibleByThree();
                MessageBox.Show("Произведение всех элементов в бинарном дереве, кратных 3: " + product.ToString());
            }
            else if (listBox1.SelectedIndex == 2)
            {
                List<TreeNode> imbalancedNodes = tree.FindNodesWithImbalancedChildren();

                if (imbalancedNodes.Count > 0)
                {
                    string message = "Вершины с несбалансированными потомками:\n";
                    foreach (var node in imbalancedNodes)
                    {
                        message += node.Value.ToString() + "\n";
                    }
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Все вершины имеют сбалансированные потомки.");
                }
            }
            else if (listBox1.SelectedIndex == 4)
            {
                int x = -8;
                int count = tree.CountOccurrences(x);
                MessageBox.Show($"Количество вхождений элемента {x} в бинарное дерево: {count}");
            }
            else if (listBox1.SelectedIndex == 3)
            {
                List<TreeNode> nodesWithUnequalHeight = tree.FindNodesWithUnequalHeight();

                if (nodesWithUnequalHeight.Count > 0)
                {
                    string message = "Вершины с неравными высотами поддеревьев:\n";
                    foreach (var node in nodesWithUnequalHeight)
                    {
                        message += node.Value.ToString() + "\n";
                    }
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Все вершины имеют равные высоты поддеревьев.");
                }
            }
            else if (listBox1.SelectedIndex == 5)
            {
                (int maxElement, int count) = tree.FindMaxElementAndCount();

                if (count > 0)
                {
                    MessageBox.Show($"Максимальный элемент в дереве: {maxElement}\nКоличество повторений максимального элемента: {count}");
                }
                else
                {
                    MessageBox.Show("Дерево пустое.");
                }
            }
            else if (listBox1.SelectedIndex == 6)
            {
                List<int> duplicates = tree.GetDuplicateElements();

                if (duplicates.Count > 0)
                {
                    string message = "Дублирующиеся элементы в бинарном дереве:\n";
                    foreach (var duplicate in duplicates)
                    {
                        message += duplicate.ToString() + "\n";
                    }
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("В бинарном дереве нет дублирующихся элементов или дерево пустое.");
                }
            }
            else if (listBox1.SelectedIndex == 7)
            {
                tree.FindMaxDuplicateCountAndShowMessage();
            }
            else if (listBox1.SelectedIndex == 8)
            {
                tree.CheckSymmetryAndShowMessage();
            }
            else if (listBox1.SelectedIndex == 9)
            {
                tree.CheckIfBSTAndShowMessage();
            }
            else if (listBox1.SelectedIndex == 10)
            {
                List<int> vertices = tree.TraverseInOrder();
                MessageBox.Show("Вершины дерева в порядке возрастания: " + string.Join(", ", vertices));
            }
            else if (listBox1.SelectedIndex == 11)
            {
                radioButton1.Show();
                radioButton2.Show();
                // Проверяем, инициализированы ли дополнительные деревья
                if (negativeTree == null)
                    negativeTree = new BinaryTree();
                if (positiveTree == null)
                    positiveTree = new BinaryTree();
                // Создаем два дерева из отрицательных и положительных элементов текущего дерева
                var splitTrees = tree.SplitBySign();
                negativeTree = splitTrees.Item1;
                positiveTree = splitTrees.Item2;
                if (radioButton1.Checked == true)
                {
                    groupBox1.Show();
                    groupBox2.Hide();
                }
                else if (radioButton2.Checked == true)
                {
                    groupBox2.Show();
                    groupBox1.Hide();
                }
            }
            else if (listBox1.SelectedIndex == 12)
            {
                int minWeight = int.MaxValue;
                List<int> currentPath = new List<int>();
                List<List<int>> minWeightPaths = new List<List<int>>();
                tree.PrintMinWeightPaths(tree.GetRootNode(), currentPath, minWeightPaths, ref minWeight);
                StringBuilder message = new StringBuilder();
                message.AppendLine("Минимальные пути с суммарным минимальным весом:");
                foreach (var path in minWeightPaths)
                {
                    message.AppendLine(string.Join(" -> ", path));
                }
                MessageBox.Show(message.ToString());
            }
            else if (listBox1.SelectedIndex == 13)
            {
                int lastLevelWithPositiveElements = tree.FindLastLevelWithPositiveElements(tree.GetRootNode(), 1, -1);
                MessageBox.Show($"Последний номер уровня с положительными элементами: {lastLevelWithPositiveElements}");
            }
            else if (listBox1.SelectedIndex == 14)
            {
                List<int> maxValues = tree.FindMaxValuesPerLevel();
                MessageBox.Show("Максимальные элементы на каждом уровне: " + string.Join(", ", maxValues));
            }
            else if (listBox1.SelectedIndex == 15)
            {
                List<string> counts = tree.CountNodesAndLeavesPerLevel();
                MessageBox.Show("Количество внутренних вершин и листьев на каждом уровне:\n" + string.Join("\n", counts));
            }
            else if (listBox1.SelectedIndex == 16)
            {
                int sum = tree.SumOfElementsOddLevels();
                MessageBox.Show("Сумма элементов всех нечетных уровней: " + sum);
            }
            else if (listBox1.SelectedIndex == 17)
            {
                List<int> minPath = tree.FindMinPath();
                List<int> maxPath = tree.FindMaxPath();
                if (minPath.Count > 0 && maxPath.Count > 0)
                {
                    string message = $"Минимальный путь: {string.Join(" -> ", minPath)}\n" +
                                     $"Максимальный путь: {string.Join(" -> ", maxPath)}";
                    MessageBox.Show(message);
                }
                else
                {
                    MessageBox.Show("Бинарное дерево пустое.");
                }
            }
            else if (listBox1.SelectedIndex == 18)
            {
                negativeTree = null;
                positiveTree = null;
                ClearGraphics();

                tree.MakeTreeStrictlyBinary(tree.GetRootNode());
                // Перерисовка дерева на форме
                Invalidate();
            }
        }

        private void инфикснымОбходомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получаем элементы дерева с помощью метода инфиксного обхода
            List<int> elements = tree.TraverseInOrder1();

            // Формируем сообщение со списком элементов
            string message = "Элементы дерева (инфиксный обход):\n";
            message += string.Join(", ", elements);

            // Выводим сообщение на форму
            MessageBox.Show(message);
        }

        private void постфикснымОбходомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получаем элементы дерева с помощью метода постфиксного обхода
            List<int> elements = tree.TraversePostOrder();

            // Формируем сообщение со списком элементов
            string message = "Элементы дерева (постфиксный обход):\n";
            message += string.Join(", ", elements);

            // Выводим сообщение на форму
            MessageBox.Show(message);
        }

        private void префикснымОбходомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Получаем элементы дерева с помощью метода префиксного обхода
            List<int> elements = tree.TraversePreOrder();

            // Формируем сообщение со списком элементов
            string message = "Элементы дерева (префиксный обход):\n";
            message += string.Join(", ", elements);

            // Выводим сообщение на форму
            MessageBox.Show(message);
        }

        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawPositive(e.Graphics);
        }

        private void groupBox2_Paint(object sender, PaintEventArgs e)
        {
            DrawNegative(e.Graphics);
        }
        private void DrawNegative(Graphics g)
        {
            int levels = 6; // Количество уровней дерева для отображения
            // Рисуем дерево с отрицательными элементами
            DrawNode(g, negativeTree.GetRootNode(), FormWidth / 2, 50, levels, 1);
        }
        private void DrawPositive(Graphics g)
        {
            int levels = 6; // Количество уровней дерева для отображения
            // Рисуем дерево с отрицательными элементами
            DrawNode(g, positiveTree.GetRootNode(), FormWidth / 2, 50, levels, 1);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                groupBox2.Show();
                groupBox1.Hide();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                groupBox1.Show();
                groupBox2.Hide();
            }
        }

        private void сделатьBДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Show();
            groupBox4.Hide();
        }

        private void построитьКрасночерноеДеревоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Show();
        }
        private void вывестиЭлементыДереваНаЭкранИспользуяСледующиеОбходыДереваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            radioButton1.Hide();
            radioButton2.Hide();
            groupBox1.Hide();
            groupBox2.Hide();
            groupBox3.Hide();
            groupBox4.Hide();
        }
        private void DrawAdditionalTrees(Graphics g)
        {
            // Преобразуем обычное бинарное дерево в B+ дерево
            bPlusRoot = tree.ConvertToBPlusTree(tree.GetRootNode());

            // Рисуем B+ дерево
            DrawBPlusTree(g, bPlusRoot, 750, 150, 1);
        }

        private void DrawBPlusTree(Graphics g, BinaryTree.BPlusTreeNode node, int x, int y, int level)
        {
            if (node == null)
                return;

            int offsetX = (FormWidth / (int)Math.Pow(2, level + 1)) - 130;
            int offsetY = 200;

            int nodeWidth = 110; // Ширина прямоугольника
            int nodeHeight = 15; // Высота прямоугольника
            Font font = new Font("Arial", 8);

            // Рисуем текущий узел в виде прямоугольника
            g.FillRectangle(Brushes.Cyan, x - nodeWidth / 2, y - nodeHeight / 2, nodeWidth, nodeHeight);
            g.DrawRectangle(Pens.Black, x - nodeWidth / 2, y - nodeHeight / 2, nodeWidth, nodeHeight);
            g.DrawString(string.Join(", ", node.Keys), font, Brushes.Black, x - nodeWidth / 2, y - nodeHeight / 2);

            int childX = x - (node.Children.Count * offsetX) / 2;
            foreach (var child in node.Children)
            {
                g.DrawLine(Pens.Black, x, y + nodeHeight / 2, childX, y + offsetY - nodeHeight / 2);
                DrawBPlusTree(g, child, childX, y + offsetY, level + 1);
                childX += offsetX;
            }
        }

        private void groupBox3_Paint(object sender, PaintEventArgs e)
        {
            DrawAdditionalTrees(e.Graphics);
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            int maxLevel = 6; // Ограничение на отображение уровней
            DrawRedBlackTree(root, e.Graphics, ClientSize.Width / 2, 50, ClientSize.Width / 4, 1, maxLevel);
        }
        private void RedBlackInsert(ref RedBlackNode root, RedBlackNode node)
        {
            RedBlackNode current = root;
            RedBlackNode parent = null;

            // Поиск места для вставки нового узла
            while (current != null)
            {
                parent = current;
                if (node.Key < current.Key)
                    current = current.Left;
                else
                    current = current.Right;
            }

            node.Parent = parent;

            if (parent == null) // Если дерево было пустым
            {
                root = node;
            }
            else if (node.Key < parent.Key)
            {
                parent.Left = node;
            }
            else
            {
                parent.Right = node;
            }

            // Вызываем метод балансировки после вставки
            FixRedBlackTree(ref root, node);

            // Установим цвет корня в черный
            root.IsRed = false;
        }
        private void FixRedBlackTree(ref RedBlackNode root, RedBlackNode node)
        {
            RedBlackNode parent, grandParent, uncle;

            while (node != root && node.Parent.IsRed)
            {
                parent = node.Parent;
                grandParent = parent.Parent;

                if (parent == grandParent.Left)
                {
                    uncle = grandParent.Right;

                    if (uncle != null && uncle.IsRed)
                    {
                        parent.IsRed = false;
                        uncle.IsRed = false;
                        grandParent.IsRed = true;
                        node = grandParent;
                    }
                    else
                    {
                        if (node == parent.Right)
                        {
                            node = parent;
                            RotateLeft(ref root, node);
                        }

                        parent = node.Parent;
                        grandParent = parent.Parent;

                        parent.IsRed = false;
                        grandParent.IsRed = true;
                        RotateRight(ref root, grandParent);
                    }
                }
                else
                {
                    uncle = grandParent.Left;

                    if (uncle != null && uncle.IsRed)
                    {
                        parent.IsRed = false;
                        uncle.IsRed = false;
                        grandParent.IsRed = true;
                        node = grandParent;
                    }
                    else
                    {
                        if (node == parent.Left)
                        {
                            node = parent;
                            RotateRight(ref root, node);
                        }

                        parent = node.Parent;
                        grandParent = parent.Parent;

                        parent.IsRed = false;
                        grandParent.IsRed = true;
                        RotateLeft(ref root, grandParent);
                    }
                }
            }

            root.IsRed = false;
        }
        private void RotateLeft(ref RedBlackNode root, RedBlackNode node)
        {
            RedBlackNode rightChild = node.Right;
            node.Right = rightChild.Left;
            if (rightChild.Left != null)
                rightChild.Left.Parent = node;
            rightChild.Parent = node.Parent;
            if (node.Parent == null)
                root = rightChild;
            else if (node == node.Parent.Left)
                node.Parent.Left = rightChild;
            else
                node.Parent.Right = rightChild;
            rightChild.Left = node;
            node.Parent = rightChild;
        }

        private void RotateRight(ref RedBlackNode root, RedBlackNode node)
        {
            RedBlackNode leftChild = node.Left;
            node.Left = leftChild.Right;
            if (leftChild.Right != null)
                leftChild.Right.Parent = node;
            leftChild.Parent = node.Parent;
            if (node.Parent == null)
                root = leftChild;
            else if (node == node.Parent.Right)
                node.Parent.Right = leftChild;
            else
                node.Parent.Left = leftChild;
            leftChild.Right = node;
            node.Parent = leftChild;
        }

        private void DrawRedBlackTree(RedBlackNode node, Graphics graphics, int x, int y, int xOffset, int currentLevel, int maxLevel)
        {
            if (node == null || currentLevel > maxLevel)
                return;

            // Рисуем левое поддерево, если оно есть
            if (node.Left != null)
            {
                graphics.DrawLine(Pens.Black, x, y, x - xOffset, y + 50);
                DrawRedBlackTree(node.Left, graphics, x - xOffset, y + 50, xOffset / 2, currentLevel + 1, maxLevel);
            }

            // Рисуем правое поддерево, если оно есть
            if (node.Right != null)
            {
                graphics.DrawLine(Pens.Black, x, y, x + xOffset, y + 50);
                DrawRedBlackTree(node.Right, graphics, x + xOffset, y + 50, xOffset / 2, currentLevel + 1, maxLevel);
            }

            // Рисуем узел
            Brush brush = node.IsRed ? Brushes.Red : Brushes.Black;
            Pen pen = node.IsRed ? Pens.White : Pens.Black;
            graphics.FillEllipse(brush, x - 15, y - 15, 30, 30);
            graphics.DrawEllipse(pen, x - 15, y - 15, 30, 30);
            graphics.DrawString(node.Key.ToString(), Font, Brushes.White, x - 6, y - 6);
        }



    }
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
        {
            Value = value;
        }
    }
    public class BinaryTree
    {
        private TreeNode root;

        public TreeNode GetRootNode()
        {
            return root;
        }


        //Задание 1
        public void Insert(int value)
        {
            root = InsertRecursive(root, value);
        }

        private TreeNode InsertRecursive(TreeNode current, int value)
        {
            if (current == null)
            {
                return new TreeNode(value);
            }

            if (value < current.Value)
            {
                current.Left = InsertRecursive(current.Left, value);
            }
            else if (value > current.Value)
            {
                current.Right = InsertRecursive(current.Right, value);
            }

            return current;
        }

        public void Clear()
        {
            root = null;
        }

        //Задание 2
        public int SumOfElements()
        {
            return SumOfElementsRecursive(root);
        }

        private int SumOfElementsRecursive(TreeNode node)
        {
            if (node == null)
                return 0;

            // Рекурсивно суммируем значения в текущем узле и его потомках
            return node.Value + SumOfElementsRecursive(node.Left) + SumOfElementsRecursive(node.Right);
        }

        //Задание 3
        public int ProductOfElementsDivisibleByThree()
        {
            return ProductOfElementsDivisibleByThreeRecursive(root);
        }

        private int ProductOfElementsDivisibleByThreeRecursive(TreeNode node)
        {
            if (node == null)
                return 1; // Если узел пустой, возвращаем 1, чтобы не влиять на произведение

            int product = 1;

            // Если значение узла кратно 3, умножаем его на произведение потомков
            if (node.Value % 3 == 0)
            {
                product = node.Value;
            }

            // Рекурсивно находим произведение для левого и правого поддеревьев
            product *= ProductOfElementsDivisibleByThreeRecursive(node.Left) * ProductOfElementsDivisibleByThreeRecursive(node.Right);

            return product;
        }


        //Задание 4
        public List<TreeNode> FindNodesWithImbalancedChildren()
        {
            List<TreeNode> result = new List<TreeNode>();
            FindImbalancedChildrenRecursive(root, result);
            return result;
        }

        private int CountChildren(TreeNode node)
        {
            if (node == null)
                return 0;
            return 1 + CountChildren(node.Left) + CountChildren(node.Right);
        }
        private void FindImbalancedChildrenRecursive(TreeNode node, List<TreeNode> result)
        {
            if (node == null)
                return;

            int leftChildCount = CountChildren(node.Left);
            int rightChildCount = CountChildren(node.Right);

            if (leftChildCount != rightChildCount)
                result.Add(node);

            // Рекурсивно проверяем для левого и правого поддеревьев
            FindImbalancedChildrenRecursive(node.Left, result);
            FindImbalancedChildrenRecursive(node.Right, result);
        }


        //Задание 5
        public List<TreeNode> FindNodesWithUnequalHeight()
        {
            List<TreeNode> result = new List<TreeNode>();
            FindUnequalHeightRecursive(root, result);
            return result;
        }

        private int Height(TreeNode node)
        {
            if (node == null)
                return 0;

            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);

            return Math.Max(leftHeight, rightHeight) + 1;
        }

        private void FindUnequalHeightRecursive(TreeNode node, List<TreeNode> result)
        {
            if (node == null)
                return;

            int leftHeight = Height(node.Left);
            int rightHeight = Height(node.Right);

            if (leftHeight != rightHeight)
                result.Add(node);

            // Рекурсивно проверяем для левого и правого поддеревьев
            FindUnequalHeightRecursive(node.Left, result);
            FindUnequalHeightRecursive(node.Right, result);
        }
        //Задание 6

        public int CountOccurrences(int x)
        {
            return CountOccurrences(GetRootNode(), x);
        }

        private int CountOccurrences(TreeNode node, int x)
        {
            if (node == null)
                return 0;

            int count = 0;
            if (node.Value == x)
                count++;

            count += CountOccurrences(node.Left, x);
            count += CountOccurrences(node.Right, x);

            return count;
        }

        //Задание 7
        public (int maxElement, int count) FindMaxElementAndCount()
        {
            if (root == null)
            {
                return (0, 0); // Если дерево пустое, возвращаем 0 и 0
            }

            int maxElement = int.MinValue;
            int count = 0;

            FindMaxElementAndCountRecursive(root, ref maxElement, ref count);

            return (maxElement, count);
        }

        private void FindMaxElementAndCountRecursive(TreeNode node, ref int maxElement, ref int count)
        {
            if (node == null)
            {
                return;
            }

            // Если текущий элемент больше максимального, обновляем максимальный элемент и счетчик
            if (node.Value > maxElement)
            {
                maxElement = node.Value;
                count = 1;
            }
            // Если текущий элемент равен максимальному, увеличиваем счетчик
            else if (node.Value == maxElement)
            {
                count++;
            }

            // Рекурсивно проверяем для левого и правого поддеревьев
            FindMaxElementAndCountRecursive(node.Left, ref maxElement, ref count);
            FindMaxElementAndCountRecursive(node.Right, ref maxElement, ref count);
        }

        //Задание 8
        public List<int> GetDuplicateElements()
        {
            if (root == null)
            {
                return new List<int>(); // Если дерево пустое, возвращаем пустой список
            }

            HashSet<int> seen = new HashSet<int>();
            List<int> duplicates = new List<int>();
            HasDuplicateElementsRecursive(root, seen, duplicates);
            return duplicates;
        }

        private void HasDuplicateElementsRecursive(TreeNode node, HashSet<int> seen, List<int> duplicates)
        {
            if (node == null)
            {
                return;
            }

            if (seen.Contains(node.Value))
            {
                duplicates.Add(node.Value); // Добавляем дубликат в список
            }
            else
            {
                seen.Add(node.Value);
            }

            // Рекурсивно проверяем для левого и правого поддеревьев
            HasDuplicateElementsRecursive(node.Left, seen, duplicates);
            HasDuplicateElementsRecursive(node.Right, seen, duplicates);
        }

        //Задание 9
        public void FindMaxDuplicateCountAndShowMessage()
        {
            Dictionary<int, int> countMap = new Dictionary<int, int>();
            FindElementCountsRecursive(root, countMap);

            int maxCount = 0;
            foreach (var kvp in countMap)
            {
                if (kvp.Value > maxCount)
                {
                    maxCount = kvp.Value;
                }
            }

            if (maxCount > 1)
            {
                MessageBox.Show($"Максимальное количество одинаковых элементов в бинарном дереве: {maxCount}");
            }
            else
            {
                MessageBox.Show("В бинарном дереве нет одинаковых элементов или дерево пустое.");
            }
        }

        private void FindElementCountsRecursive(TreeNode node, Dictionary<int, int> countMap)
        {
            if (node == null)
            {
                return;
            }

            if (!countMap.ContainsKey(node.Value))
            {
                countMap[node.Value] = 1;
            }
            else
            {
                countMap[node.Value]++;
            }

            // Рекурсивно проверяем для левого и правого поддеревьев
            FindElementCountsRecursive(node.Left, countMap);
            FindElementCountsRecursive(node.Right, countMap);
        }

        //Задание 10
        public void CheckSymmetryAndShowMessage()
        {
            if (root == null)
            {
                MessageBox.Show("Дерево пустое.");
                return;
            }

            bool isSymmetric = IsSymmetricRecursive(root.Left, root.Right);
            if (isSymmetric)
            {
                MessageBox.Show("Бинарное дерево симметрично.");
            }
            else
            {
                MessageBox.Show("Бинарное дерево не является симметричным.");
            }
        }

        private bool IsSymmetricRecursive(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true; // Если оба поддерева пустые, они симметричны
            }

            if (left == null || right == null)
            {
                return false; // Если одно из поддеревьев пустое, они не симметричны
            }

            // Сравниваем значения текущих узлов и рекурсивно проверяем их поддеревья
            return (left.Value == right.Value) &&
                   IsSymmetricRecursive(left.Left, right.Right) &&
                   IsSymmetricRecursive(left.Right, right.Left);
        }

        //Задание 11
        public void CheckIfBSTAndShowMessage()
        {
            if (root == null)
            {
                MessageBox.Show("Дерево пустое.");
                return;
            }

            bool isBST = IsBSTRecursive(root, int.MinValue, int.MaxValue);
            if (isBST)
            {
                MessageBox.Show("Бинарное дерево является деревом поиска (BST).");
            }
            else
            {
                MessageBox.Show("Бинарное дерево не является деревом поиска (BST).");
            }
        }

        private bool IsBSTRecursive(TreeNode node, int minValue, int maxValue)
        {
            if (node == null)
            {
                return true; // Пустое поддерево является допустимым BST
            }

            if (node.Value < minValue || node.Value > maxValue)
            {
                return false; // Нарушено условие BST
            }

            // Рекурсивно проверяем левое поддерево с учетом текущего узла как нового максимума
            // и правое поддерево с учетом текущего узла как нового минимума
            return IsBSTRecursive(node.Left, minValue, node.Value - 1) &&
                   IsBSTRecursive(node.Right, node.Value + 1, maxValue);
        }

        // Задание 12

        public List<int> TraverseInOrder()
        {
            List<int> vertices = new List<int>();
            TraverseInOrder(GetRootNode(), vertices);
            return vertices;
        }

        private void TraverseInOrder(TreeNode node, List<int> vertices)
        {
            if (node == null)
                return;

            TraverseInOrder(node.Left, vertices);
            vertices.Add(node.Value);
            TraverseInOrder(node.Right, vertices);
        }
        //Задание 13
        // Метод для создания двух новых деревьев: одного с отрицательными элементами и одного с положительными элементами
        public Tuple<BinaryTree, BinaryTree> SplitBySign()
        {
            BinaryTree negativeTree = new BinaryTree();
            BinaryTree positiveTree = new BinaryTree();

            SplitBySignRecursive(root, negativeTree, positiveTree);

            return Tuple.Create(negativeTree, positiveTree);
        }

        private void SplitBySignRecursive(TreeNode current, BinaryTree negativeTree, BinaryTree positiveTree)
        {
            if (current == null)
                return;

            if (current.Value < 0)
            {
                negativeTree.Insert(current.Value);
            }
            else if (current.Value > 0)
            {
                positiveTree.Insert(current.Value);
            }

            SplitBySignRecursive(current.Left, negativeTree, positiveTree);
            SplitBySignRecursive(current.Right, negativeTree, positiveTree);
        }

        //Задание 14
        public void PrintMinWeightPaths(TreeNode node, List<int> currentPath, List<List<int>> minWeightPaths, ref int minWeight)
        {
            if (node == null)
                return;

            // Добавляем текущий узел в путь
            currentPath.Add(node.Value);

            // Если текущий узел - лист, проверяем сумму весов элементов в пути
            if (node.Left == null && node.Right == null)
            {
                int pathWeight = currentPath.Sum();
                if (pathWeight < minWeight)
                {
                    minWeight = pathWeight;
                    // Очищаем список минимальных путей и добавляем текущий путь
                    minWeightPaths.Clear();
                    minWeightPaths.Add(new List<int>(currentPath));
                }
                else if (pathWeight == minWeight)
                {
                    // Если сумма весов равна минимальной, добавляем текущий путь в список минимальных путей
                    minWeightPaths.Add(new List<int>(currentPath));
                }
            }

            // Рекурсивно вызываем функцию для левого и правого потомков
            PrintMinWeightPaths(node.Left, currentPath, minWeightPaths, ref minWeight);
            PrintMinWeightPaths(node.Right, currentPath, minWeightPaths, ref minWeight);

            // Удаляем текущий узел из пути перед возвратом из рекурсии
            currentPath.RemoveAt(currentPath.Count - 1);
        }


        // Задание 15

        public int FindLastLevelWithPositiveElements(TreeNode node, int currentLevel, int lastLevel)
        {
            if (node == null)
            {
                return lastLevel;
            }

            if (node.Value > 0)
            {
                lastLevel = currentLevel;
            }

            // Рекурсивный вызов для левого и правого поддеревьев с увеличением уровня
            int leftLevel = FindLastLevelWithPositiveElements(node.Left, currentLevel + 1, lastLevel);
            int rightLevel = FindLastLevelWithPositiveElements(node.Right, currentLevel + 1, lastLevel);

            // Возвращаем наибольший номер уровня с положительными элементами
            return Math.Max(leftLevel, rightLevel);
        }

        // Задание 16

        public List<int> FindMaxValuesPerLevel()
        {
            List<int> maxValues = new List<int>();
            if (GetRootNode() == null)
                return maxValues;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(GetRootNode());

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                int max = int.MinValue; // Используем минимальное значение int в качестве начального максимального значения на текущем уровне

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    max = Math.Max(max, node.Value);

                    if (node.Left != null)
                        queue.Enqueue(node.Left);

                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }

                maxValues.Add(max);
            }

            return maxValues;
        }

        // Задание 17
        // Внутренние вершины (узлы): Это вершины дерева, которые имеют по крайней мере одного потомка. Внутренняя вершина является узлом, через который проходит один или более пути от корня к листьям.
        // Листья (терминальные узлы) : Это вершины дерева, которые не имеют потомков. Листья находятся в конце каждого пути в дереве.

        public List<string> CountNodesAndLeavesPerLevel()
        {
            List<string> counts = new List<string>();
            if (GetRootNode() == null)
                return counts;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(GetRootNode());

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                int internalNodesCount = 0;
                int leavesCount = 0;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (node.Left != null || node.Right != null)
                        internalNodesCount++;
                    else
                        leavesCount++;

                    if (node.Left != null)
                        queue.Enqueue(node.Left);

                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }

                counts.Add($"Уровень {counts.Count + 1}: Внутренние вершины: {internalNodesCount}, Листья: {leavesCount}");
            }

            return counts;
        }

        // Задание 18

        public int SumOfElementsOddLevels()
        {
            if (GetRootNode() == null)
                return 0;

            int level = 0;
            int sum = 0;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(GetRootNode());

            while (queue.Count > 0)
            {
                int levelSize = queue.Count;
                level++;

                for (int i = 0; i < levelSize; i++)
                {
                    TreeNode node = queue.Dequeue();
                    if (level % 2 != 0) // Проверка на нечетность уровня
                        sum += node.Value;

                    if (node.Left != null)
                        queue.Enqueue(node.Left);

                    if (node.Right != null)
                        queue.Enqueue(node.Right);
                }
            }

            return sum;
        }

        // Задание 19
        public List<int> FindMinPath()
        {
            List<int> minPath = new List<int>();
            if (GetRootNode() == null)
                return minPath;

            List<List<int>> allPaths = new List<List<int>>();
            FindAllLeafToLeafPaths(GetRootNode(), new List<int>(), allPaths);

            int minLength = int.MaxValue;
            foreach (List<int> path in allPaths)
            {
                if (path.Count < minLength)
                {
                    minLength = path.Count;
                    minPath = new List<int>(path);
                }
            }

            return minPath;
        }

        public List<int> FindMaxPath()
        {
            List<int> maxPath = new List<int>();
            if (GetRootNode() == null)
                return maxPath;

            List<List<int>> allPaths = new List<List<int>>();
            FindAllLeafToLeafPaths(GetRootNode(), new List<int>(), allPaths);

            int maxLength = 0;
            foreach (List<int> path in allPaths)
            {
                if (path.Count > maxLength)
                {
                    maxLength = path.Count;
                    maxPath = new List<int>(path);
                }
            }

            return maxPath;
        }

        private void FindAllLeafToLeafPaths(TreeNode node, List<int> currentPath, List<List<int>> allPaths)
        {
            if (node == null)
                return;

            currentPath.Add(node.Value);

            if (node.Left == null && node.Right == null) // Лист
            {
                allPaths.Add(new List<int>(currentPath));
            }
            else
            {
                FindAllLeafToLeafPaths(node.Left, currentPath, allPaths);
                FindAllLeafToLeafPaths(node.Right, currentPath, allPaths);
            }

            currentPath.RemoveAt(currentPath.Count - 1); // Удалить последний добавленный узел перед возвратом
        }

        // Задание 20
        // В контексте бинарного дерева "строго бинарное" означает, что каждый узел в дереве имеет либо ноль, либо два потомка. 
        public void MakeTreeStrictlyBinary(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            // Если узел имеет только один дочерний узел, удалить его
            if (root.Left == null || root.Right == null)
            {
                if (root.Left != null)
                {
                    root.Left = null;
                }
                else
                {
                    root.Right = null;
                }

                return;
            }

            // Рекурсивно обработать левый и правый поддеревья
            MakeTreeStrictlyBinary(root.Left);
            MakeTreeStrictlyBinary(root.Right);
        }
        public void PrintTree(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            Console.WriteLine(root.Value);
            PrintTree(root.Left);
            PrintTree(root.Right);
        }

        // Задание 21

        // инфиксный обход дерева

        public List<int> TraverseInOrder1()
        {
            List<int> elements = new List<int>();
            TraverseInOrderRecursive(GetRootNode(), elements);
            return elements;
        }

        private void TraverseInOrderRecursive(TreeNode node, List<int> elements)
        {
            if (node == null)
                return;

            TraverseInOrderRecursive(node.Left, elements);
            elements.Add(node.Value);
            TraverseInOrderRecursive(node.Right, elements);
        }

        // постфиксным обходом

        public List<int> TraversePostOrder()
        {
            List<int> elements = new List<int>();
            TraversePostOrderRecursive(GetRootNode(), elements);
            return elements;
        }

        private void TraversePostOrderRecursive(TreeNode node, List<int> elements)
        {
            if (node == null)
                return;

            // Рекурсивно обходим левое поддерево
            TraversePostOrderRecursive(node.Left, elements);

            // Рекурсивно обходим правое поддерево
            TraversePostOrderRecursive(node.Right, elements);

            // Добавляем значение текущего узла в список
            elements.Add(node.Value);
        }

        // префиксным обходом

        public List<int> TraversePreOrder()
        {
            List<int> elements = new List<int>();
            TraversePreOrderRecursive(GetRootNode(), elements);
            return elements;
        }

        private void TraversePreOrderRecursive(TreeNode node, List<int> elements)
        {
            if (node == null)
                return;

            // Добавляем значение текущего узла в список
            elements.Add(node.Value);

            // Рекурсивно обходим левое поддерево
            TraversePreOrderRecursive(node.Left, elements);

            // Рекурсивно обходим правое поддерево
            TraversePreOrderRecursive(node.Right, elements);
        }

        // Задание 22

        // Класс для узла B+ дерева
        public class BPlusTreeNode
        {
            public List<int> Keys { get; set; }
            public List<BPlusTreeNode> Children { get; set; }

            public BPlusTreeNode()
            {
                Keys = new List<int>();
                Children = new List<BPlusTreeNode>();
            }
        }

        // Метод для преобразования обычного бинарного дерева в B+ дерево
        public BPlusTreeNode ConvertToBPlusTree(TreeNode root)
        {
            List<int> keys = new List<int>();
            InOrderTraversal(root, keys);

            List<List<int>> keyGroups = SplitIntoGroups(keys, 5);

            BPlusTreeNode bPlusRoot = new BPlusTreeNode();
            foreach (var group in keyGroups)
            {
                BPlusTreeNode leaf = new BPlusTreeNode();
                leaf.Keys.AddRange(group);
                bPlusRoot.Children.Add(leaf);
            }

            return bPlusRoot;
        }

        // Метод для инфиксного обхода дерева и сбора ключей
        private void InOrderTraversal(TreeNode node, List<int> keys)
        {
            if (node == null)
                return;

            InOrderTraversal(node.Left, keys);
            keys.Add(node.Value);
            InOrderTraversal(node.Right, keys);
        }

        // Метод для разбиения списка ключей на группы по заданному размеру
        private List<List<int>> SplitIntoGroups(List<int> keys, int groupSize)
        {
            List<List<int>> groups = new List<List<int>>();
            for (int i = 0; i < keys.Count; i += groupSize)
            {
                groups.Add(keys.GetRange(i, Math.Min(groupSize, keys.Count - i)));
            }
            return groups;
        }
    }

    //Задание 23
    public class RedBlackNode
    {
        public int Key { get; set; }
        public RedBlackNode Parent { get; set; }
        public RedBlackNode Left { get; set; }
        public RedBlackNode Right { get; set; }
        public bool IsRed { get; set; } // Цвет узла: true - красный, false - черный

        public RedBlackNode(int key)
        {
            Key = key;
            IsRed = true; // При вставке нового узла он всегда красный
        }
    }

}
