namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;
        private IScoreState scoreState;
        
        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
            this.scoreState = new ScoreStateEqual();
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                m_score1 += 1;
            else
                m_score2 += 1;
            
            if (m_score1 == m_score2)
                this.scoreState = new ScoreStateEqual();
            else if (m_score1 >= 4 || m_score2 >= 4)
                this.scoreState = new ScoreStateAboveFour();
            else
                this.scoreState = new ScoreStateNotEqualAndLessThenFour();
            
        }

        public string GetScore()
        {   
            return this.scoreState.GetScore(this.m_score1, this.m_score2);
        }
    }
}

