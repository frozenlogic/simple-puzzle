using UnityEngine;
using UnityEngine.UI;

namespace SimplePuzzle
{
    public class GameOverView : GameView
    {
        [SerializeField] private Button _restartButton;
        public override void Init(SimplePuzzleGameManager gameManager)
        {
            base.Init(gameManager);
            
            PlayerData.OnGameOver.AddListener(() =>
            {
                gameObject.SetActive(true);
            });
            
            _restartButton.onClick.AddListener(() =>
            {
                GameManager.Reset();
                gameObject.SetActive(false);
            });
        }
    }
}