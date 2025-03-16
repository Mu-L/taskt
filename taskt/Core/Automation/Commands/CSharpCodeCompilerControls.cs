using System.CodeDom.Compiler;

namespace taskt.Core.Automation.Commands
{
    public static class CSharpCodeCompilerControls
    {
        private const string defaultOutFileName = "tasktOnTheFly.exe";

        /// <summary>
        /// read here
        /// https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/configure-language-version?WT.mc_id=AI-MVP-123445
        /// </summary>
        private const string defaultLangVersion = "default";

        public static CompilerResults CompileInput(string codeInput, string langVersion = "", string outFileName = "")
        {
            if (string.IsNullOrEmpty(langVersion)) 
            { 
                langVersion = defaultLangVersion;
            }
            if (string.IsNullOrEmpty(outFileName)) 
            { 
                outFileName = defaultOutFileName;
            }

            if (!outFileName.EndsWith(".exe"))
            {
                outFileName += ".exe";
            }

            // create provider
            //CodeDomProvider codeProvider = CodeDomProvider.CreateProvider("CSharp");
            var roslyn = new Microsoft.CodeDom.Providers.DotNetCompilerPlatform.CSharpCodeProvider();

            // create compile parameters
            var parameters = new CompilerParameters
            {
                GenerateExecutable = true,
                OutputAssembly = outFileName,
                CompilerOptions = $"-langversion:{langVersion}",
            };

            // compile
            return roslyn.CompileAssemblyFromSource(parameters, codeInput);
        }
    }
}
