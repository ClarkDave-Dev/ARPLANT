using System.Collections;
using System;
using System.Xml;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public Text questionText;
    private bool startTimer = false;
    public Text countdownText;
    public Text answerText;

    // Start is called before the first frame update
    public QuestionList QL;
    public double targetTime = 5.0;

    private XmlDocument doc = new XmlDocument();
    private int setNumber = -1;
    private System.Random random = new System.Random();
    private void Start()
    {
        TextAsset textAsset = (TextAsset)Resources.Load("Questions");
        doc.LoadXml(textAsset.text);

    }
    void Update()
    {
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
                ButtonActionManager.Instance.quizAnswerButton.gameObject.SetActive(true);
            }

            targetTime -= Time.deltaTime;
        }
        else
        {
            if(countdownText.text != "Time's up!")
                countdownText.text = "0";
            targetTime = 5.0;
        }
    }
    private void MyTimer_Tick(object sender, EventArgs e)
    {
       
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

    public void CreateQuestion()
    {
        questionText.text = doc.DocumentElement.ChildNodes[0].ChildNodes[setNumber].ChildNodes[0].ChildNodes[0].Value;
        startTimer = true;
    }
    public void ShowAnswer()
    {
        UIManager.Instance.quizAnswerPanel.SetActive(true);
        answerText.text = doc.DocumentElement.ChildNodes[0].ChildNodes[setNumber].ChildNodes[1].ChildNodes[0].Value;
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
   
}
