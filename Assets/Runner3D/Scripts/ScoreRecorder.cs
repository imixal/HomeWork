using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreRecorder : MonoBehaviour
{
    private Text _text;
    [SerializeField]
    private Transform player;

    private void Awake()
    {
        _text = GetComponent<Text>(); 
    }

    private void Update()
    {
        _text.text = player.position.z.ToString("F1");
    }
}
