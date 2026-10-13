using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SitrusBerryFactory._utilities
{
    public sealed class NudBtnBinding
    {
        public NumericUpDown Nud { get; }
        public Button PrevBtn { get; }
        public Button NextBtn { get; }

        public NudBtnBinding(
            NumericUpDown nud, 
            Button prevBtn, 
            Button nextBtn)
        {
            Nud = nud;
            PrevBtn = prevBtn;
            NextBtn = nextBtn;
        }
    }

    public static class LinkNudToBtns
    {
        private static readonly List<NudBtnBinding> _bindings = new List<NudBtnBinding>();

        /// <summary>
        /// Connects buttons to a NumericUpDown.
        /// </summary>
        public static void AttachBtnsToNud(NumericUpDown nud, Button btnPrev, Button btnNext)
        {
            var binding = new NudBtnBinding(nud, btnPrev, btnNext);
            _bindings.Add(binding);

            btnPrev.Click += BtnDecrease;
            btnNext.Click += BtnIncrease;
            nud.ValueChanged += UpdateBtnsToNud;

            // Set the initial state
            UpdateBtnsToNud(nud, EventArgs.Empty);
        }

        /// <summary>
        /// Disconnects buttons from a NumericUpDown.
        /// </summary>
        public static void DetachBtnsToNud(NumericUpDown nud, Button btnPrev, Button btnNext)
        {
            var binding = _bindings.FirstOrDefault(x => x.Nud == nud);
            if (binding == null) return;

            btnPrev.Click -= BtnDecrease;
            btnNext.Click -= BtnIncrease;
            nud.ValueChanged -= UpdateBtnsToNud;

            _bindings.Remove(binding);
        }

        private static void BtnDecrease(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;

            var navigator = _bindings.FirstOrDefault(x => x.PrevBtn == btn);
            if (navigator == null) return;

            var nud = navigator.Nud;
            if (nud.Value > nud.Minimum)
            {
                nud.Value--;
            }
        }

        private static void BtnIncrease(object sender, EventArgs e)
        {
            if (!(sender is Button btn)) return;

            var navigator = _bindings.FirstOrDefault(x => x.NextBtn == btn);
            if (navigator == null) return;

            var nud = navigator.Nud;
            if (nud.Value < nud.Maximum)
            {
                nud.Value++;
            }
        }

        private static void UpdateBtnsToNud(object sender, EventArgs e)
        {
            if (!(sender is NumericUpDown nud)) return;

            var navigator = _bindings.FirstOrDefault(x => x.Nud == nud);
            if (navigator == null) return;

            // Keep focus on the NumericUpDown
            bool canGoPrev = nud.Value > nud.Minimum;
            if (!canGoPrev && navigator.PrevBtn.Focused)
            {
                nud.Focus();
            }
            navigator.PrevBtn.Enabled = canGoPrev;

            bool canGoNext = nud.Value < nud.Maximum;
            if (!canGoNext && navigator.NextBtn.Focused)
            {
                nud.Focus();
            }
            navigator.NextBtn.Enabled = canGoNext;
        }
    }
}
