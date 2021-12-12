namespace UeModule
{
    public class TemplateSourceFile : TemplateClass
    {
        public TemplateSourceFile(string moduleName)
        {
            ModuleName = moduleName;
        }

        public override string GenerateFileContent()
        {
            return 
@"#include """ + ModuleName + @".h""

DEFINE_LOG_CATEGORY(Log" + ModuleName + @");


void F" + ModuleName + @"Module::StartupModule()
{
}

void F" + ModuleName + @"Module::ShutdownModule()
{
}

bool F" + ModuleName + @"Module::SupportsDynamicReloading()
{
	return false;
}

IMPLEMENT_MODULE(F" + ModuleName + @"Module, " + ModuleName + @");
";
        }

        public override string GetFileName()
        {
            return $"{ModuleName}.cpp";
        }

        public override string GetRelativePath()
        {
            return "Private";
        }

        private readonly string ModuleName;
    }
}