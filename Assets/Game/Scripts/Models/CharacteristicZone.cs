using Managers;
using Screens;
using UnityEngine;

namespace Models
{
    public class CharacteristicZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                UIManager.Instance.OpenScreen<CharacteristicScreen>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                UIManager.Instance.CloseScreen<CharacteristicScreen>();
            }
        }
    }
}
