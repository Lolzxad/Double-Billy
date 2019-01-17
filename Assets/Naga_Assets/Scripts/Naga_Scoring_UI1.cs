using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_Scoring_UI1 : MonoBehaviour {

    //Variables
    string name = "";
    string score = "";
    List<Scores> highscore;

    // Use this for initialization
    void Start ()
    {
        highscore = new List<Scores>();
    }

    void ButtonClicked(GameObject vobject)
    {
        print("Clicked button:" + vobject.name);
    }

    void OnGUI()
    {
        GUILayout.BeginHorizontal();
        GUILayout.Label("Name :");
        name = GUILayout.TextField(name);
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUILayout.Label("Score :");
        score = GUILayout.TextField(score);
        GUILayout.EndHorizontal();

        if (GUILayout.Button("Add Score"))
        {
            Naga_Score_Manager.eEvent.SaveScore(name, System.Int32.Parse(score));
            highscore = Naga_Score_Manager.eEvent.GetHighScore();
        }

        if (GUILayout.Button("Get LeaderBoard"))
        {
            highscore = Naga_Score_Manager.eEvent.GetHighScore();
        }

        if (GUILayout.Button("Clear Leaderboard"))
        {
            Naga_Score_Manager.eEvent.ClearScores();
        }

        GUILayout.Space(60);

        GUILayout.BeginHorizontal();
        GUILayout.Label("Name", GUILayout.Width(Screen.width / 2));
        GUILayout.Label("Scores", GUILayout.Width(Screen.width / 2));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);

        foreach (Scores _score in highscore)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(_score.name, GUILayout.Width(Screen.width / 2));
            GUILayout.Label("" + _score.score, GUILayout.Width(Screen.width / 2));
            GUILayout.EndHorizontal();
        }
    }



}
