using RedBlackTree;

class Program
{
    static void Main(string[] args)
    {
        LeftLeaningRedBlackTree<int> tree = new();


        tree.Insert(6);
        tree.Insert(2);
        tree.Insert(5);
        tree.Insert(1);
        tree.Insert(4);
        tree.Insert(7);
        tree.Insert(8);
        tree.Insert(10);
        tree.Insert(11);

        ;
    }
}