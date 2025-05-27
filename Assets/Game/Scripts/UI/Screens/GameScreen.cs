using Managers;

namespace Screens
{
    public class GameScreen : BaseScreen
    {
        public override void OpenScreen()
        {
            base.OpenScreen();
            
            if(GameManager.Instance != null)
                GameManager.Instance.SetupGame();
        }

        public override void CloseScreen()
        {
            base.CloseScreen();
            
            if(GameManager.Instance != null)
                GameManager.Instance.ResetGame();
        }
    }
}
