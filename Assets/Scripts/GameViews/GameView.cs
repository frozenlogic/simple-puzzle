using UnityEngine;

namespace SimplePuzzle
{
    public class GameView : MonoBehaviour
    {
        protected SimplePuzzleGameManager GameManager;
        
        public virtual void Init(SimplePuzzleGameManager gameManager)
        {
            GameManager = gameManager;
        }
    }
}