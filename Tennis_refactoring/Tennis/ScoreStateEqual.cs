namespace Tennis;

public class ScoreStateEqual : IScoreState
{
    public string GetScore(int m_score1, int m_score2)
    {
        switch (m_score1)
        {
            case 0:
                return "Love-All";
            case 1:
                return "Fifteen-All";
            case 2:
                return "Thirty-All";
            default:
                return "Deuce";

        }
    }
}