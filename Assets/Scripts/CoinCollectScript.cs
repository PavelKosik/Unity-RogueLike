using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class CoinCollectScript : MonoBehaviour
{
    public int numberOfGold;
    public Text coinText;
    public DungeonCreator dungeonCreator;
    public BaseSceneCoinTextScript baseSceneCoinTextScript;
    public GameObject dungeonSquareSceneCoinImage;
    // Start is called before the first frame update
    void Start()
    {
        dungeonSquareSceneCoinImage = GameObject.FindGameObjectWithTag("DungeonSquareSceneCoinImage");
        dungeonSquareSceneCoinImage.SetActive(false);
        dungeonCreator = FindObjectOfType<DungeonCreator>();
        baseSceneCoinTextScript = FindObjectOfType<BaseSceneCoinTextScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene()!=SceneManager.GetSceneByBuildIndex(2))
        {
            dungeonSquareSceneCoinImage.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            numberOfGold += 1;
            collision.gameObject.SetActive(false);
            coinText.text = numberOfGold.ToString();
            dungeonCreator.numberOfGold += 1;
            baseSceneCoinTextScript.numberOfGold += 1;
        }
    }
}
