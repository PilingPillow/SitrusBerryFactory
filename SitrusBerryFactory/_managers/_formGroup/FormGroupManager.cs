using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SitrusBerryFactory._managers._formGroup
{
    public sealed class FormGroupManager
    {
        public event EventHandler Closed = null; // Updates the main form state
        private Form _owner = null;
        private List<Form> _editors = null;
        private FormGroupData _data = null;

        public FormGroupManager(Form owner, FormGroup kind)
        {
            _owner = owner;
            _editors = new List<Form>();

            // Find forms in the group and sort them by order
            var formInfos = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => typeof(Form).IsAssignableFrom(t))
                .Select(t => new
                {
                    Type = t,
                    Attribute = t.GetCustomAttribute<FormGroupAttribute>()
                })
                .Where(x => x.Attribute?.Group == kind)
                .OrderBy(x => x.Attribute.Order) // sorting
                .ToList();

            // Create group data when the group has multiple forms
            if (formInfos.Any(x => x.Attribute.Order >= 0))
            {
                _data = new FormGroupData();
                _data.RefreshRequested += RefreshForms;
            }

            foreach (var info in formInfos)
            {
                var form = _data != null
                    ? (Form)Activator.CreateInstance(info.Type, _data)
                    : (Form)Activator.CreateInstance(info.Type);
                form.FormClosed += SingleForm_FormClosed;
                _editors.Add(form);
            }
        }

        /// <summary>
        /// Refresh the UI of each editor, optionally excluding one form.
        /// </summary>
        public void RefreshForms(object sender = null, Form excludeForm = null)
        {
            foreach (var form in _editors)
            {
                // Skip the excluded form to prevent unnecessary refreshes
                if (excludeForm != null && ReferenceEquals(form, excludeForm))
                {
                    continue;
                }

                var refreshable = (IEditorRefresh)form;
                refreshable.RefreshUI();
            }
        }

        /// <summary>
        /// Close all forms in the group when one closes.
        /// </summary>
        private void SingleForm_FormClosed(object sender, EventArgs e)
        {
            foreach (var form in _editors)
            {
                if (ReferenceEquals(form, sender))
                {
                    continue; // Skip the closed form
                }

                if (!form.IsDisposed)
                {
                    form.FormClosed -= SingleForm_FormClosed;
                    form.Close();
                }
            }
            _editors.Clear();
            _editors = null;
            _data?.ClearData();
            _data = null;

            // Bring the owner form to the front
            _owner.BringToFront();
            Closed.Invoke(this, EventArgs.Empty);
        }

        public void ShowFormGroup()
        {
            foreach (var form in _editors)
            {
                form.Show(_owner);
            }
        }
    }
}
