using System;
using Platformer.MainPlayer.Scripts;
using UnityEngine;

namespace Platformer.Objects.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class ExitView : MonoBehaviour
    {
        public event Action OnPlayerExit;
        private void OnTriggerEnter2D(Collider2D other)
        {
            var playerView = other.gameObject.GetComponent<PlayerView>();
            if (playerView != null)
            {
                OnPlayerExit?.Invoke();
            }
        }
    }
}