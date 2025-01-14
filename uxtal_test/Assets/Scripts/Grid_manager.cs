using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int gridWidth = 10;
    public int gridHeight = 10;
    public float tileSize = 1f;

    public GameObject[] tilePrefabs;

    public GameObject[,] grid;

    void Start()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        grid = new GameObject[gridWidth, gridHeight];

        for (int x = 0; x < gridWidth; x++)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                float isoX = (x - y) * tileSize / 2f;
                float isoY = (x + y) * tileSize / 4f;

                GameObject tilePrefab = tilePrefabs[Random.Range(0, tilePrefabs.Length)];

                GameObject tile = Instantiate(tilePrefab, new Vector3(isoX, isoY, 0), Quaternion.identity, transform);
                grid[x, y] = tile;
            }
        }
    }
}