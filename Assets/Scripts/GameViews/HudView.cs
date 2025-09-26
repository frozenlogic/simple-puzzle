using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace SimplePuzzle
{
    public class HudView : GameView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _scoreMovesText;
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _makeMoveButton;

        public override void Init(SimplePuzzleGameManager gameManager)
        {
            base.Init(gameManager);
            
            _scoreMovesText.SetText(GameManager.PlayerData.Moves.ToString());
            _scoreText.SetText(GameManager.PlayerData.Score.ToString());
            
            PlayerData.OnMovesChanged.AddListener((newMovesQty) =>
            {
                _scoreMovesText.SetText(newMovesQty.ToString());
            });

            PlayerData.OnScoreChanged.AddListener((newScore) =>
            {
                _scoreText.SetText(newScore.ToString());
            });

            _makeMoveButton.onClick.AddListener(() =>
            {
                if (GameManager.PlayerData.Moves > 0)
                {
                    GameManager.PlayerData.Score += 10;
                }
                GameManager.PlayerData.Moves--;
            });
            
            _restartButton.onClick.AddListener(() =>
            {
                GameManager.Reset();
            });

        }
    }
}