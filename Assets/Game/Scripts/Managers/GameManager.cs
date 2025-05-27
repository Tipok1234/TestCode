using Screens;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerSpawner PlayerSpawner => playerSpawner;
        
        [SerializeField] private PlayerSpawner playerSpawner;

        private void Start()
        {
            UIManager.Instance.GetScreen<GameScreen>().StartGameAction += SetupGame;
            UIManager.Instance.GetScreen<GameScreen>().ResetGameAction += ResetGame;
        }

        private void OnDestroy()
        {
            UIManager.Instance.GetScreen<GameScreen>().StartGameAction -= SetupGame;
            UIManager.Instance.GetScreen<GameScreen>().ResetGameAction -= ResetGame;
        }

        public void SetupGame()
        {
            playerSpawner.Setup();
        }

        public void ResetGame()
        {
            playerSpawner.ResetPlayer();   
        }
    }
}
