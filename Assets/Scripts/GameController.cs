using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int progressAmount;
    public Slider progressSlider;

    public GameObject player;
    public GameObject loadCanvas;
    public List<GameObject> levels;
    private int currentLevelIndex = 0;

    public GameObject gameOverScreen;
    public TMP_Text SurvivedText;
    private int survivedLevelsCount;
    

    // Start is called before the first frame update
    void Start()
    {
        progressAmount = 0;
        progressSlider.value = 0;
        CollectItem.OnItemCollect += IncreaseProgressAmount;
        LoadLevel.OnHoldComplete += LoadNextLevel;
        PlayerHealth.OnPlayerShinda += GameOverScreen;
        loadCanvas.SetActive(false);
        gameOverScreen.SetActive(false);

    }

    void GameOverScreen()
    {
        gameOverScreen.SetActive(true);
        SurvivedText.text = "" + survivedLevelsCount + " STAGE";
        if (survivedLevelsCount != 1) SurvivedText.text += "S";
        Time.timeScale = 0f;
        Time.timeScale = 1f;
    }

    void IncreaseProgressAmount(int amount)
    {
        progressAmount += amount;
        progressSlider.value = progressAmount;
        if (progressAmount >= 100)
        {
            //Level complete!
            loadCanvas.SetActive(true);
            Debug.Log("Level Complete!");
        }
    }
 
    void LoadNextLevel()
    {
        int nextLevelIndex = (currentLevelIndex == levels.Count - 1) ? 0 : currentLevelIndex + 1;
        loadCanvas.SetActive(false);

        levels[currentLevelIndex].gameObject.SetActive(false);
        levels[nextLevelIndex].gameObject.SetActive(true);

        player.transform.position = new Vector3(0, 0, 0);
    }
}
