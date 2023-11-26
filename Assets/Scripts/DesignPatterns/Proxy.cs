using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public interface InterfaceScore 
{
    int GetScore();
} 

public class Score : InterfaceScore 
{
    private int _score = 0;

    public int GetScore() 
    {
        return _score;
    }
}

public class ScoreProxy : InterfaceScore
{
    private Score score;

    public ScoreProxy()
    {
        score = new Score();
    }

    public int GetScore()
    {
        return score.GetScore();
    }
}
