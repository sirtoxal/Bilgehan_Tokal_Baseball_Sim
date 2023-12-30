using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI lvlText;

    void Start()
    {
        ChooseLevel();
        UpdateLevelText();
    }

    void ChooseLevel()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
        int x = PlayerPrefs.GetInt("CurrentLevel", 1);
        switch (x)
        {
            case 1: transform.GetChild(0).gameObject.SetActive(true); break;
            case 2: transform.GetChild(1).gameObject.SetActive(true); break;
            case 3: transform.GetChild(2).gameObject.SetActive(true); break;
            case 4: transform.GetChild(3).gameObject.SetActive(true); break;
            case 5: transform.GetChild(4).gameObject.SetActive(true); break;
        }
    }

    public void LevelIncrease()
    {
        if(PlayerPrefs.GetInt("CurrentLevel", 1) < 5)
            PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);
        else        
            PlayerPrefs.SetInt("CurrentLevel", 1);
        
        //SceneManager.GetSceneByBuildIndex(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UpdateLevelText()
    {
        lvlText.text = "Level: " + PlayerPrefs.GetInt("CurrentLevel", 1).ToString();
    }
}
