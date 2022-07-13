using System;
using UnityEngine;

namespace HexGridLib
{
    public struct HexCoords
    {
        public override int GetHashCode()
        {
            unchecked
            {
                return (X * 397) ^ Z;
            }
        }

        public int X;

        /// <summary>
        /// Think of this one as "Y", but in hexes its Z
        /// </summary>
        public int Z;

        public override string ToString() => $"{X},{Z}";

        public float GetDistance(HexCoords other)
        {
            var coordsDistance = new HexCoords
            {
                Z = this.Z - other.Z,
                X = this.X - other.X,
            };
            var distanceResult = coordsDistance.HexGridLengthAway();

            return distanceResult;
        }

        public float HexGridLengthAway()
        {
            // first if the coords are 0, then the length is 0
            if (X == 0 && Z == 0) return 0;

            // with that out of the way, the craziness begins!
            // no i dont understand what is happening really, i have tried my best to
            // taken from https://www.youtube.com/watch?v=i0x5fj4PqP4
            // please watch this video before even attempting to adjust this code


            // effectivly at this point we have a Vector2 in Grid Form and we are calculating distance of these coords from 0/0
            // there are 6 possible returns, covering all directions
            // if the X is greater than 0, and the Z is or greater than 0, then we are in 1+/1+ range on the grid (aka top right)
            // then we can just return the sum of the two coords
            if (X > 0 && Z >= 0) return X + Z;

            // next up the 0-/1+ range (aka going Left)
            if (X <= 0 && Z > 0)
            {
                // next up we need to see if the positive value of X < Z
                // we have already determined that X is negative, so doing a negative flips the sign
                var positiveX = -X;
                // if positive X is Less than Z, then return the Z distance, otherwise the positive X
                // distances cant be 0 so
                return positiveX < Z ? Z : positiveX;
            }

            // if we get here then BOTH coords are < 0
            // then we can return the inverse sum if the X is negative
            if (X < 0) return -X - Z;

            // finally if all else fails
            // if the Inverse of Z is greater than Q, return InverseX, otherwise return Z;
            return -Z > X ? -Z : X;
        }

        #region EqualityOperators
        public static bool operator ==(HexCoords coords, Vector2Int other)
        {
            return coords.X == other.x && coords.Z == other.y;
        }

        public static bool operator !=(HexCoords coords, Vector2Int other)
        {
            return coords.X != other.x || coords.Z != other.y;
        }

        public bool Equals(HexCoords other)
        {
            return X == other.X && Z == other.Z;
        }

        public override bool Equals(object obj)
        {
            return obj is HexCoords other && Equals(other);
        }

        #endregion
    }
}
