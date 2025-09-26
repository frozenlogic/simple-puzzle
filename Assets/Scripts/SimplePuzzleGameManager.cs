using System;
using System.Collections.Generic;
using UnityEngine;

namespace SimplePuzzle
{
    public sealed class SimplePuzzleGameManager : MonoBehaviour
    {
        [field:SerializeField] public GameSettings GameSettings { get; private set; }
        [field:SerializeField] public List<GameView> GameViews { get; private set; }
        public PlayerData PlayerData { get; private set; }
        [field:SerializeField] public GridController GridController { get; private set; }
        [field:SerializeField] public List<Block> BlockPrefabs { get; private set; }
        
        private void Awake()
        {
            PlayerData = new PlayerData(this);

            foreach (GameView view in GameViews)
            {
                view.Init(this);
            }
            
            GridController.Init(this);
        }

        public void Reset()
        {
            PlayerData.Moves = GameSettings.StartMovesQty;
            PlayerData.Score = 0;
        }

        public Block GetRandomBlockPrefab()
        {
            return BlockPrefabs[UnityEngine.Random.Range(0, BlockPrefabs.Count)];
        }
    }
}