using System;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for Show File/Folder Dialog commands
    /// </summary>
    public abstract class AShowFileFolderDialogCommands : ScriptCommand, ICanHandleFolderPath
    {
        [XmlAttribute]
        [PropertyVirtualProperty(nameof(FolderPathControls), nameof(FolderPathControls.v_FolderPath))]
        [PropertyDescription("Value of the InitialDirectory Property")]
        [InputSpecification("InitialDirectory", true)]
        [PropertyDetailSampleUsage("**C:\\Users\\myUser\\Documents**", PropertyDetailSampleUsage.ValueType.Value, "InitialDirectory")]
        [PropertyDetailSampleUsage("**{{{vFolderPath}}}**", PropertyDetailSampleUsage.ValueType.VariableValue, "InitialDirectory")]
        [PropertyIsOptional(true, "Documents")]
        [PropertyFirstValue("")]
        [PropertyValidationRule("InitialDirectory", PropertyValidationRule.ValidationRuleFlags.None)]
        [PropertyDisplayText(false, "InitialDiretory")]
        [PropertyParameterOrder(10000)]
        public string v_InitialDirectory { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        [PropertyParameterOrder(11000)]
        public string v_Result { get; set; }

        [XmlAttribute]
        [PropertyVirtualProperty(nameof(SelectionItemsControls), nameof(SelectionItemsControls.v_ComboBoxHasErrorIgnore))]
        [PropertyDescription("When Dialog Result Is Cancel")]
        [PropertyUISelectionOption("Set Empty")]
        [PropertyUISelectionOption("Show Dialog Again")]
        [PropertyDetailSampleUsage("**Ignore**", "Nothing to do. The Result Variable is not Changed.")]
        [PropertyDetailSampleUsage("**Set Empty**", "Result Variable value is Empty")]
        [PropertyDetailSampleUsage("**Show Dialog Again", "Show Dialog Again")]
        [PropertyIsOptional(true, "Show Dialog Again")]
        [PropertyValidationRule("When Dialog Result Is Cancel", PropertyValidationRule.ValidationRuleFlags.None)]
        [PropertyDisplayText(false, "When Dialog Result Is Cancel")]
        [PropertyParameterOrder(12000)]
        public string v_WhenCancel { get; set; }

        /// <summary>
        /// get InitialDirectory
        /// </summary>
        /// <param name="engine"></param>
        /// <returns></returns>
        protected string GetInitialDirectory(Engine.AutomationEngineInstance engine)
        {
            if (string.IsNullOrEmpty(v_InitialDirectory))
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
            else
            {
                return this.ExpandValueOrUserVariableAsFolderPath(nameof(v_InitialDirectory), engine);
            }
        }
    }
}
