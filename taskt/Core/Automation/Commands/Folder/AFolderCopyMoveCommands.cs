using System;
using System.Xml.Serialization;
using System.IO;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    public abstract class AFolderCopyMoveFolderCommands : AFolderExistsFolderBeforeAfterResultCommands
    {
        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        //[PropertyDescription("Target Folder")]
        //[PropertyValidationRule("Target Folder", PropertyValidationRule.ValidationRuleFlags.Empty)]
        //[PropertyDisplayText(true, "Target Folder")]
        //public string v_TargetFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        [PropertyDescription("Destination Folder for Action")]
        [PropertyValidationRule("Destination Folder", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "Destination Folder")]
        [PropertyParameterOrder(5100)]
        public virtual string v_DestinationFolderPath { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(SelectionItemsControls), nameof(SelectionItemsControls.v_YesNoComboBox))]
        [PropertyDescription("Create Folder when the Destination Folder does not Exists")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(5200)]
        public virtual string v_CreateDirectory { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(SelectionItemsControls), nameof(SelectionItemsControls.v_YesNoComboBox))]
        [PropertyDescription("Delete Folder when it already Exists")]
        [PropertyIsOptional(true, "No")]
        [PropertyParameterOrder(5300)]
        public virtual string v_DeleteExisting { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_WaitTime))]
        //[PropertyDescription("Wait Time for the Target Folder to Exist (sec)")]
        //[PropertyDisplayText(false, "")]
        //public string v_WaitTimeForFolder { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPathResult))]
        //[PropertyDescription("Variable Name to Store Folder Path Before Copy")]
        //public string v_BeforeFolderPathResult { get; set; }

        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(FilePathControls), nameof(FilePathControls.v_FilePathResult))]
        //[PropertyDescription("Variable Name to Store Folder Path After Copy")]
        //public string v_AfterFolderPathResult { get; set; }

        /// <summary>
        /// create action func for copy/move folder
        /// </summary>
        /// <param name="processFunc">(source, destination)</param>
        /// <param name="engine"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        protected Func<string, string> CreateActionFunc(Action<string, string> processFunc, Engine.AutomationEngineInstance engine)
        {
            return new Func<string, string>(path =>
            {
                // TODO : wait for folder
                var destinationFolder = v_DestinationFolderPath.ExpandValueOrUserVariableAsFolderPath(engine);

                if (!Directory.Exists(destinationFolder))
                {
                    if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_CreateDirectory), engine))
                    {
                        Directory.CreateDirectory(destinationFolder);
                    }
                }

                // get source folder name and info
                var sourceFolderInfo = new DirectoryInfo(path);

                // create final path
                var newFolderPath = Path.Combine(destinationFolder, sourceFolderInfo.Name);

                // delete if it already exists
                if (Directory.Exists(newFolderPath))
                {
                    if (this.ExpandValueOrUserVariableAsYesNo(nameof(v_DeleteExisting), engine))
                    {
                        Directory.Delete(newFolderPath, true);
                    }
                }

                processFunc(path, newFolderPath);

                return newFolderPath;
            });
        }
    }
}
