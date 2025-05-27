using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class GameManager : Singleton<GameManager>
    {
        public PlayerSpawner PlayerSpawner => playerSpawner;
        
        [SerializeField] private PlayerSpawner playerSpawner;

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
