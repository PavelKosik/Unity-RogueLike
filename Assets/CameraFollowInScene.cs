using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowInScene : MonoBehaviour
{
    public GameObject player;
    public Vector3 offSet;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CameraFollow();
    }

    void CameraFollow()
    {
        // transform.position = new Vector3(player.transform.position.x+offSet.x,player.transform.position.y+offSet.y,player.transform.position.z+offSet.z);
        transform.position = Vector3.Lerp(transform.position,player.transform.position + offSet, 0.08f);
    }
}
