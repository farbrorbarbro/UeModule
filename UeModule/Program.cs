using System;
using System.IO;
using System.Reflection;

namespace UeModule
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Arguments:");
            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
            
            if (args.Length != 1)
            {
                Console.WriteLine("Invalid arguments!");
                Console.WriteLine("UeModule <module name>");
                return;
            }

            var moduleName = args[0];
            
            var currentDirectory = Directory.GetCurrentDirectory();
            
            var moduleRoot = Path.Combine(currentDirectory, moduleName);
            if (Directory.Exists(moduleRoot))
            {
                Console.WriteLine("Module seems to already exist!");
                return;
            }

            Directory.CreateDirectory(moduleRoot);

            var templateFiles = new TemplateClass[]
            {
                new TemplateBuildFile(moduleName),
                new TemplateHeaderFile(moduleName),
                new TemplateSourceFile(moduleName)
            };

            foreach (var templateFile in templateFiles)
            {
                var relativePath = templateFile.GetRelativePath();
                var fileDirectoryPath = Path.Combine(moduleRoot, relativePath);
                if (!Directory.Exists(fileDirectoryPath))
                {
                    Directory.CreateDirectory(fileDirectoryPath);
                }

                var fileContent = templateFile.GenerateFileContent();
                var fileName = templateFile.GetFileName();
                var absolutePath = Path.Combine(fileDirectoryPath, fileName);

                File.WriteAllText(absolutePath, fileContent);
                
                Console.WriteLine($"Created {absolutePath}.");
            }

            Console.WriteLine("Generation completed!");
        }
    }
}