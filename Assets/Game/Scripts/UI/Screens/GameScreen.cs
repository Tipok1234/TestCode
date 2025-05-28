using System;

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
        }

        private void SetupGame()
        {
            StartGameAction?.Invoke();
        }

        private void ResetGame()
        {
            ResetGameAction?.Invoke();
        }
    }
}
