using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private Text questionText;

    void Start ()
    {
        if(unansweredQuestions == null || unansweredQuestions.Count() == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            
            SetCurrentQuestion();
        }
    }

    void SetCurrentQuestion()
    {
        int QuestionIndex = Random.Range(0,unansweredQuestions.Count());
        currentQuestion = unansweredQuestions[QuestionIndex];

        questionText.text = currentQuestion.question;

        unansweredQuestions.RemoveAt (QuestionIndex);
    }

    public void UserSelectTrue ()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
        }else
        {
            Debug.Log("FALSE");
        }
    }

    public void UserSelectFalse ()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("CORRECT");
        }else
        {
            Debug.Log("FALSE");
        }
    }
}