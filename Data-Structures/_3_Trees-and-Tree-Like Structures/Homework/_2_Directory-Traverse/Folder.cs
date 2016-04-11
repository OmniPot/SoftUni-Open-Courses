namespace _2_Directory_Traverse
{
    using System.Collections.Generic;

    public class Folder
    {
        public Folder(string name, List<File> files, List<Folder> childFolders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = childFolders;
        }

        public string Name { get; set; }

        public List<File> Files { get; set; }

        public List<Folder> ChildFolders { get; set; }
    }
}