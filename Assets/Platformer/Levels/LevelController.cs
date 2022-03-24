using System;
using Platformer.Camera.Scripts;
using Platformer.Core;
using Platformer.DynamicBackground.Scripts;
using Platformer.MainPlayer.Scripts;
using Platformer.UI;
using UnityEngine;

namespace Platformer.Levels
{
	public class LevelController : IController
	{
		public event Action<GameState> OnControllerFinish;

		private GameObject _rootObject;
		private LevelView _levelViewPrefab;
		private PlayerView _playerViewPrefab;
		private CameraFollowing _cameraFollowing;
		private GameModel _gameModel;
		private GameUIView _gameUIView;

		private LevelView _currentLevel;
		private PlayerView _currentPlayer;

		public LevelController(GameObject rootObject, LevelView levelViewPrefab, PlayerView playerViewPrefab, CameraFollowing cameraFollowing, GameUIView gameUIView, GameModel gameModel)
		{
			_rootObject = rootObject;
			_levelViewPrefab = levelViewPrefab;
			_playerViewPrefab = playerViewPrefab;
			_cameraFollowing = cameraFollowing;
			_gameUIView = gameUIView;
			_gameModel = gameModel;
		}

		public void Run()
		{
			_currentLevel = GameObject.Instantiate(_levelViewPrefab, _rootObject.transform);
			_currentPlayer = GameObject.Instantiate(_playerViewPrefab, _currentLevel.enterView.enter);
			var parallaxComponents = _currentLevel.GetComponentsInChildren<Parallax>();
			foreach (var parallaxComponent in parallaxComponents)
			{
				parallaxComponent.mainCamera = _cameraFollowing.gameObject;
			}
			_cameraFollowing.camTarget = _currentPlayer.transform;
			
			_gameUIView.gameObject.SetActive(true);
			_gameUIView.coinCounter.text = _gameModel.collectedCoins.ToString();
			_currentPlayer.CoinCollected += CoinCollected;
			_currentLevel.exitView.OnPlayerExit += Stop;
		}

		private void CoinCollected()
		{
			_gameModel.collectedCoins++;
			_gameUIView.coinCounter.text = _gameModel.collectedCoins.ToString();
		}

		private void Stop()
		{
			_currentPlayer.CoinCollected -= CoinCollected;
			_currentLevel.exitView.OnPlayerExit -= Stop;
			_gameUIView.gameObject.SetActive(false);
			GameObject.Destroy(_currentPlayer.gameObject);
			GameObject.Destroy(_currentLevel.gameObject);
			_gameModel.currentLevel++;
			OnControllerFinish?.Invoke(GameState.FinishLevel);
		}
	}
}