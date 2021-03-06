using System;
using PvZ.Data;

namespace PvZ.Logic.Sun
{
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