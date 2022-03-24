using System.Collections.Generic;
using Platformer.Camera.Scripts;
using Platformer.Levels;
using Platformer.MainPlayer.Scripts;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Core
{
    public enum GameState
    {
        MainMenu,
        Level,
        FinishLevel,
        FailedLevel
    }
    public class GameManager : MonoBehaviour
    {
        public MainMenuView mainMenuView;
        public GameUIView gameUIView;
        public GameModel gameModel;
        public List<LevelView> levelPrefabs;
        public PlayerView playerViewPrefab;
        public CameraFollowing cameraFollowing;

        private IController _currentController;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            PlayState(GameState.MainMenu);
        }

        private void PlayState(GameState state)
        {
            if (_currentController != null)
                _currentController.OnControllerFinish -= PlayState;
            switch (state)
            {
                case GameState.MainMenu:
                    _currentController = new MainMenuController(mainMenuView);
                    break;
                case GameState.FinishLevel:
                case GameState.Level:
                    if (gameModel.currentLevel > levelPrefabs.Count)
                        gameModel.currentLevel = 1;
                    _currentController = new LevelController(gameObject, levelPrefabs[gameModel.currentLevel - 1],
                        playerViewPrefab, cameraFollowing, gameUIView, gameModel);
                    break;
            } 
            _currentController.OnControllerFinish += PlayState;
            _currentController.Run();
        }
    }
}