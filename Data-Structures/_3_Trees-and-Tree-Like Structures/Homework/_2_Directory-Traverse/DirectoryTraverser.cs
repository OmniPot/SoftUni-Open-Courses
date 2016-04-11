namespace _2_Directory_Traverse
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Numerics;

    public class DirectoryTraverser
    {
        public static void Main()
        {
            // Process Input
            string inputDirectory = ProcessInput();

            // Load files and folders in a tree-like structure
            DirectoryInfo inputDirectoryInfo = new DirectoryInfo(inputDirectory);
            Folder rootDirectory = new Folder(inputDirectoryInfo.FullName, new List<File>(), new List<Folder>());
            Console.WriteLine("Processing files and folders...");
            TraverseDirectory(rootDirectory);

            // Find The size of a folder
            BigInteger rootSize = GetFolderSizeInBytes(rootDirectory);
            Console.WriteLine("Calculating folder size...");
            Console.WriteLine("Size of directory: \"{0}\" is {1} bytes", inputDirectory, rootSize);
        }

        private static string ProcessInput()
        {
            Console.Write("Input directory: ");
            string inputDirectory = Console.ReadLine().Trim();

            if (string.IsNullOrWhiteSpace(inputDirectory) || !Directory.Exists(inputDirectory))
            {
                Console.WriteLine("Invalid input directory!");
            }

            return inputDirectory;
        }

        private static void TraverseDirectory(Folder currentFolder)
        {
            try
            {
                var dirInfo = new DirectoryInfo(currentFolder.Name);
                Console.WriteLine(dirInfo.FullName);

                currentFolder.Files = dirInfo.GetFiles()
                    .Select(f => new File(f.Name, f.Length))
                    .ToList();

                currentFolder.ChildFolders = dirInfo.GetDirectories()
                    .Select(f => new Folder(dirInfo.FullName + @"\" + f.Name + @"\", new List<File>(), new List<Folder>()))
                    .ToList();

                currentFolder.ChildFolders.ForEach(TraverseDirectory);
            }
            catch (UnauthorizedAccessException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch (DirectoryNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static BigInteger GetFolderSizeInBytes(Folder subTreeRoot, BigInteger sizeInBytes = new BigInteger())
        {
            sizeInBytes += subTreeRoot.Files.Select(f => f.Size).Sum();

            foreach (var folder in subTreeRoot.ChildFolders)
            {
                BigInteger.Add(sizeInBytes, GetFolderSizeInBytes(folder, sizeInBytes));
            }

            return sizeInBytes;
        }
    }
}