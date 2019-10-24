using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
	public Text resultText;
	public static int score;
	//public static QuizManager instance {get; set;}
	public GameObject[] slides;
	int questionIndex;
	
	
	void Start()
	{
		score = 0;
		startQuestion();
	}
	
	public void AddScore()
	{
		++score;
	}
	
	public void SetText()
	{
		resultText.text = "Correct answers: " + score + "/" + (slides.Length-1) + ".";
	}

	public void moveToNextQuestion()
    {
	    slides[questionIndex].SetActive(false);
	    questionIndex++;
	    slides[questionIndex].SetActive(true);
    }

    public void startQuestion()
    {
        slides[0].SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}