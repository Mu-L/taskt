using System;
using System.Windows.Forms;
using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    [Serializable]
    [Attributes.ClassAttributes.Group("Dialog/Message")]
    [Attributes.ClassAttributes.CommandSettings("Show Folder Dialog")]
    [Attributes.ClassAttributes.Description("Show FolderBrowserDialog")]
    [Attributes.ClassAttributes.UsesDescription("Use this command when you want to select folder.")]
    [Attributes.ClassAttributes.ImplementationDescription("")]
    [Attributes.ClassAttributes.CommandIcon(nameof(Properties.Resources.command_input))]
    [Attributes.ClassAttributes.EnableAutomateRender(true)]
    [Attributes.ClassAttributes.EnableAutomateDisplayText(true)]
    public sealed class ShowFolderDialogCommand : AShowFileFolderDialogCommands
    {
        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(GeneralPropertyControls), nameof(GeneralPropertyControls.v_Result))]
        //public string v_Result { get; set; }

        public ShowFolderDialogCommand()
        {
        }

        public override void RunCommand(Engine.AutomationEngineInstance engine)
        {
            engine.tasktEngineUI.Invoke(new Action(() =>
            {
                using (var dialog = new FolderBrowserDialog())
                {
                    dialog.SelectedPath = this.GetInitialDirectory(engine);

                    //string result;
                    //if (dialog.ShowDialog() == DialogResult.OK)
                    //{
                    //    result = dialog.SelectedPath;
                    //}
                    //else
                    //{
                    //    result = "";
                    //}
                    //result.StoreInUserVariable(engine, v_Result);

                    //Func<CommonDialog, string> GetPathFunc = new Func<CommonDialog, string>(d => ((FolderBrowserDialog)d).SelectedPath);

                    //var whenCancel = this.ExpandValueOrUserVariableAsSelectionItem(nameof(v_WhenCancel), engine);
                    //switch (whenCancel)
                    //{
                    //    case "show dialog again":
                    //        bool isAgain = true;
                    //        while (isAgain)
                    //        {
                    //            if (dialog.ShowDialog() == DialogResult.OK)
                    //            {
                    //                dialog.SelectedPath.StoreInUserVariable(engine, v_Result);
                    //                isAgain = false;
                    //            }
                    //        }
                    //        break;
                    //    default:
                    //        if (dialog.ShowDialog() == DialogResult.OK)
                    //        {
                    //            dialog.SelectedPath.StoreInUserVariable(engine, v_Result);
                    //        }
                    //        else
                    //        {
                    //            switch (whenCancel)
                    //            {
                    //                case "error":
                    //                    throw new Exception($"Error. FolderBrowseDialog is Clicked Cancel button.");

                    //                case "set empty":
                    //                    "".StoreInUserVariable(engine, v_Result);
                    //                    break;
                    //                case "ignore":
                    //                    // nothing to do
                    //                    break;
                    //            }
                    //        }
                    //        break;
                    //}

                    this.ShowDialogProcess(dialog,
                        new Func<CommonDialog, string>(d => ((FolderBrowserDialog)d).SelectedPath), 
                        "FolderBrowserDialog", engine);
                }
            }));
        }
    }
}
