using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public Quizmanager quizManager;

    public Color startColor;

    private void Start()
    {
        startColor = GetComponent<Image>().color;
    }

    //when a good or bad answer has been given during the exam show the given colors
    public void Answer()
    {
        Debug.Log("Click");
        if (isCorrect)
        {
            
            GetComponent<Image>().color = Color.green;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            Debug.Log("Correct Answer");
            quizManager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;
            transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.white;
            Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }

}
