using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SitrusBerryFactory._helpers
{
    public static class DrawExternalBorder
    {
        private static readonly Dictionary<Control, List<Control>> _externalBorders = new Dictionary<Control, List<Control>>();

        /// <summary>
        /// Draws external borders around the target controls.
        /// </summary>
        public static void AttachExternalBorder(Control parent, params Control[] targets)
        {
            _externalBorders[parent] = new List<Control>(targets);
            parent.Paint += BorderPaint;
            parent.Invalidate();
        }

        /// <summary>
        /// Removes all external borders drawn.
        /// </summary>
        public static void DetachExternalBorder(Control parent)
        {
            _externalBorders.Remove(parent);
            parent.Paint -= BorderPaint;
            parent.Invalidate();
        }

        private static void BorderPaint(object sender, PaintEventArgs e)
        {
            using (var pen = new Pen(Color.Gray, 1))
            {
                foreach (var target in _externalBorders[(Control)sender])
                {
                    var rect = new Rectangle(
                        target.Left - 1,
                        target.Top - 1,
                        target.Width + 1,
                        target.Height + 1);

                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
