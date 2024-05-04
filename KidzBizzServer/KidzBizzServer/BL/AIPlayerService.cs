namespace KidzBizzServer.BL
{
    public class AIPlayerService
    {
        private readonly AIPlayer _aiPlayer;

        public AIPlayerService(PlayerType defaultType)
        {
            _aiPlayer = new AIPlayer(defaultType);
        }

        public bool MakeDecision(GameState gameState)
        {
            _aiPlayer.MakeDecision(gameState);
            return _aiPlayer.GetLastDecision();
        }

        public IEnumerable<bool> GetDecisionHistory()
        {
            return _aiPlayer.DecisionHistory;
        }

        public object ExecuteDecision(GameState gameState)
        {
            // Example implementation
            _aiPlayer.MakeDecision(gameState);
            return _aiPlayer.GetLastDecision();
        }
    }
}
