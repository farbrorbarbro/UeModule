namespace UeModule
{
    public class TemplateBuildFile : TemplateClass
    {
        public TemplateBuildFile(string moduleName)
        {
            ModuleName = moduleName;
        }

        public override string GenerateFileContent()
        {
            return 
@"using System.IO;

namespace UnrealBuildTool.Rules
{
	public class " + ModuleName + @" : ModuleRules
	{
		public " + ModuleName + @"(ReadOnlyTargetRules Target) : base(Target)
		{
			PublicDependencyModuleNames.AddRange(
				new string[] {
					""Core"",
				}
			);
		}
	}
}
";
        }

        public override string GetFileName()
        {
            return $"{ModuleName}.Build.cs";
        }

        public override string GetRelativePath()
        {
	        return "";
        }

        private readonly string ModuleName;
    }
}