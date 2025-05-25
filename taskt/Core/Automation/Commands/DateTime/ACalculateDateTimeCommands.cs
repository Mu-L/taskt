using System.Xml.Serialization;
using taskt.Core.Automation.Attributes.PropertyAttributes;

namespace taskt.Core.Automation.Commands
{
    /// <summary>
    /// for Calculate DateTime commands
    /// </summary>
    public abstract class ACalculateDateTimeCommands : ADateTimeConvertCommands, IDateTimeResultProperties
    {
        //[XmlAttribute]
        //[PropertyVirtualProperty(nameof(DateTimeControls), nameof(DateTimeControls.v_InputDateTime))]
        //public string v_DateTime { get; set; }

        [XmlAttribute]
        [PropertyDescription("Calculation Method")]
        [PropertyUIHelper(PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [InputSpecification("")]
        [Remarks("")]
        [PropertyRecommendedUIControl(PropertyRecommendedUIControl.RecommendeUIControlType.ComboBox)]
        [PropertyUISelectionOption("Add Years")]
        [PropertyUISelectionOption("Add Months")]
        [PropertyUISelectionOption("Add Days")]
        [PropertyUISelectionOption("Add Hours")]
        [PropertyUISelectionOption("Add Minutes")]
        [PropertyUISelectionOption("Add Seconds")]
        [PropertyUISelectionOption("Substract Years")]
        [PropertyUISelectionOption("Substract Months")]
        [PropertyUISelectionOption("Substract Days")]
        [PropertyUISelectionOption("Substract Hours")]
        [PropertyUISelectionOption("Substract Minutes")]
        [PropertyUISelectionOption("Substract Seconds")]
        [PropertyValidationRule("Calculation Method", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "Method")]
        [PropertyParameterOrder(6000)]
        public virtual string v_CalculationMethod { get; set; }

        [XmlAttribute]
        [PropertyDescription("Value to Add or Substruct")]
        [PropertyUIHelper(PropertyUIHelper.UIAdditionalHelperType.ShowVariableHelper)]
        [InputSpecification("")]
        [PropertyDetailSampleUsage("**5**", "Add or Substruct **5**")]
        [PropertyDetailSampleUsage("**{{{vValue}}}**", "Add or Substruct Value of Variable **vValue**")]
        [Remarks("Adding **-5** is same as Substructing **5**")]
        [PropertyShowSampleUsageInDescription(true)]
        [PropertyTextBoxSetting(1, false)]
        [PropertyValidationRule("Value", PropertyValidationRule.ValidationRuleFlags.Empty)]
        [PropertyDisplayText(true, "Value")]
        [PropertyParameterOrder(6001)]
        public virtual string v_Value { get; set; }

        [XmlAttribute]
        [PropertyInstanceType(PropertyInstanceType.InstanceType.DateTime, true)]
        public override string v_Result { get; set; }
    }
}