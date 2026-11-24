using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SitrusBerryFactory._helpers
{
    public static class LinkRbToCtrl
    {
        private static readonly Dictionary<Control, RadioButton> _ctrlToRb = new Dictionary<Control, RadioButton>();
        private static readonly Dictionary<RadioButton, Control> _rbToCtrl = new Dictionary<RadioButton, Control>();

        /// <summary>
        /// Links a radio button to a control.
        /// </summary>
        public static void AttachRbToCtrl(RadioButton rb, Control ctrl)
        {
            _ctrlToRb[ctrl] = rb;
            _rbToCtrl[rb] = ctrl;

            ctrl.Enter += CtrlEnter;
            rb.CheckedChanged += RbChecked;
        }

        /// <summary>
        /// Removes the link between a radio button and a control.
        /// </summary>
        public static void DetachRbToCtrl(RadioButton rb, Control ctrl)
        {
            _ctrlToRb.Remove(ctrl);
            _rbToCtrl.Remove(rb);

            ctrl.Enter -= CtrlEnter;
            rb.CheckedChanged -= RbChecked;
        }

        private static void CtrlEnter(object sender, EventArgs e)
        {
            var rb = _ctrlToRb[(Control)sender];
            rb.Checked = true;
        }

        private static void RbChecked(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            if (rb.Checked)
            {
                _rbToCtrl[rb].Focus();
            }
        }
    }
}
