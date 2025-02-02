﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Camera.main.GetComponent<Level>().SetLevelAimScore(int.Parse(Camera.main.GetComponent<Level>().TextScoreLines[int.Parse(gameObject.tag)]));
    }
}
