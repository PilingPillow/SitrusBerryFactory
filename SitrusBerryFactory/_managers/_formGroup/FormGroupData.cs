using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Windows.Forms;

namespace SitrusBerryFactory._managers._formGroup
{
    public sealed class FormGroupData
    {
        public event EventHandler<Form> RefreshRequested = null; // To refresh other editors in the same group
        public dynamic CommonData = null;

        public FormGroupData()
        {
            CommonData = new ExpandoObject();
        }

        public void ClearData()
        {
            var dict = (IDictionary<string, object>)CommonData;
            dict.Clear();
        }

        /// <summary>
        /// Request UI refresh in other editors.
        /// </summary>
        public void RefreshOtherEditors(Form senderForm)
        {
            RefreshRequested?.Invoke(this, senderForm);
        }
    }
}
