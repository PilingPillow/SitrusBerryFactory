using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SitrusBerryFactory._helpers
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
            btnPrev.Click -= BtnDecrease;
            btnNext.Click -= BtnIncrease;
            nud.ValueChanged -= UpdateBtnsToNud;

            var binding = _bindings.First(x => x.Nud == nud);
            _bindings.Remove(binding);
        }

        private static void BtnDecrease(object sender, EventArgs e)
        {
            var navigator = _bindings.First(x => x.PrevBtn == (Button)sender);

            var nud = navigator.Nud;
            if (nud.Value > nud.Minimum)
            {
                nud.Value--;
            }
        }

        private static void BtnIncrease(object sender, EventArgs e)
        {
            var navigator = _bindings.First(x => x.NextBtn == (Button)sender);

            var nud = navigator.Nud;
            if (nud.Value < nud.Maximum)
            {
                nud.Value++;
            }
        }

        private static void UpdateBtnsToNud(object sender, EventArgs e)
        {
            var nud = (NumericUpDown)sender;
            var navigator = _bindings.First(x => x.Nud == nud);

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
