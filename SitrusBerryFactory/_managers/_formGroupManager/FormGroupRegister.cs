using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._managers._formGroupManager
{
    public sealed class FormGroupRegister
    {
        public FormGroupData GroupData { get; set; }
        public EventHandler Closed { get; set; } // Updates the main UI state

        private Form _ownerForm = null;
        private List<Form> _forms = null;

        public FormGroupRegister(
            Form ownerForm,
            FormGroup group,
            SharedData sharedData)
        {
            _ownerForm = ownerForm;
            _forms = new List<Form>();

            // Find forms in the group and sort them by order
            var formInfos = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Form).IsAssignableFrom(t))
                .Select(t => new
                {
                    Type = t,
                    Attribute = t.GetCustomAttribute<FormGroupAttribute>()
                })
                .Where(x => x.Attribute?.Group == group)
                .OrderBy(x => x.Attribute.Order)
                .ToList();

            // Create group data when the group has multiple forms
            if (formInfos.Any(x => x.Attribute.Order >= 0))
            {
                GroupData = new FormGroupData();
                GroupData.RefreshRequested += RefreshForms;
            }

            foreach (var info in formInfos)
            {
                var form = GroupData != null
                    ? (Form)Activator.CreateInstance(info.Type, sharedData, GroupData)
                    : (Form)Activator.CreateInstance(info.Type, sharedData);

                form.FormClosed += SingleForm_FormClosed;
                _forms.Add(form);
            }
        }

        public void ShowFormGroup()
        {
            foreach (var form in _forms)
            {
                form.Show(_ownerForm);
            }
        }

        /// <summary>
        /// Close all forms in the group when one closes.
        /// </summary>
        private void SingleForm_FormClosed(object sender, EventArgs e)
        {
            foreach (var form in _forms)
            {
                if (ReferenceEquals(form, sender)) continue; // Skip the closed form

                if (!form.IsDisposed)
                {
                    form.FormClosed -= SingleForm_FormClosed;
                    form.Close();
                }
            }
            _forms.Clear();
            _forms = null;
            GroupData?.ClearDict();
            GroupData = null;

            // Bring the owner form to the front
            _ownerForm.BringToFront();
            Closed.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Refresh the UI of each editor, optionally excluding one form.
        /// </summary>
        public void RefreshForms(object sender = null, Form excludeForm = null)
        {
            foreach (var form in _forms)
            {
                // Skip disposed forms
                if (form.IsDisposed) continue;

                // Skip the excluded form to prevent unnecessary refreshes
                if (excludeForm != null && ReferenceEquals(form, excludeForm)) continue;

                if (form is IEditorRefresh refreshable)
                {
                    refreshable.RefreshUI();
                }
            }
        }
    }
}
