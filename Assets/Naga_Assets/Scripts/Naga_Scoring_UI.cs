using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_Scoring_UI : MonoBehaviour {

    //Variables
    string name = "";
    string score = "";
    List<Scores> highscore;
    public int top = 90;
    public int left = 375;
    public int left2 = 900;

    // Use this for initialization
    void Start ()
    {
        highscore = new List<Scores>();
        highscore = Naga_Score_Manager.eEvent.GetHighScore();
    }

    void ButtonClicked(GameObject vobject)
    {
        print("Clicked button:" + vobject.name);
    }

    void OnGUI()
    {
        /*GUILayout.BeginHorizontal();
        GUILayout.Label("Name :");
        name = GUILayout.TextField(name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Score :");
        score = GUILayout.TextField(score);
        GUILayout.EndHorizontal();*/

        GUILayout.Space(top);

        foreach (Scores array in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Space(left);
            GUILayout.Label("" + array.name, GUILayout.Width(left2));
            GUILayout.Label("" + array.score, GUILayout.Width(left2));
            GUILayout.EndHorizontal();
        }
    }

    public void Add()
    {
        Naga_Score_Manager.eEvent.SaveScore(name, System.Int32.Parse(score));
        highscore = Naga_Score_Manager.eEvent.GetHighScore();
    }

    public void GetBoard()
    {
        highscore = Naga_Score_Manager.eEvent.GetHighScore();
    }

    public void Clearall()
    {
        Naga_Score_Manager.eEvent.ClearScores();
        highscore = Naga_Score_Manager.eEvent.GetHighScore();
    }



}
