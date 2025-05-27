using Datas;
using Managers;
using Saves;
using UnityEngine;
using Views;

namespace Screens
{
    public class CharacteristicScreen : ViewScreen<CharacteristicView, CharacteristicData>
    {
        [SerializeField] private CharacteristicConfig config;
        
        public override void OpenScreen()
        {
            GameSaves.Instance.AddCoin(100);
            base.OpenScreen();
            Setup(config.Datas);
        }

        protected override void OnItemBought(CharacteristicData data)
        {
            base.OnItemBought(data);
            GameManager.Instance.PlayerSpawner.SavePlayerStats();
        }
    }
}  
