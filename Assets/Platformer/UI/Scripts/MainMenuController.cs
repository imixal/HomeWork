using System;
using Platformer.Core;

namespace Platformer.UI
{
    public class MainMenuController : IController
    {
        public event Action<GameState> OnControllerFinish;

        private MainMenuView _mainMenuView;

        public MainMenuController(MainMenuView mainMenuView)
        {
            _mainMenuView = mainMenuView;
        }

        public void Run()
        {
            _mainMenuView.gameObject.SetActive(true);
            _mainMenuView.startButton.onClick.AddListener(Stop);
        }

        private void Stop()
        {
            _mainMenuView.startButton.onClick.RemoveListener(Stop);
            _mainMenuView.gameObject.SetActive(false);
            OnControllerFinish?.Invoke(GameState.Level);
        }
    }
}
