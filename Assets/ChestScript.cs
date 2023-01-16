using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestScript : MonoBehaviour
{
    public GameObject player;
    public bool playerIsNear;
    public GameObject coinPrefab;
    public bool chestOpened;
    public float minNumberOfCoins;
    public float maxNumberOfCoins;
    public float numberOfCoins;
    public GameObject[] coin;
    public Vector2 offSet;
    public Text openTheChestText;
    // Start is called before the first frame update
    void Start()
    {
        numberOfCoins = Random.Range(minNumberOfCoins, maxNumberOfCoins);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfPlayerIsNear();
        OpenChest();
    }

    void CheckIfPlayerIsNear()
    {
        if ((transform.position.x - player.transform.position.x <= 1.2f && player.transform.position.x - transform.position.x <= 1.2f) && (transform.position.y - player.transform.position.y <= 1.2f && player.transform.position.y - transform.position.y <= 1.2f))
        {
            playerIsNear = true;
            openTheChestText.gameObject.SetActive(true);
        }

        else
        {
            playerIsNear = false;
            openTheChestText.gameObject.SetActive(false);
        }
    }

    void OpenChest()
    {
        if (playerIsNear&&Input.GetKeyDown("e")&&chestOpened==false)
        {
            chestOpened = true;
            SpawnCoins();
        }
    }

    void SpawnCoins()
    {
        for (int i = 0; i < numberOfCoins; i++)
        {
            coin[i] = Instantiate(coinPrefab);
            if (i == 0)
            {
                coin[i].transform.position = new Vector2(transform.position.x+offSet.x, transform.position.y+offSet.y);
            }

            else
            {
                coin[i].transform.position = new Vector2(coin[i - 1].transform.position.x + Random.Range(-0.1f, 0.1f), coin[i - 1].transform.position.y + Random.Range(-0.1f, 0.1f));
            }
        }
    }
}
