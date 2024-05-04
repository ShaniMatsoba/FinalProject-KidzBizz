namespace KidzBizzServer.BL
{
    public enum PlayerType
    {
        Conservative,
        Adventurous,
        Balanced
    }

    public class AIPlayer
    {
        private PlayerType playerType;
        private List<bool> decisionHistory;
        private static readonly Random random = new Random();  // Shared random instance

        public IEnumerable<bool> DecisionHistory => decisionHistory;

        public AIPlayer(PlayerType type)
        {
            playerType = type;
            decisionHistory = new List<bool>();
        }

        public void MakeDecision(GameState gameState)
        {
            switch (playerType)
            {
                case PlayerType.Conservative:
                    decisionHistory.Add(MakeConservativeDecision(gameState));
                    break;
                case PlayerType.Adventurous:
                    decisionHistory.Add(MakeAdventurousDecision(gameState));
                    break;
                case PlayerType.Balanced:
                    decisionHistory.Add(MakeBalancedDecision(gameState));
                    break;
                default:
                    throw new InvalidOperationException("Invalid player type.");
            }
        }

        private bool MakeConservativeDecision(GameState gameState)
        {
            return random.Next(4) == 0;
        }

        private bool MakeAdventurousDecision(GameState gameState)
        {
            return random.Next(2) == 0;
        }

        private bool MakeBalancedDecision(GameState gameState)
        {
            return random.Next(3) == 0;
        }

        public List<bool> GetLastNDecisions(int n)
        {
            return decisionHistory.Count <= n ? decisionHistory : decisionHistory.GetRange(decisionHistory.Count - n, n);
        }

        public bool GetLastDecision()
        {
            return decisionHistory.LastOrDefault();
        }
    }
}
