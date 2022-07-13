using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    private Stack<HexCell> _path;
    private HexCell _parentCell;

    // Start is called before the first frame update
    void Start()
    {
        CalculatePath();
    }

    public void Init(HexCell parentCell)
    {
        _parentCell = parentCell;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            SpawnEnemy();
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            CalculatePath();
        }
}

    private void SpawnEnemy()
    {
        var spawnPoint = transform.position;
        spawnPoint.y += 0.5f;
        var newEnemy = Instantiate(enemyToSpawn, spawnPoint, Quaternion.identity, this.transform.parent);
        newEnemy.SetPath(_path);
    }

    private void CalculatePath()
    {
        _path =  GridManager.Instance.CalculatePath(_parentCell);

        //ShowDebugPath();
    }

    private void ShowDebugPath()
    {
        if (Debug.isDebugBuild)
        {
            var testArray = _path.ToArray();

            for (int currentIndex = 0, nextItem = 1;
                 currentIndex < testArray.Length && nextItem < testArray.Length;
                 currentIndex++, nextItem++)
            {
                Debug.DrawLine(EnemyController.GetTarget(testArray[currentIndex].Position),
                    EnemyController.GetTarget(testArray[nextItem].Position), Color.green, 120f);
            }
        }
    }

}
