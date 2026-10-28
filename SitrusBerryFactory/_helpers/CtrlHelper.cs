using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using SitrusBerryFactory._utilities;

namespace SitrusBerryFactory._helpers
{
    public static class CtrlHelper
    {
        /// <summary>
        /// Enables or disables controls recursively.
        /// </summary>
        public static void SetControlsEnabled(
            this Control container,
            bool enabled,
            bool includeSelf = true,
            IEnumerable<string> excludeNames = null,
            IEnumerable<Type> excludeTypes = null)
        {
            foreach (var ctrl in container.GetTargetControls(includeSelf, excludeNames, excludeTypes))
            {
                ctrl.Enabled = enabled;
            }
        }

        /// <summary>
        /// Resets controls recursively.
        /// </summary>
        public static void ResetControls(
            this Control container,
            bool includeSelf = true,
            IEnumerable<string> excludeNames = null,
            IEnumerable<Type> excludeTypes = null)
        {
            foreach (var ctrl in container.GetTargetControls(includeSelf, excludeNames, excludeTypes))
            {
                switch (ctrl)
                {
                    case TextBox textBox:
                        textBox.Text = string.Empty;
                        break;
                    case NumericUpDown nud:
                        nud.Value = Math.Max(nud.Minimum, 0);
                        break;
                    case ComboBox comboBox:
                        comboBox.SelectedIndex = BinaryConstants.InvalidValue;
                        break;
                    case CheckBox checkBox:
                        checkBox.Checked = false;
                        break;
                    case RadioButton radioButton:
                        radioButton.Checked = false;
                        break;
                }
            }
        }

        private static List<Control> GetTargetControls(
            this Control container,
            bool includeSelf,
            IEnumerable<string> excludeNames,
            IEnumerable<Type> excludeTypes)
        {
            var results = new List<Control>();
            var nameSet = excludeNames?.ToList();
            var typeSet = excludeTypes?.ToList();

            if (includeSelf && !IsExcluded(container))
            {
                results.Add(container);
            }

            SearchCtrl(container);
            return results;

            bool IsExcluded(Control ctrl) =>
                (nameSet?.Contains(ctrl.Name) ?? false) || (typeSet?.Contains(ctrl.GetType()) ?? false);

            void SearchCtrl(Control parent)
            {
                if (!ShouldRecurse(parent))
                {
                    return;
                }

                foreach (Control child in parent.Controls)
                {
                    if (!IsExcluded(child))
                    {
                        results.Add(child);
                    }

                    SearchCtrl(child);
                }
            }

            // Limit recursion to known container types
            bool ShouldRecurse(Control ctrl)
            {
                return ctrl is Form ||
                       ctrl is Panel ||
                       ctrl is GroupBox ||
                       ctrl is TabControl ||
                       ctrl is TabPage;
            }
        }

        /// <summary>
        /// Sets ComboBox items and selects the default item.
        /// </summary>
        public static void SetupCmbItems(
            this ComboBox cmb,
            int defaultIndex = 0,
            params string[] items)
        {
            try
            {
                cmb.BeginUpdate();
                cmb.Items.Clear();
                cmb.Items.AddRange(items);

                cmb.SelectedIndex = items.Length == 0
                    ? BinaryConstants.InvalidValue
                    : defaultIndex;
            }
            finally
            {
                cmb.EndUpdate();
            }
        }

        /// <summary>
        /// Loads ComboBox items from file in the format "[XX]ItemName".
        /// </summary>
        public static void LoadComboBoxFromFile(params (ComboBox Cmb, string Path)[] targets)
        {
            foreach (var target in targets)
            {
                var entries = new List<KeyValuePair<byte, string>>();

                foreach (string line in File.ReadLines(target.Path, Encoding.UTF8))
                {
                    // Skip blank lines and comments
                    if (string.IsNullOrWhiteSpace(line) || line.StartsWith(";"))
                    {
                        continue;
                    }

                    // Parse the value inside the brackets
                    int closeBracketIndex = line.IndexOf(']');
                    var hex = line.Substring(1, closeBracketIndex - 1).ParseStringToInt();

                    var entry = new KeyValuePair<byte, string>((byte)hex, line);
                    entries.Add(entry);
                }

                // Bind the entries
                target.Cmb.DisplayMember = nameof(KeyValuePair<byte, string>.Value);
                target.Cmb.ValueMember = nameof(KeyValuePair<byte, string>.Key);
                target.Cmb.DataSource = entries;
            }
        }

        public static void EnableDoubleBuffering(params Control[] controls)
        {
            var property = typeof(Control).GetProperty(
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var ctrl in controls)
            {
                property.SetValue(ctrl, true, null);
            }
        }
    }
}
