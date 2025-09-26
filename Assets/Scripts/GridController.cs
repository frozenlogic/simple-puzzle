using System;
using UnityEngine;

namespace SimplePuzzle
{
    public class GridController : MonoBehaviour
    {
        private Grid _grid;

        [SerializeField] private int Height;
        [SerializeField] private int Width;
        
        private SimplePuzzleGameManager _gameManager;

        public void Init(SimplePuzzleGameManager gameManager)
        {
            _gameManager = gameManager;
            _grid = GetComponent<Grid>();
            GetCells();
        }

        public void GetCells()
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    Vector3 worldPos =  _grid.GetCellCenterWorld(new Vector3Int(i, j, 0));
                    worldPos.y += Block.k_Gap;
                    Block block = Instantiate(_gameManager.GetRandomBlockPrefab(), worldPos, Quaternion.identity);
                    block.SetLayer(j);
                }
            }
        }
    }
}