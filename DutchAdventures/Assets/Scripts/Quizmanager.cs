using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Quizmanager : MonoBehaviour
{
    [Header("Quiz")]
    public GameObject Quizpanel;
    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;
    public TextMeshProUGUI QuestionTxt;
   
    [Header("Result panel")]
    public int totalQuestions = 0;
    public int score;
    public GameObject EndScore;
    public TextMeshProUGUI PassedFailedTxt;
    public TextMeshProUGUI ScoreTxt;

    [Header("Minigame")]
    [SerializeField]
    private GameObject world;
    [SerializeField]
    private GameObject mingame;
    [SerializeField]
    private Transform player;
    [SerializeField]
    private PlayerSpawn exitPos;
    [SerializeField]
    private GameObject retryBtn;
    [SerializeField]
    private GameObject continueBtn;
    private bool retried = false;

    private void Start()
    {
        totalQuestions = QnA.Count;
        EndScore.SetActive(false);
        generateQuestion();

        // if retried is pressed the location of the player is the new spawn location
        if (retried != true)
        {
            player.position = exitPos.spawnPosition;
            retried = false;

        }
    }

    // function when retry is pressed reset the question
    public void retry()
    {
        Debug.Log(player.position);
        exitPos.spawnPosition = player.position;
        retried = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // function when btn continue is pressed give you tessed passed to get your licenace
    public void continueBtnClick() {

        KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
        keyItemSaver.setItem("TestPassed", true);
        
        world.SetActive(true);
        mingame.SetActive(false);

        Debug.Log("Minigame compleeted");

    }

    // Give you result screen
    void GameOver()
    {
        Quizpanel.SetActive(false);
        EndScore.SetActive(true);

        // check if test is 100% correct
        if (totalQuestions == score)
        {
            PassedFailedTxt.text = "You have PASSED the test.";
            continueBtn.SetActive(true);
            retryBtn.SetActive(false);
        } else 
        {
            PassedFailedTxt.text = "Your have FAILED the test.";
            continueBtn.SetActive(false);
            retryBtn.SetActive(true);
        }
        ScoreTxt.text = "You scored " + score + "/" + totalQuestions + " points.";
    }

    // remove correct awnsers questions from list and add point to score
    public void correct()
    {
        //when you are right
        score += 1;
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    // remove wrong anwsers to list
    public void wrong()
    {
        //when you answer wrong
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    // setup every question with anwsers
    void SetAnswers()
    {
        for (int option = 0; option < options.Length; option++)
        {
            options[option].GetComponent<AnswerScript>().isCorrect = false;
            options[option].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[option];
            options[option].transform.GetChild(0).GetComponent<TextMeshProUGUI>().color = Color.black; 
            options[option].GetComponent<Image>().color = options[option].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestion].CorrectAnswer == option)
            {
                
                options[option].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    //Makes all the questions
    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else
        {
            Debug.Log("Out of Questions");
            GameOver();
        }


    }
}
