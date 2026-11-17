using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SitrusBerryFactory._helpers
{
    public static class LinkRbToCtrl
    {
        private static readonly List<RbLink> _rbLinks = new List<RbLink>();

        private sealed class RbLink
        {
            public RadioButton Rb { get; }
            public Control Ctrl { get; }

            public RbLink(RadioButton rb, Control ctrl)
            {
                Rb = rb;
                Ctrl = ctrl;
            }
        }

        /// <summary>
        /// Links a radio button to a control.
        /// </summary>
        public static void AttachRbToCtrl(RadioButton rb, Control ctrl)
        {
            var link = new RbLink(rb, ctrl);
            _rbLinks.Add(link);

            ctrl.Enter += CtrlEnter;
            rb.CheckedChanged += RbChecked;
        }

        /// <summary>
        /// Removes the link between a radio button and a control.
        /// </summary>
        public static void DetachRbToCtrl(RadioButton rb, Control ctrl)
        {
            var link = _rbLinks.First(x => x.Rb == rb && x.Ctrl == ctrl);

            ctrl.Enter -= CtrlEnter;
            rb.CheckedChanged -= RbChecked;
            _rbLinks.Remove(link);
        }

        private static void CtrlEnter(object sender, EventArgs e)
        {
            var link = _rbLinks.First(x => x.Ctrl == (Control)sender);
            link.Rb.Checked = true;
        }

        private static void RbChecked(object sender, EventArgs e)
        {
            var link = _rbLinks.First(x => x.Rb == (RadioButton)sender);
            if (link.Rb.Checked)
            {
                link.Ctrl.Focus();
            }
        }
    }
}
