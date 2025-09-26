using System;
using Unity.Android.Gradle.Manifest;
using UnityEngine.Events;

namespace SimplePuzzle
{
    public sealed class PlayerData
    {
        private int _score;
        private int _moves;
        
        public int Score
        {
            set
            {
                if (value < 0) return;
                
                _score = value;
                OnScoreChanged?.Invoke(_score);
            }
            get
            {
                return _score;
            }
        }

        public int Moves
        {
            set
            {
                if (value < 0)
                {
                    OnGameOver?.Invoke();
                    return;
                }
                
                _moves = value;
                OnMovesChanged?.Invoke(_moves);
            }
            get
            {
                return _moves;
            }
        }

        public static UnityEvent<int> OnScoreChanged = new UnityEvent<int>(); 
        public static UnityEvent<int> OnMovesChanged = new UnityEvent<int>();
        public static UnityEvent OnGameOver = new UnityEvent();

        public PlayerData(SimplePuzzleGameManager gameManager)
        {
            _score = 0;
            _moves = gameManager.GameSettings.StartMovesQty;
        }
    }
}