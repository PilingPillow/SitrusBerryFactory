using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SitrusBerryFactory._helpers
{
    public static class LinkNudToBtns
    {
        private static readonly Dictionary<NumericUpDown, List<Button>> _nudToBtns = new Dictionary<NumericUpDown, List<Button>>();
        private static readonly Dictionary<Button, NumericUpDown> _btnToNud = new Dictionary<Button, NumericUpDown>();

        private enum btnOrder
        {
            Prev,
            Next,
        }

        /// <summary>
        /// Connects buttons to a NumericUpDown.
        /// </summary>
        public static void AttachBtnsToNud(NumericUpDown nud, Button btnPrev, Button btnNext)
        {
            _nudToBtns[nud] = new List<Button>() { btnPrev, btnNext };
            _btnToNud[btnPrev] = nud;
            _btnToNud[btnNext] = nud;

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

            _nudToBtns.Remove(nud);
            _btnToNud.Remove(btnPrev);
            _btnToNud.Remove(btnNext);
        }

        private static void BtnDecrease(object sender, EventArgs e)
        {
            var nud = _btnToNud[(Button)sender];
            if (nud.Value > nud.Minimum)
            {
                nud.Value--;
            }
        }

        private static void BtnIncrease(object sender, EventArgs e)
        {
            var nud = _btnToNud[(Button)sender];
            if (nud.Value < nud.Maximum)
            {
                nud.Value++;
            }
        }

        private static void UpdateBtnsToNud(object sender, EventArgs e)
        {
            var nud = (NumericUpDown)sender;
            var btns = _nudToBtns[nud];
            var prevBtn = btns[(int)btnOrder.Prev];
            var nextBtn = btns[(int)btnOrder.Next];

            // Keep focus on the NumericUpDown
            bool canGoPrev = nud.Value > nud.Minimum;
            if (!canGoPrev && prevBtn.Focused)
            {
                nud.Focus();
            }
            prevBtn.Enabled = canGoPrev;

            bool canGoNext = nud.Value < nud.Maximum;
            if (!canGoNext && nextBtn.Focused)
            {
                nud.Focus();
            }
            nextBtn.Enabled = canGoNext;
        }
    }
}
