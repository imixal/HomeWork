using System;
using System.Collections.Generic;
using Platformer.Objects.Coin;
using UnityEngine;

namespace Platformer.MainPlayer.Scripts
{
    public class PlayerView : MonoBehaviour
    {
        public event Action CoinCollected;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var coin = other.gameObject.GetComponent<CoinView>();
            if (coin != null)
            {
                Destroy(coin.gameObject);
                CoinCollected.Invoke();
            }
        }
    }
}