using System;
using System.Collections;
using System.Collections.Generic;
using Core.Services.Interfaces;
using UnityEngine;
using UnityEngine.UI;

public class model
{
    public string v1;
    public int v2;
}

public class Test : MonoBehaviour
{
    public InputField text;
    public InputField number;
    public Button btn;
    public ISaveService SaveService;
    void Start()
    {
        SaveService = new SaveService();
        var model = SaveService.Load<model>("model");
        if (model != null)
        {
            text.text = model.v1;
            number.text = model.v2.ToString();

        }
        btn.onClick.AddListener((() =>
        {
            
            SaveService.Write(new model(){v1 = text.text,v2 = Convert.ToInt32(number.text)}, "model");
            SaveService.Save();
        }));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
