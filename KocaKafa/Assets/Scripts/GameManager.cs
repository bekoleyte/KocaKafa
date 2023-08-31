using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance; //tekrar tekrar gamemanager olusturulmasin 
    public GameObject StartMenuPanel;
    public GameObject SuccessPanel;

    private void Awake() // starttan once calisir
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
    }
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonTapped()
    {
        StartMenuPanel.gameObject.SetActive(false);
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerController playerScript = playerGO.GetComponent<playerController>();
        playerScript.GameStarted();
    }

    public void NextLevelButtonTapped()
    {
        SuccessPanel.gameObject.SetActive(false);
        LevelController.instance.NextLevel();
    }

    public void ShowSuccessMenu()
    {
        SuccessPanel.gameObject.SetActive(true);
    }

}
