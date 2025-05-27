using System.Collections.Generic;
using UnityEngine;
using System;
using Enum;

namespace Datas
{
    [CreateAssetMenu(menuName = "CharacteristicConfig")]
    public class CharacteristicConfig : ScriptableObject
    {
        public List<CharacteristicData> Datas = new List<CharacteristicData>();
    }

    [Serializable]
    public class CharacteristicData
    {
        public CharacteristicType Type;
        public string Description;
        
        public float Price;
        public float Value;
    }
}
