using System;
using Datas;
using DataUtils;
using UnityEngine;
using Views;

namespace Screens
{
    public class CharacteristicScreen : ViewScreen<CharacteristicView, CharacteristicData>
    {
        public event Action UpgradeCharacteristicAction;
        
        [SerializeField] private CharacteristicConfig config;
        
        public override void OpenScreen()
        {
            //TODO: FOR Test upgrages
            GameSaves.Instance.AddCoin(100);
            
            base.OpenScreen();
            Setup(config.Datas);
        }

        protected override void OnItemBought(CharacteristicData data)
        {
            base.OnItemBought(data);
            UpgradeCharacteristicAction?.Invoke();
        }
    }
}  
