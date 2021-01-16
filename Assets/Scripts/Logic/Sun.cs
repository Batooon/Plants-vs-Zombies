using System;
using Data;

namespace Logic
{
    public interface IObservable
    {
        event Action<IObservable> DataChanged;
        void SetChanged();
    }

    public interface Observer
    {
        void SetModel();
    }

    public class Sun
    {
        public event Action SunCollected;
        private readonly int _sunAmount;
        private readonly PlayerData _playerData;

        public Sun(int cost, PlayerData playerData)
        {
            _sunAmount = cost;
            _playerData = playerData;
        }

        public void Collect()
        {
            _playerData.SunsAmount += _sunAmount;
            SunCollected?.Invoke();
        }
    }
}