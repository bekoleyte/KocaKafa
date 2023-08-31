using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public static LevelController instance;
    public int currentLevel;
    public int maxLevel;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        maxLevel = 3;  //level artinca burayi degistyir
        DontDestroyOnLoad(gameObject);
        GetLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetLevel()
    {
        currentLevel = PlayerPrefs.GetInt("levelKey", 1);
        LoadLevel();
    }

    private void LoadLevel()
    {
        string strLevel = "LevelScene" + currentLevel;
        SceneManager.LoadScene(strLevel);
    }

    public void NextLevel()
    {
        currentLevel++;

        if (currentLevel > maxLevel)
        {
            currentLevel = 1;
        }

        PlayerPrefs.SetInt("levelKey", currentLevel);
        LoadLevel();
    }

}
