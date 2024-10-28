namespace Tennis;

public class ScoreStateAboveFour : IScoreState
{
    public string GetScore(int m_score1, int m_score2)
    {
        var minusResult = m_score1 - m_score2;
        if (minusResult == 1) return "Advantage player1";
        else if (minusResult == -1) return "Advantage player2";
        else if (minusResult >= 2) return "Win for player1";
        else return "Win for player2";
    }
}