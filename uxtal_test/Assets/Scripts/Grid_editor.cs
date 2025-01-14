using UnityEngine;

public class TileEditor : MonoBehaviour
{
    public GridManager gridManager;
    public GameObject[] tilePrefabs;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 localPosition = gridManager.transform.InverseTransformPoint(worldPosition);

            int x = Mathf.RoundToInt((localPosition.x + localPosition.y) / gridManager.tileSize);
            int y = Mathf.RoundToInt((localPosition.y - localPosition.x) / gridManager.tileSize);

            if (x >= 0 && x < gridManager.gridWidth && y >= 0 && y < gridManager.gridHeight)
            {
                GameObject currentTile = gridManager.grid[x, y];
                Destroy(currentTile);

                GameObject newTile = Instantiate(tilePrefabs[Random.Range(0, tilePrefabs.Length)],
                    currentTile.transform.position, Quaternion.identity, gridManager.transform);
                gridManager.grid[x, y] = newTile;
            }
        }
    }
}
