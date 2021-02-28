namespace PvZ.Logic.GameField
{
    public class Cell
    {
        private bool _isEmpty = true;

        public bool IsEmpty
        {
            get => _isEmpty;
            set =>_isEmpty = value;
        }

    }
}