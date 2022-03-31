using System;
using System.Linq;
using Common.Scripts.Service;
using Runner3D.Scripts.Models;
using Runner3D.Scripts.Views;
using UnityEngine;

namespace Runner3D.Scripts.Core
{
    public class GameContext : MonoBehaviour, IGameContext
    {
        public static IGameContext Instance;
	
        [SerializeField] private Sound[] sounds;
        [SerializeField] private UIView[] views;

        private UIView _currentView;

        public IAudioService AudioService { get; private set;}
        public ISaveService SaveService { get; private set; }
        public ISceneService SceneService { get; private set; }
		
        public ICameraService CameraService { get; private set; }

        private void Awake()
        {
            foreach (var sound in sounds)
            {
                sound.source = gameObject.AddComponent<AudioSource>();
            }
            AudioService = new AudioService(sounds);
            SaveService = new SaveService();
            SceneService = new SceneService();
            CameraService = new CameraService(Camera.main);
			
            CheckModels();
			
            if(Instance == null)
                Instance = this;
        }

        private void Start()
        {
            _currentView = views.First(v => v.ViewName == nameof(MenuRunnerUIView));
            _currentView.Show();
        }

        public void ShowView(string viewName)
        {
            var tweener = _currentView.Hide();
            tweener.onComplete += () =>
            {
                _currentView = views.First(v => v.ViewName == viewName);
                _currentView.Show();
            };
        }
		
        public void HideView()
        {
            _currentView.Hide();
        }

        private void CheckModels()
        {
            var pm = SaveService.Load<ProgressModel>();
            if (pm == null)
            {
                pm = new ProgressModel();
                SaveService.Write(pm);
            }

            var s = SaveService.Load<SettingsModel>();
            if (s == null)
            {
                s = new SettingsModel();
                SaveService.Write(s);
            }
        }
    }
}