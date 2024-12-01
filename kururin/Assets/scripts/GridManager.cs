using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.U2D;

public class GridManager : MonoBehaviour
{
    public Tilemap tilemap;
    public SpriteShapeController spriteShapeController;

    public Tile singleTile;
    public Tile horizontalTile;
    public Tile verticalTile;
    public Tile cornerTile;
    public Tile centerTile;

    public void PlaceBlock(Vector3Int gridPosition)
    {
        Tile tileToPlace = GetTileForPosition(gridPosition);

        tilemap.SetTile(gridPosition, tileToPlace);

        UpdateSpriteShape();
    }

    private Tile GetTileForPosition(Vector3Int position)
    {
        bool hasLeft = tilemap.HasTile(position + Vector3Int.left);
        bool hasRight = tilemap.HasTile(position + Vector3Int.right);
        bool hasUp = tilemap.HasTile(position + Vector3Int.up);
        bool hasDown = tilemap.HasTile(position + Vector3Int.down);

        if (!hasLeft && !hasRight && !hasUp && !hasDown)
        {
            return singleTile;
        }
        if (hasLeft && hasRight && !hasUp && !hasDown)
        {
            return horizontalTile;
        }
        if (!hasLeft && !hasRight && hasUp && hasDown)
        {
            return verticalTile;
        }
        if (hasLeft && hasUp && !hasRight && !hasDown)
        {
            return cornerTile;
        }
        if (hasRight && hasUp && !hasLeft && !hasDown)
        {
            return cornerTile;
        }
        if (hasLeft && hasDown && !hasRight && !hasUp)
        {
            return cornerTile;
        }
        if (hasRight && hasDown && !hasLeft && !hasUp)
        {
            return cornerTile;
        }
        if (hasLeft && hasRight && hasUp && hasDown)
        {
            return centerTile;
        }

        return singleTile;
    }

    private void UpdateSpriteShape()
    {
        spriteShapeController.spline.Clear();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);

        for (int x = bounds.xMin; x < bounds.xMax; x++)
        {
            for (int y = bounds.yMin; y < bounds.yMax; y++)
            {
                Vector3Int pos = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(pos))
                {
                    AddPointsToSpline(pos);
                }
            }
        }

        spriteShapeController.BakeCollider();
    }

    private void AddPointsToSpline(Vector3Int tilePosition)
    {
        Vector3 worldPos = tilemap.CellToWorld(tilePosition);
        
        spriteShapeController.spline.InsertPointAt(spriteShapeController.spline.GetPointCount(), worldPos + new Vector3(0, 0));
        spriteShapeController.spline.InsertPointAt(spriteShapeController.spline.GetPointCount(), worldPos + new Vector3(1, 0));
        spriteShapeController.spline.InsertPointAt(spriteShapeController.spline.GetPointCount(), worldPos + new Vector3(1, 1));
        spriteShapeController.spline.InsertPointAt(spriteShapeController.spline.GetPointCount(), worldPos + new Vector3(0, 1));
    }
}