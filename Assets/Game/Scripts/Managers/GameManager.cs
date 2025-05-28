using Controllers;
using Models;
using Screens;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private PlayerCubeFactory playerCubeFactory;
        
        private PlayerCubeModel _playerCube;
        
        private void Start()
        {
            uiManager.GetScreen<GameScreen>().StartGameAction += SetupGame;
            uiManager.GetScreen<GameScreen>().ResetGameAction += ResetGame;
            uiManager.GetScreen<CharacteristicScreen>().UpgradeCharacteristicAction += UpdateStatsPlayer;
            
            uiManager.GetScreen<GameScreen>().OpenScreen();
        }

        private void OnDestroy()
        {
            uiManager.GetScreen<GameScreen>().StartGameAction -= SetupGame;
            uiManager.GetScreen<GameScreen>().ResetGameAction -= ResetGame;
            uiManager.GetScreen<CharacteristicScreen>().UpgradeCharacteristicAction -= UpdateStatsPlayer;
        }

        private void SetupGame()
        {
            _playerCube = playerCubeFactory.CreatePlayer(Vector3.zero,Quaternion.identity,transform);
            _playerCube.Setup();
            cameraController.Setup(_playerCube.transform);
        }

        private void UpdateStatsPlayer()
        {
            if(_playerCube)
                _playerCube.SetupStats();
        }

        private void ResetGame()
        {
            _playerCube.ResetPlayer();
        }
    }
}
