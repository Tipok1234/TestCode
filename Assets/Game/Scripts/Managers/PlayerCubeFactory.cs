using Models;
using UnityEngine;

namespace Managers
{
    public class PlayerCubeFactory : MonoBehaviour
    {
        [SerializeField] private PlayerCubeModel playerPrefab;
        
        public PlayerCubeModel CreatePlayer(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var player = GameObject.Instantiate(playerPrefab, position, rotation, parent);
            return player;
        }
    }
}
