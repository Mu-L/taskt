using System;
using System.Xml.Serialization;
using System.IO;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    public abstract class FolderCopySameRenameFolderCommands : AFolderExistsFolderBeforeAfterResultCommands, ICanHandleFolderName
    {
        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        //public string v_TargetFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_DisallowNewLine_OneLineTextBox))]
        [PropertyDescription("New Folder Name")]
        [InputSpecification("New Folder Name", true)]
        [PropertyDetailSampleUsage("**myFolder2**", PropertyDetailSampleUsage.ValueType.Value, "New Folder")]
        [PropertyDetailSampleUsage("**{{{vNewFolder}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "New Folder")]
        [PropertyValidationRule("New Folder", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "New Folder")]
        [PropertyParameterOrder(5100)]
        public string v_NewFolderName { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_ComboBox))]
        [PropertyDescription("When Folder Name Same After the Change")]
        [PropertyUISelectionOption("Ignore")]
        [PropertyUISelectionOption("Error")]
        [PropertyDetailSampleUsage("**Ignore**", "Nothing to do")]
        [PropertyDetailSampleUsage("**Error**", "Rise a Error")]
        [PropertyIsOptional(true, "Ignore")]
        [PropertyDisplayText(false, "")]
        [PropertyParameterOrder(5200)]
        public string v_WhenFolderNameSame { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_WaitTime))]
        //public string v_WaitTimeForFolder { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPathResult))]
        //[PropertyDescription("Variable Name to Store Folder Path Before Rename")]
        //public string v_BeforeFolderPathResult { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        //[PropertyDescription("Variable Name to Store Folder Path After Rename")]
        //[PropertyIsOptional(true)]
        //[PropertyValidationRule("", PropertyValidationRule.ValidationRuleFlags.None)]
        //[PropertyDisplayText(false, "")]
        //public string v_AfterFolderPathResult { get; set; }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            this.FolderAction(engine,
                new Func<string, string>(path =>
                {
                    //var currentFolderName = Path.GetFileName(path);

                    //var newFolderName = v_NewFolderName.ExpandValueOrUserVariableAsFolderName(engine);
                    var newFolderName = this.ExpandValueOrUserVariableAsFolderName(nameof(v_NewFolderName), engine);

                    // get source folder name and info
                    DirectoryInfo sourceFolderInfo = new DirectoryInfo(path);

                    // create destination
                    var destinationPath = Path.Combine(sourceFolderInfo.Parent.FullName, newFolderName);

                    //var whenSame = this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_IfFolderNameSame), engine);
                    //if (sourceFolderInfo.Name == newFolderName)
                    if (EM_CanHandleFileOrFolderPathExtensionMethods.IsSamePath(path, destinationPath))
                    {
                        switch (this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_WhenFolderNameSame), engine))
                        {
                            case "ignore":
                                return path;

                            case "error":
                                throw new Exception($"Folder Name before and after the changes is same. Name '{newFolderName}'");
                        }
                    }

                    // rename folder
                    Directory.Move(path, destinationPath);

                    return destinationPath;
                })
            );
        }

        /// <summary>
        /// create action func
        /// </summary>
        /// <param name="processFunc"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Func<string, string> CreateActionFunc(Action<string, string> processFunc, Engine.AutomationEngineInstance engine)
        {
            return new Func<string, string>(path =>
            {
                var newFolderName = this.ExpandValueOrUserVariableAsFolderName(nameof(v_NewFolderName), engine);

                // get source folder name and info
                var sourceFolderInfo = new DirectoryInfo(path);

                // create destination
                var destinationPath = Path.Combine(sourceFolderInfo.Parent.FullName, newFolderName);

                // check path is same
                if (EM_CanHandleFileOrFolderPathExtensionMethods.IsSamePath(path, destinationPath))
                {
                    switch (this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_WhenFolderNameSame), engine))
                    {
                        case "ignore":
                            return path;

                        case "error":
                            throw new Exception($"Folder Name before and after the changes is same. Name '{newFolderName}'");
                    }
                }

                // action
                processFunc(path, destinationPath);

                return destinationPath;
            });
        }
    }
}
