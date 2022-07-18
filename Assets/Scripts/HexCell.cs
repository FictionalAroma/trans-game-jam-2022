using System;
using System.Collections.Generic;
using System.Linq;
using HexGridLib;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class HexCell : MonoBehaviour
    {
        public HexCoords Coords;

        public TextMeshProUGUI coordsText, pathfinderText;

        public List<HexCell> NeighborCellCache { get; private set; }

        public PathfindingValues Pathfinding;

        public bool Walkable { get; set; }

        public Vector3 Position => transform.position;
        // Use this for initialization
        void Awake()
        {
            NeighborCellCache = new List<HexCell>();
            Pathfinding = new PathfindingValues();
            Walkable = true;
        }

        internal void Init(int xIndex, int yIndex)
        {
            Coords = new HexCoords()
            {
                X = xIndex,
                Z = yIndex,
            };
            coordsText.text = Coords.ToString();

            var posVector3 = xIndex * new Vector3(1, 0,0) + yIndex * new Vector3(0.5f, 0,1f);
            this.transform.position = posVector3;
        }
        private static readonly float Sqrt3 = Mathf.Sqrt(3);
        public void CacheNeighbors(List<HexCell> hexList)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
           NeighborCellCache = hexList.Where(cell => !cell.Coords.Equals(this.Coords)  && GetDistance(cell.Coords) == 1).ToList();
        }

        public float GetDistance(HexCoords other) => Coords.GetDistance(other);
        public float GetDistance(Vector2Int other) => Coords.GetDistance(new HexCoords(){X = other.x, Z = other.y});

        internal void SetPreviousCell(HexCell previousCell)
        {
            PreviousCellInChain = previousCell;
        }

        public void SetPathString()
        {
            pathfinderText.text = Pathfinding.ToString();
        }


    public HexCell PreviousCellInChain { get; private set; }
    }

    public struct PathfindingValues
    {
        /// <summary>
        /// Distance from Start
        /// </summary>
        public float G { get; set; }
        // distance to target
        public float H { get; set; }

        // final calculation of cost
        public float F => G + H;

        public override string ToString() => $"G - {G}{Environment.NewLine}H - {H}{Environment.NewLine}F-{F}";
    }

}