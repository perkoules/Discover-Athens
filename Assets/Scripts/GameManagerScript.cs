using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

	public Question [] questions;
	private static List<Question> unansweredQuestions;
	int times =0, correctAnswers = 0, wrongAnswers=0;
	GameObject[] tt;

	private Question currentQuestion;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestions = 0.1f;

	[SerializeField]
	private Text textAnswerA;

	[SerializeField]
	private Text textAnswerB;

	[SerializeField]
	private Text textAnswerC;

	[SerializeField]
	private Text textAnswerD;


	void Start()
	{
		if (unansweredQuestions == null || unansweredQuestions.Count == 0){
			unansweredQuestions = questions.ToList<Question>();
		}



		SetCurrentQuestion();
		tt = GameObject.FindGameObjectsWithTag("TickTag");
	}

	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text =  currentQuestion.fact;

		textAnswerA.text = currentQuestion.answers[0];
		textAnswerB.text = currentQuestion.answers[1];
		textAnswerC.text = currentQuestion.answers[2];
		textAnswerD.text = currentQuestion.answers[3];
	}

	public void UserSelectedA()
	{
		if(currentQuestion.correctAnswerNumber == 1){
			Correct();
		}else{
			Wrong();
		}

		StartCoroutine(transitionToNextQuestion());
	}
	public void UserSelectedB()
	{
		if(currentQuestion.correctAnswerNumber == 2){
			Correct();
		}else{
			Wrong();
		}

		StartCoroutine(transitionToNextQuestion());
	}
	public void UserSelectedC()
	{
		if(currentQuestion.correctAnswerNumber == 3){
			Correct();
		}else{
			Wrong();
		}

		StartCoroutine(transitionToNextQuestion());
	}
	public void UserSelectedD()
	{
		if(currentQuestion.correctAnswerNumber == 4){
			Correct();
		}else{
			Wrong();
		}

		StartCoroutine(transitionToNextQuestion());
	}

	IEnumerator transitionToNextQuestion()
	{
		unansweredQuestions.Remove(currentQuestion);
		
		
		yield return new WaitForSeconds(timeBetweenQuestions);
		
		if(times==3){
			if (correctAnswers == 3){
				PlayerPrefs.SetString("AllCorrect", "YES");
				SceneManager.UnloadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
			}else{
				SceneManager.UnloadSceneAsync(PlayerPrefs.GetInt("SceneNumber"));
				SceneManager.LoadScene(PlayerPrefs.GetInt("SceneNumber"), LoadSceneMode.Additive);
				times = 0;
				correctAnswers = 0;
			}
		}else{
			SetCurrentQuestion();
		}
	}

	void Correct()
	{
		times++;
		correctAnswers++;
		tt[times-1].GetComponent<Text>().color = new Color(0,255,0,255);
	}

	void Wrong()
	{
		times++;
		GameObject[] tt = GameObject.FindGameObjectsWithTag("TickTag");
		tt[times-1].GetComponent<Text>().color = new Color(255,0,0,255);
	}

	

}
