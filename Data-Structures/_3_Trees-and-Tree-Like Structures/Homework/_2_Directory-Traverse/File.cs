namespace _2_Directory_Traverse
{
    public class File
    {
        public File(string name, long size = 0)
        {
            this.Name = name;
            this.Size = size;
        }

        public string Name { get; set; }

        public long Size { get; set; }
    }
}