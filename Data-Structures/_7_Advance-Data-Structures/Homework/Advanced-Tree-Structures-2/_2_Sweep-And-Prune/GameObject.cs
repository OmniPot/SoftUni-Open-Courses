namespace _2_Sweep_And_Prune
{
    using _1_Quad_Tree;

    public class GameObject : IBoundable
    {
        private const int DefaultWidth = 10;
        private const int DefaultHeight = 10;

        public GameObject(string name, int x1, int y1)
        {
            this.Name = name;
            this.Bounds = new Rectangle(x1, y1, DefaultWidth, DefaultHeight);
        }

        public string Name { get; set; }

        public Rectangle Bounds { get; set; }

        public void Move(int newX1, int newY1)
        {
            this.Bounds = new Rectangle(newX1, newY1, DefaultWidth, DefaultHeight);
        }

        public override string ToString()
        {
            return this.Bounds.ToString();
        }
    }
}
