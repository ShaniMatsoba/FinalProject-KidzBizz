namespace KidzBizzServer.BL
{
    public class AIPlayerService
    {
        private readonly AIPlayer _aiPlayer;

        public AIPlayerService(PlayerType defaultType)
        {
            _aiPlayer = new AIPlayer(defaultType);
        }

        // Executes a decision based on the provided game state
        public bool MakeDecision(GameState gameState)
        {
            if (gameState == null)
                throw new ArgumentNullException(nameof(gameState));

            _aiPlayer.MakeDecision(gameState);
            return _aiPlayer.GetLastDecision();
        }

        // Retrieves the history of decisions made by the AI player
        public IEnumerable<bool> GetDecisionHistory()
        {
            return _aiPlayer.DecisionHistory;
        }

        // Example implementation of executing a decision
        // This method could be expanded to include additional logic after making a decision
        public bool ExecuteDecision(GameState gameState)
        {
            if (gameState == null)
                throw new ArgumentNullException(nameof(gameState));

            _aiPlayer.MakeDecision(gameState);
            return _aiPlayer.GetLastDecision();
        }
    }
}
