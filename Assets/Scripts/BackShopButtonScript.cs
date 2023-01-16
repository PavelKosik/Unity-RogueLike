using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackShopButtonScript : MonoBehaviour
{
    public GameObject[] shopUI;
    public GameObject[] nonShopUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void DeSetupShopUI()
    {
        
        for (int i=0;i<shopUI.Length;i++)
        {
         
            shopUI[i].SetActive(false);
        }

        for (int i = 0; i < nonShopUI.Length; i++)
        {
         
            nonShopUI[i].SetActive(true);
        }
    }
}
