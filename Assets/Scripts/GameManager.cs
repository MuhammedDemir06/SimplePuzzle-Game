using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject puzzleStartPicture;
    private TextMeshProUGUI tutorialText;
    [SerializeField] private int score;
    private void Start()
    {
        tutorialText = GameObject.Find("TutorialText").GetComponent<TextMeshProUGUI>();
        puzzleStartPicture.SetActive(true);
    }
    public void ScoreUpdate()
    {
        score += 1;
        if(score==12)
        {
            Debug.LogWarning("Succesfull");
            tutorialText.color = Color.green;
            tutorialText.text = "Succesfull";
        }
    }
    private void Update()
    {
        
    }
    public void NextButton()
    {
        puzzleStartPicture.SetActive(false);
    }
}
