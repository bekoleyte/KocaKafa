using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
    private GameObject playerGO;
    private playerController playerScript;
    private bool hasObstacleUsed;
    // Start is called before the first frame update
    void Start()
    {
        playerGO = GameObject.FindGameObjectWithTag("Player");
        playerScript = playerGO.GetComponent<playerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && hasObstacleUsed == false)
        {
            hasObstacleUsed = true;
            playerScript.TouchedToObstacle();
            //playercontrollera s�yle engele degdi
        }
    }
}
