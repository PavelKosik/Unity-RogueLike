using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float numberOfGold;
    public float health;
    public BaseSceneCoinTextScript baseSceneCoinTextScript;
    public bool load;
    public Canvas baseCanvas;
    public Canvas loadCanvas;
    public Canvas saveCanvas;
    // Start is called before the first frame update
    void Start()
    {
        baseSceneCoinTextScript = GetComponent<BaseSceneCoinTextScript>();
        saveCanvas.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // numberOfGold = baseSceneCoinTextScript.numberOfGold;
        if (load==false)
        {
            numberOfGold = baseSceneCoinTextScript.numberOfGold;
        }
    }


    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
        saveCanvas.gameObject.SetActive(true);
        loadCanvas.gameObject.SetActive(false);
        baseCanvas.gameObject.SetActive(false);
        // numberOfGold = baseSceneCoinTextScript.numberOfGold;
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        loadCanvas.gameObject.SetActive(false);
        baseCanvas.gameObject.SetActive(true);
        numberOfGold = data.numberOfGold;
        health = data.health;
        load = true;
    }
}
