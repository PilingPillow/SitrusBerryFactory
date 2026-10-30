using System;
using System.ComponentModel;
using System.Windows.Forms;
using SitrusBerryFactory._managers;

namespace SitrusBerryFactory._utilities._customCtrls
{
    public sealed class StrTextBox : TextBox
    {
        private int _allowedLength = 1;
        private bool _needTerminator = true;

        /// <summary>
        /// Assign CharmapManager instance before use.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CharmapManager CharmapManager { get; set; }

        /// <summary>
        /// Gets or sets the maximum allowed length in bytes.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(1)]
        [Description("Specifies the maximum allowed input length in bytes.")]
        public int AllowedLength
        {
            get => _allowedLength;
            set
            {
                // Ensure the value is at least 1
                if (value < 1) value = 1;

                _allowedLength = value;
                ValidateTextLength();
            }
        }

        /// <summary>
        /// Gets or sets whether to include a terminator.
        /// </summary>
        [Browsable(true)]
        [Category("Behavior")]
        [DefaultValue(true)]
        [Description("Specifies whether to include a terminator when validating the text.")]
        public bool NeedTerminator
        {
            get => _needTerminator;
            set
            {
                _needTerminator = value;
                ValidateTextLength();
            }
        }

        /// <summary>
        /// Validates the text whenever it changes.
        /// </summary>
        protected override void OnTextChanged(EventArgs e)
        {
            base.OnTextChanged(e);
            ValidateTextLength();
        }

        /// <summary>
        /// Validates and truncates the current text.
        /// </summary>
        private void ValidateTextLength()
        {
            if (CharmapManager == null || string.IsNullOrEmpty(Text)) return;

            // Validate and truncate the text
            Text = CharmapManager.TextLengthValidate(Text, AllowedLength, NeedTerminator);

            // Move the caret to the end
            SelectionStart = Text.Length;
            SelectionLength = 0;
        }
    }
}
