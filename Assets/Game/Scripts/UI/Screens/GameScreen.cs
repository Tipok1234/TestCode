using System;
using Managers;

namespace Screens
{
    public class GameScreen : BaseScreen
    {
        public event Action StartGameAction;
        public event Action ResetGameAction;
        
        public override void OpenScreen()
        {
            base.OpenScreen();

            SetupGame();
        }

        public override void CloseScreen()
        {
            base.CloseScreen();
            
            ResetGame();
            
            if(GameManager.Instance != null)
                GameManager.Instance.ResetGame();
        }

        private void SetupGame()
        {
            if(GameManager.Instance != null)
                GameManager.Instance.SetupGame();
            
            StartGameAction?.Invoke();
        }

        private void ResetGame()
        {
            ResetGameAction?.Invoke();
        }
    }
}
