using Controllers;
using Models;
using UnityEngine;

namespace Managers
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private PlayerCubeModel playerCubePrefab;

        public PlayerCubeModel PlayerCube { get; private set; }
        public void Setup()
        {
            SpawnPlayer();
            cameraController.Setup(PlayerCube.transform);
        }

        public void SavePlayerStats()
        {
            if (PlayerCube)
                PlayerCube.SetupStats();
        }

        public void ResetPlayer()
        {
            if (PlayerCube)
                PlayerCube.gameObject.SetActive(false);
        }

        private void SpawnPlayer()
        {
            PlayerCube = Instantiate(playerCubePrefab, transform.position, transform.rotation);
            PlayerCube.transform.SetParent(transform);
            PlayerCube.Setup();
        }
    }
}
