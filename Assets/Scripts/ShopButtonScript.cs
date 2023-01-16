using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtonScript : MonoBehaviour
{

    public GameObject[] uiNotInShop;
    public GameObject[] uiInShop;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<uiInShop.Length;i++)
        {
            uiInShop[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

   public void SetupShopUI()
    {
        for (int i=0;i<uiNotInShop.Length;i++)
        {
            uiNotInShop[i].SetActive(false);
        }

        for (int i = 0; i < uiInShop.Length; i++)
        {
            uiInShop[i].SetActive(true);
        }

    }

}
