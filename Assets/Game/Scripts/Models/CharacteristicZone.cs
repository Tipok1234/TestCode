using Managers;
using Screens;
using UnityEngine;

namespace Models
{
    public class CharacteristicZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (IsPlayer(other))
            {
                UIManager.Instance.OpenScreen<CharacteristicScreen>();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (IsPlayer(other))
            {
                UIManager.Instance.CloseScreen<CharacteristicScreen>();
            }
        }

        private bool IsPlayer(Collider collider)
        {
            return collider.CompareTag("Player");
        }
    }
}
