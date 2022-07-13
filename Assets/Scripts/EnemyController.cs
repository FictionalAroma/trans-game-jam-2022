using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Scripts;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static float NewPositionRadius = 0.01f;
    private static float floatingHeight = 0.5f;


    [Tooltip("Number of Seconds to move Per Tile")]
    public float moveSpeed = 3f;


    private Vector3 _previousCellPos;
    private Vector3 _currentMoveTarget;
    private HexCell _currentTargetCell;

    private Queue<HexCell> _walkPath;

    private float elapsedCellTransferTime = 0f;
    void Update()
    {
        var targetPos = _currentTargetCell.transform.position;
        targetPos.y = floatingHeight;

        if (Vector3.Distance(transform.position, _currentTargetCell.transform.position) < floatingHeight + NewPositionRadius)
        {
            if (_walkPath.Any())
            {
                SetCellTarget();

                elapsedCellTransferTime = 0f;
            }
            else
            {
                Destroy(this);
            }
        }
        elapsedCellTransferTime += Time.deltaTime;


        var newPos = Vector3.Lerp(_previousCellPos, GetTarget(_currentTargetCell.transform.position), elapsedCellTransferTime / moveSpeed);

        transform.position = new Vector3(newPos.x, floatingHeight, newPos.z);

    }

    public static Vector3 GetTarget(Vector3 transformPosition)
    {
        return new Vector3(transformPosition.x, floatingHeight, transformPosition.z);
    }


    private void OnTriggerEnter(Collider other)
    {
        Destroy(this);
    }

    public void SetPath(Stack<HexCell> path)
    {
        _walkPath = new Queue<HexCell>(path);
        SetCellTarget();
    }

    private void SetCellTarget()
    {
        _currentTargetCell = _walkPath.Dequeue();
        _currentMoveTarget = GetTarget(_currentTargetCell.Position);
        _previousCellPos = transform.position;
    }
}
