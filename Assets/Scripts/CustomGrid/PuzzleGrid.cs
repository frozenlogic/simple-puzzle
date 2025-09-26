using UnityEngine;

namespace SimplePuzzle
{
    public class PuzzleGrid : MonoBehaviour
    {
        [SerializeField] private int height;
        [SerializeField] private int width;
        [SerializeField] private Vector2 _cellSize;
        [SerializeField] private Block[] Blocks;
        private float _cellSizeXInUnits;
        private float _cellSizeYInUnits;
        private Vector2 GridWorldPosition;

        private const int k_PPU = 100;
        
        public PuzzleGridCell[,] GridCells { private set; get; }

        public void Awake()
        {
            GridCells = new PuzzleGridCell[height, width];
            Fill();
            
            _cellSizeXInUnits = _cellSize.x / k_PPU;
            _cellSizeYInUnits = _cellSize.y / k_PPU;
        }
        
        public PuzzleGridCell GetCell(int x, int y)
        {
            return GridCells[x, y];
        }
        
        Block CreateRandomBlock()
        {
            return GameObject.Instantiate(Blocks[UnityEngine.Random.Range(0, Blocks.Length)]);
        }
        
        void Fill()
        {
            for (int i = 0; i < GridCells.GetLength(0); i++)
            {
                for (int j = 0; j < GridCells.GetLength(1); j++)
                {
                    PuzzleGridCell cell = GetCell(i, j);
                    if (cell == null)
                    {
                        Vector2 worldPos = new Vector2(i * _cellSizeXInUnits, j * _cellSizeYInUnits);
                        PuzzleGridCell newCell = new PuzzleGridCell(i, j, worldPos);
                        // Block block = CreateRandomBlock();
                        GridCells[i, j] = newCell;

                        Debug.Log("Created Cell in" + "[" + i + ", " + j + "]. Created Gem.");
                    }
                    else
                    {
                        if(cell.IsEmpty())
                        {
                            // Block block = CreateRandomBlock();

                            Debug.Log("Created Block on Cell " + "[" + i + ", " + j + "]");
                        }
                    }
                }
            }

            Debug.Log("Grid Filling is Done");
        }
        
        void Update()
        {
            DrawGrid();
        }
        
        void DrawGrid()
        {
            for (int i = 0; i < GridCells.GetLength(0); i++)
            {
                for (int j = 0; j < GridCells.GetLength(1); j++)
                {
                    if (j + 1 < GridCells.GetLength(1) && i + 1 < GridCells.GetLength(0))
                    {
                        Debug.DrawLine(GetCell(i, j).GetWorldPosition() - new Vector3(GetCell(i, j).GetSize() / 2, GetCell(i, j).GetSize() / 2, 0),
                            GetCell(i, j + 1).GetWorldPosition() - new Vector3(GetCell(i, j + 1).GetSize() / 2, GetCell(i, j + 1).GetSize() / 2, 0), Color.red);
                        Debug.DrawLine(GetCell(i, j).GetWorldPosition() - new Vector3(GetCell(i, j).GetSize() / 2, GetCell(i, j).GetSize() / 2, 0),
                            GetCell(i + 1, j).GetWorldPosition() - new Vector3(GetCell(i + 1, j).GetSize() / 2, GetCell(i + 1, j).GetSize() / 2, 0), Color.red);
                    }
                }
            }

            if (GridCells != null && GridCells.GetLength(0) > 0)
            {
                Debug.DrawLine(GetCell(0, height - 1).GetWorldPosition() + new Vector3(-GetCell(0, height - 1).GetSize() / 2, GetCell(0, height - 1).GetSize() / 2, 0),
                    GetCell(width - 1, height - 1).GetWorldPosition() + new Vector3(GetCell(0, height - 1).GetSize() / 2, GetCell(width - 1, height - 1).GetSize() / 2, 0), Color.red);
                Debug.DrawLine(GetCell(width - 1, 0).GetWorldPosition() + new Vector3(GetCell(width - 1, 0).GetSize() / 2, -GetCell(width - 1, 0).GetSize() / 2, 0)
                    , GetCell(width - 1, height - 1).GetWorldPosition() + new Vector3(GetCell(width - 1, height - 1).GetSize() / 2, GetCell(width - 1, height - 1).GetSize() / 2, 0), Color.red);
            }
        }
    }
}