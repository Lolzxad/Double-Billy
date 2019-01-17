using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Naga_Score_Manager : MonoBehaviour
{

    //Variables
    private static Naga_Score_Manager mEvent;
    private const int LeaderboardLength = 10;

    public static Naga_Score_Manager eEvent
    {
        get
        {
            if (mEvent == null)
            {
                mEvent = new GameObject("Naga_Score_Manager").AddComponent<Naga_Score_Manager>();
            }
            return mEvent;
        }
    }

    void Awake()
    {
        if (mEvent == null)
        {
            mEvent = this;
        }
        else if (mEvent != this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void SaveScore(string name, int score)
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }

        if (HighScores.Count == 0)
        {
            Scores temp2 = new Scores();
            temp2.name = name;
            temp2.score = score;
            HighScores.Add(temp2);
        }

        else
        {
            for (i = 1; i <= HighScores.Count && i <= LeaderboardLength; i++)
            {
                if (score > HighScores[i - 1].score)
                {
                    Scores temp2 = new Scores();
                    temp2.name = name;
                    temp2.score = score;
                    HighScores.Insert(i - 1, temp2);
                    break;
                }

                if (i == HighScores.Count && i < LeaderboardLength)
                {
                    Scores temp2 = new Scores();
                    temp2.name = name;
                    temp2.score = score;
                    HighScores.Add(temp2);
                    break;
                }
            }
        }

        i = 1;
        while (i <= LeaderboardLength && i <= HighScores.Count)
        {
            PlayerPrefs.SetString("HighScore" + i + "name", HighScores[i - 1].name);
            PlayerPrefs.SetInt("HighScore" + i + "score", HighScores[i - 1].score);
            i++;
        }

    }

    public List<Scores> GetHighScore()
    {
        List<Scores> HighScores = new List<Scores>();

        int i = 1;
        while (i <= LeaderboardLength && PlayerPrefs.HasKey("HighScore" + i + "score"))
        {
            Scores temp = new Scores();
            temp.score = PlayerPrefs.GetInt("HighScore" + i + "score");
            temp.name = PlayerPrefs.GetString("HighScore" + i + "name");
            HighScores.Add(temp);
            i++;
        }

        return HighScores;
    }

    public void ClearScores()
    {
        List<Scores> HighScores = GetHighScore();

        for (int i = 1; i <= HighScores.Count; i++)
        {
            PlayerPrefs.DeleteKey("HighScore" + i + "name");
            PlayerPrefs.DeleteKey("HighScore" + i + "score");
        }
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}

    public class Scores
    {
        public int score;
        public string name;
    }
