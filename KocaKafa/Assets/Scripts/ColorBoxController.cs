using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBoxController : MonoBehaviour
{
    public Material boxMat;
    private GameObject playerGO;
    private playerController playerScript;

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
        if (other.tag == "Player")
        {
            playerScript.TouchedToColorBox(boxMat);
            Destroy(gameObject);
            //playercontroller a söyle bir renkli kuutuya dokundu vedokundugu kutu bu renk
        }
    }
}
