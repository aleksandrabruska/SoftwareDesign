namespace Tennis;

public class ScoreStateNotEqualAndLessThenFour : IScoreState
{
    public string GetScore(int m_score1, int m_score2)
    {
        var tempScore = 0;
        var score = "";
        
        for (var i = 1; i < 3; i++)
        {
            if (i == 1) tempScore = m_score1;
            else { score += "-"; tempScore = m_score2; }
            switch (tempScore)
            {
                case 0:
                    score += "Love";
                    break;
                case 1:
                    score += "Fifteen";
                    break;
                case 2:
                    score += "Thirty";
                    break;
                case 3:
                    score += "Forty";
                    break;
            }
        }

        return score;
    }
}