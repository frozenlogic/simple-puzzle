using UnityEngine;

namespace SimplePuzzle
{
    public class PuzzleGridCell
    {
        public Block CurrentBlock { get; private set; }
        public Vector2 GridPosition { get; private set; }
        public Vector2 WorldPosition { get; private set; }
        public float padding;
        
        public float size;

        public PuzzleGridCell(int x, int y, Vector2 worldPosition)
        {
            WorldPosition = worldPosition;
            GridPosition = new Vector2(x, y);
        }

        public float GetSize()
        {
            return size + padding; 
        }

        public void SetBlock(Block block)
        {
            CurrentBlock = block;
            if (CurrentBlock)
            {
                CurrentBlock.transform.position = WorldPosition;
            }
        }

        public void RemoveBlock()
        {
            GameObject.Destroy(CurrentBlock.gameObject);
            CurrentBlock = null;
        }

        public void SetWorldPosition(int row, int col, Vector3 pos)
        {
            WorldPosition = (new Vector3(row, col, 0) * GetSize()) + pos;
        }

        public Vector3 GetWorldPosition()
        {
            return WorldPosition;
        }

        public void SetGridPosition(int x, int y)
        {
            GridPosition = new Vector2(x, y);
        }

        public bool IsEmpty()
        {
            return CurrentBlock == null ? true : false;
        }
    }
}