using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyMoreHPScript : MonoBehaviour
{
    public Player player;
    public BaseSceneCoinTextScript BaseSceneCoinTextScript;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuyMoreHp()
    {
        if (BaseSceneCoinTextScript.numberOfGold >= 10.0f)
        {
            player.health += 10.0f;
            // player.numberOfGold -= 10.0f;
            BaseSceneCoinTextScript.numberOfGold -= 10.0f;

        }
    }

}
