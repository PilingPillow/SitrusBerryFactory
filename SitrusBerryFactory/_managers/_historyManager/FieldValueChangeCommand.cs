using SitrusBerryFactory._managers._recordManager;

namespace SitrusBerryFactory._managers._historyManager
{
    public sealed class FieldValueChangeCommand : ICommand
    {
        private FieldValueHolder _target = null;
        private byte[] _oldData = null;
        private byte[] _newData = null;

        public string Desc { get; }

        public FieldValueChangeCommand
            (FieldValueHolder target,
            byte[] oldData,
            byte[] newData,
            string description)
        {
            _target = target;
            _oldData = (byte[])oldData.Clone(); // Clone to break the reference
            _newData = (byte[])newData.Clone();
            Desc = description;
        }

        public void Undo()
        {
            _target.BinaryData = _oldData;
        }

        public void Redo()
        {
            _target.BinaryData = _newData;
        }
    }
}
