using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using UnityEngine;


public class GridManager : MonoBehaviour
{
    public static GridManager Instance { get; private set; }

    public Vector2Int gridSize;
    public Dictionary<Vector2Int, HexCell> GridSet;
    public HexCell defaultCell;

    private Grid _gridHelper;


    public Vector2Int testSpawnerCoords;
    public Vector2Int testBrainCoords;

    public SpawnerController spawnerPrefab;
    public GameObject brainPrefab;
    public GameObject obstaclePrefab;

    [SerializeField]
    private int _obstacleWeight = 8;

    
    void Awake()
    {
        Instance = this;
        GridSet = new Dictionary<Vector2Int, HexCell>();
        GenerateGrid(gridSize.x, gridSize.y);
        GenerateObjects();
    }

    private void GenerateObjects()
    {
        if (GridSet.TryGetValue(testBrainCoords, out var brainCell))
        {
            Instantiate(brainPrefab, brainCell.transform.position, Quaternion.identity, brainCell.transform);
        }

        if (GridSet.TryGetValue(testSpawnerCoords, out var spawnCell))
        {
            var spawner = Instantiate(spawnerPrefab, spawnCell.transform.position, Quaternion.identity, spawnCell.transform);
            spawner.Init(spawnCell);
        }

    }

    private void GenerateGrid(int gridWidth, int gridNumRows, bool fromCenter = false)
    {
        for (int yIndex = 0; yIndex < gridNumRows; yIndex++)
        {
            var rowOffset = yIndex >>1;
            for (int xIndex = -rowOffset; xIndex < gridWidth - rowOffset; xIndex++)
            {
                var newCell = Instantiate(defaultCell, Vector3.zero, Quaternion.identity, this.transform);
                newCell.Init(xIndex, yIndex);
                GridSet.Add(new Vector2Int(xIndex, yIndex), newCell);

                if (DecideIfObstacle())
                {
                    newCell.Walkable = false;
                    Instantiate(obstaclePrefab, newCell.transform.position, Quaternion.identity, newCell.transform);
                }
            }
        }

        var hexList = GridSet.Values.ToList();
        foreach (var hexCell in hexList)
        {
            hexCell.CacheNeighbors(hexList);
        }
    }

    /// <summary>
    /// Arbitary Obsticle
    /// </summary>
    /// <returns></returns>
    protected bool DecideIfObstacle() => Random.Range(1, 20) < _obstacleWeight;


    public Stack<HexCell> CalculatePath(HexCell startCell)
    {
        var target = testBrainCoords;

        var cellPathsToTest = new List<HexCell> { startCell };
        var processed = new List<HexCell>();

        while (cellPathsToTest.Any())
        {
            // just get the 
            HexCell currentCell = cellPathsToTest.First();
            if(cellPathsToTest.Count > 1)
            {
                foreach (var t in cellPathsToTest)
                    if (t.Pathfinding.F < currentCell.Pathfinding.F || t.Pathfinding.F == currentCell.Pathfinding.F && t.Pathfinding.H < currentCell.Pathfinding.H) currentCell = t;
            }

            processed.Add(currentCell);
            cellPathsToTest.Remove(currentCell);

            if (currentCell.Coords.X == testBrainCoords.x && currentCell.Coords.Z == testBrainCoords.y)
            {
                //todo - unwind path stack
                var result = new Stack<HexCell>();
                var stackCell = currentCell;
                while (stackCell != null)
                {
                    result.Push(stackCell);
                    stackCell = stackCell.PreviousCellInChain;
                }

                return result;

            }

            foreach (var nextCellTest in currentCell.NeighborCellCache.Where(cell => cell.Walkable && 
                                                                                    !processed.Contains(cell)))
            {
                var costForMove = currentCell.Pathfinding.G + currentCell.GetDistance(nextCellTest.Coords);


                var inSearch = cellPathsToTest.Contains(nextCellTest);

                if (!inSearch || costForMove < nextCellTest.Pathfinding.G)
                {
                    nextCellTest.Pathfinding.G = costForMove;
                    nextCellTest.SetPreviousCell(currentCell);
                    nextCellTest.SetPathString();

                    if (!inSearch)
                    {
                        // set the total distance to the goal
                        nextCellTest.Pathfinding.H = nextCellTest.GetDistance(testBrainCoords);
                        cellPathsToTest.Add(nextCellTest);
                        nextCellTest.SetPathString();

                    }
                }

            }

        }

        // something has gone really wrong
        Debug.LogError("Pathfinding couldnt get to destination!!");

        return null;
    }
}
