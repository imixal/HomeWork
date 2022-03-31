using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField] 
    private GameObject gameOver;

    private bool _isGameOver = false;

    private void Update()
    {
        if (player.position.y < 0 && !_isGameOver)
        {
            gameOver.SetActive(true);
            player.gameObject.SetActive(false);
            Destroy(player);
            _isGameOver = true;
        }
    }
}
