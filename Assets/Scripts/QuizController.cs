using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour

{   [SerializeField]
    private Text questionText;

    private bool startTimer = false;

    [SerializeField]
    private Text countdownText;

    [SerializeField]
    private Text answerText;

    [SerializeField]
    private Text readyText;

    public GameObject quizButton;

    // Start is called before the first frame update
    public QuestionList QL;
    public double targetTime = 5.0;

    private XmlDocument doc = new XmlDocument();
    private int setNumber = -1;
    private System.Random random = new System.Random();

    private float rotateInterval = 2;

    private int quizID;

    private void Start()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Questions");
        doc.LoadXml(textAsset.text);

    }
    void Update()
    {
        rotateInterval += Time.deltaTime;
        if(rotateInterval >= 2 && rotateInterval <= 2.1)
        {
            StartCoroutine(QButtonRotate());
            rotateInterval = 0;
        }
        if (setNumber == -1)
        {
            setNumber = random.Next(3);
        }
        if (startTimer)
        {
            if (targetTime > 0)
            {
                countdownText.text = Math.Round(targetTime,1).ToString() + " seconds left!";
            }
            else
            {
                startTimer = false;
                countdownText.text = "Time's up!";
                ShowAnswer(quizID);
             //   ButtonActionManager.Instance.quizAnswerButton.gameObject.SetActive(true);
            }

            targetTime -= Time.deltaTime;
        }
        else
        {
            if(countdownText.text != "Time's up!")
                countdownText.text = "";
            targetTime = 5.0;
        }
    }
    private static QuizController instance;

    public static QuizController Instance
    {
        get
        {
            if (instance == null)
                instance = FindObjectOfType<QuizController>();

            return instance;
        }
    }

    public void CreateQuestion(int i)
    {
        StartCoroutine(Question(i));
        quizID = i;
    }
    public void ShowAnswer(int i)
    {
        UIManager.Instance.quizAnswerPanel.SetActive(true);
        answerText.text = doc.DocumentElement.ChildNodes[i].ChildNodes[setNumber].ChildNodes[1].ChildNodes[0].Value;
    }
    public void StopTimer()
    {
        setNumber = -1;
        countdownText.text = "0";
        targetTime = 10.0;
        startTimer = false;
        ButtonActionManager.Instance.quizAnswerButton.gameObject.SetActive(false);
        //   answerText.gameObject.SetActive(false);
    }

    // Update is called once per frame

    IEnumerator QButtonRotate()
    {
        quizButton.GetComponent<RectTransform>().LeanRotateZ(-40f, 0.15f);
        yield return new WaitForSeconds(0.15f);
        quizButton.GetComponent<RectTransform>().LeanRotateZ(40f, 0.15f);
        yield return new WaitForSeconds(0.15f);
        quizButton.GetComponent<RectTransform>().LeanRotateZ(0f, 0.15f);
        //   quizButton.GetComponent<RectTransform>().LeanRotate(Vector3.left, 1f);
        //    yield return new WaitForSeconds(1f);
    }

    IEnumerator Question(int i)
    {
        questionText.text = "";
        countdownText.text = "";
        readyText.text = "Ready?";
        yield return new WaitForSeconds(0.8f);
        readyText.text = "3";
        yield return new WaitForSeconds(0.8f);
        readyText.text = "2";
        yield return new WaitForSeconds(0.8f);
        readyText.text = "1";
        yield return new WaitForSeconds(0.8f);
        readyText.text = "";
        questionText.text = doc.DocumentElement.ChildNodes[i].ChildNodes[setNumber].ChildNodes[0].ChildNodes[0].Value;
        startTimer = true;
    }
   
}
