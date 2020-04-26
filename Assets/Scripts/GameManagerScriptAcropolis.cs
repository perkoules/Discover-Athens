using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManagerScriptAcropolis : MonoBehaviour {

	public QuestionAcropolis [] questions;
	private static List<QuestionAcropolis> unansweredQuestions;
	int times =0, correctAnswers = 0, wrongAnswers=0;
	private QuestionAcropolis currentQuestion;

	private Image m_Image;
    public Sprite[] m_Sprite;

	[SerializeField]
	private Text factText;

	[SerializeField]
	private float timeBetweenQuestions =1;

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
			unansweredQuestions = questions.ToList<QuestionAcropolis>();
		}
		
		m_Image = GameObject.FindGameObjectWithTag("IMG").GetComponent<Image>();
		SetCurrentQuestion();
	}

	void SetCurrentQuestion()
	{
		int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions[randomQuestionIndex];
		factText.text =  currentQuestion.fact;

		if(factText.text.Contains("advocate")){
			m_Image.sprite = m_Sprite[0];
		}else if(factText.text.Contains("Acropolis")){
			m_Image.sprite = m_Sprite[7];
		}else if(factText.text.Contains("Dionysus")){
			m_Image.sprite = m_Sprite[6];
		}else if(factText.text.Contains("Propylaea")){
			m_Image.sprite = m_Sprite[1];
		}else if(factText.text.Contains("Erechtheion")){
			m_Image.sprite = m_Sprite[3];
		}else if(factText.text.Contains("country")){
			m_Image.sprite = m_Sprite[8];
		}else if(factText.text.Contains("stole")){
			m_Image.sprite = m_Sprite[4];
		}else if(factText.text.Contains("name")){
			m_Image.sprite = m_Sprite[5];
		}else if(factText.text.Contains("major") || factText.text.Contains("Parthenon")){
			m_Image.sprite = m_Sprite[2];
		}else if(factText.text.Contains("Democrasy")){
			m_Image.sprite = m_Sprite[9];
		}

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

		if(times==15){
			if (correctAnswers == 15){
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
		GameObject[] tt = GameObject.FindGameObjectsWithTag("TickTag");
		tt[correctAnswers-1].GetComponent<Text>().color = new Color(0,255,0,255);
	}

	void Wrong()
	{
		times++;
		GameObject[] tt = GameObject.FindGameObjectsWithTag("TickTag");
		tt[times-1].GetComponent<Text>().color = new Color(255,0,0,255);
	}

	

}
