namespace UeModule
{
    public class TemplateHeaderFile : TemplateClass
    {
        public TemplateHeaderFile(string moduleName)
        {
            ModuleName = moduleName;
        }

        public override string GenerateFileContent()
        {
            return 
@"#pragma once

#include ""CoreMinimal.h""

DECLARE_LOG_CATEGORY_EXTERN(Log" + ModuleName + @", Log, All);


class F" + ModuleName + @"Module : public IModuleInterface
{
public:
	
	void StartupModule() override;
	void ShutdownModule() override;

	bool SupportsDynamicReloading() override;
};
";
        }

        public override string GetFileName()
        {
            return $"{ModuleName}.h";
        }

        public override string GetRelativePath()
        {
            return "Public";
        }

        private readonly string ModuleName;
    }
}