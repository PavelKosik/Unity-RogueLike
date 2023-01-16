﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BaseSceneCoinTextScript : MonoBehaviour
{
    public float numberOfGold;
    public Text coinTextInBaseScene;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        CoinTextUpdate();
    }

    void CoinTextUpdate()
    {
        // numberOfGold = player.numberOfGold;
        if (player.load)
        {
            numberOfGold = player.numberOfGold;
        }
        coinTextInBaseScene.text = numberOfGold.ToString();
    }
}
