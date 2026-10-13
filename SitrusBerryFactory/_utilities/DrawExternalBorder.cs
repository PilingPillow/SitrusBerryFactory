using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SitrusBerryFactory._utilities
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
            if (!(sender is Control parent) || !_externalBorders.TryGetValue(parent, out var targets)) return;

            using (var pen = new Pen(Color.Gray, 1))
            {
                foreach (var target in targets)
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
