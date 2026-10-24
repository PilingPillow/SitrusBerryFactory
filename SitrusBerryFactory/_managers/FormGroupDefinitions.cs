using System;

namespace SitrusBerryFactory._managers
{
    /// <summary>
    /// Refreshes the UI after undo/redo.
    /// </summary>
    public interface IEditorRefresh
    {
        void RefreshUI();
    }

    /// <summary>
    /// Specifies the form group and display order.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class FormGroupAttribute : Attribute
    {
        public FormGroup Group { get; }
        public int Order { get; }

        // Use the default when order is irrelevant
        public FormGroupAttribute(FormGroup group, int order = -1)
        {
            Group = group;
            Order = order;
        }
    }

    /// <summary>
    /// Defines the available form groups.
    /// </summary>
    public enum FormGroup
    {
        Map,
        Tileset,

        TrainerClass,
        TrainerSprite,
    }
}
