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
    public List<QuestionAndAnswers> BackupQnA;
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

    private void Start()
    {
        totalQuestions = QnA.Count;
        EndScore.SetActive(false);
        generateQuestion();
        
    }

    public void retry()
    {
        Debug.Log(player.position);
        exitPos.spawnPosition = player.position;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void continueBtnClick() {

        KeyItemsSaver keyItemSaver = player.GetComponent<KeyItemsSaver>();
        keyItemSaver.setItem("TestPassed", true);
        
        world.SetActive(true);
        mingame.SetActive(false);

        Debug.Log("Minigame compleeted");

    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        EndScore.SetActive(true);

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

    public void correct()
    {
        //when you are right
        score += 1;
        Debug.Log("CurrentQuest"+currentQuestion);
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    public void wrong()
    {
        //when you answer wrong
        Debug.Log("CurrentQuest" + currentQuestion);
        BackupQnA.AddRange(QnA);
        QnA.RemoveAt(currentQuestion);
        StartCoroutine(waitForNext());
    }

    IEnumerator waitForNext()
    {
        yield return new WaitForSeconds(1);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().startColor;

            if (QnA[currentQuestion].CorrectAnswer == i)
            {
                
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

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
