using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// This script will be the quiz controller and handle the quiz interactions.
public class Quiz_Manager : MonoBehaviour
{
    // List object of the question and answers for the quiz
    public List<QuestionsNAnswers> Qna;

    // An GameObject array for the answers available for the question
    public GameObject[] answerOptions;

    // Integer variable to keep track of the current question
    public int currentQuestion;

    // Integer variable to count the questions created
    public int questionCount;

    //Integer variable tracks the total questions answered
    int totalQuestions = 0;

    // Integer variable keeps tracks of users score
    public int score;

    // Text variable which gives the user the question and score
    public Text QuestionText;
    public Text ScoreText;

    // GameObject objects of the quiz, gameover and winners panel
    public GameObject QuizPanel;
    public GameObject GameOverPanel;
    public GameObject WinnersPanel;

    // Checks to see if user has completed quiz
    public bool quizCompleted = false; 

    // At the start of the game the game will call the creation question function
    private void Start()
    {
        totalQuestions=Qna.Count; //Set totalQuestions to the number of Qna questions.
        GameOverPanel.SetActive(false); //Disable game over panel at the start
        WinnersPanel.SetActive(false); //Disable winners panel at the start
        createQuestion();
    } 

    // Will load the active scene again
    public void tryAgain()
    {
        // Get current scene index and load it
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // When called will enable game over/winners panel and disable quiz panel depending on the users score
    public void GameFinished()
    {
        QuizPanel.SetActive(false);
        ScoreText.text = score + "/" + 3;

        if(score == 3)
        {
            WinnersPanel.SetActive(true); // Enable winners panel when user gets all of the questions correct!
            quizCompleted = true; // Change quiz completed variable to true
            QuizLoad.taskComplete = true; // Changing the taskComplete boolean in QuizLoad to tell the program the user has completed the task. 
        }
        else
        {
            GameOverPanel.SetActive(true); //Enable game over panel  
            quizCompleted = false; //Set user status to false in completing the quiz
            QuizLoad.taskComplete = false; // Set the taskComplete boolean in QuizLoad as false.
        }
    }

    // Function removes question and creates another question for the user when the user is correct
    public void answerCorrect()
    {
        score += 1;
        Qna.RemoveAt(currentQuestion); //Remove question once answered
        createQuestion(); //Call function that creates the question
    }

    // User answers question incorrectly
    public void answerIncorrect()
    {
        Qna.RemoveAt(currentQuestion); // Remove question once answered
        createQuestion(); // Call function that creates the question
    }

    // This function will set the answers for the quiz
    void SetAnswers()
    {
        for(int i = 0; i < answerOptions.Length; i++)
        {
            answerOptions[i].GetComponent<Answers>().isCorrect = false;
            answerOptions[i].transform.GetChild(0).GetComponent<Text>().text = Qna[currentQuestion].Answers[i];

            if (Qna[currentQuestion].CorrectAnswer == i+1) // Option with the correct index will be set to true
            {
                answerOptions[i].GetComponent<Answers>().isCorrect = true;
            }
        }
    }

    // This function will create the question, store it in a variable and then call the function to set answers 
    void createQuestion()
    {
        // if there is a next valid question and if the question count is less than 3, then generate a random question and set the answers
        if(Qna.Count > 0 && questionCount < 3) 
        {
            currentQuestion = Random.Range(0, Qna.Count);
            QuestionText.text = Qna[currentQuestion].Question;
            questionCount++; // Increment the question count by one
            SetAnswers();
        } 
        else // Print to the console that there is no more questions left to asnwer 
        {
            Debug.Log("No more questions left!");
            GameFinished(); // Invoke the method which deals with the game finished panels
        }
        
    }
}
