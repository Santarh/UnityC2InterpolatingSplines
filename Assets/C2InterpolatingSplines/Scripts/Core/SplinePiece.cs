using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public class SplinePiece
    {
        /// <summary>
        /// Center Position.
        /// </summary>
        public Vector2 Center;
        
        /// <summary>
        /// First Axis.
        /// </summary>
        public Vector2 Axis1;
        
        /// <summary>
        /// Second Axis.
        /// </summary>
        public Vector2 Axis2;

        /// <summary>
        /// radian is chosen such that F_i(0) = P_{i-1}
        /// </summary>
        public readonly float Radian1;
        
        /// <summary>
        /// radian is chosen such that F_i(1) = P_{i+1}
        /// </summary>
        public readonly float Radian2;

        public SplinePiece(Vector2 center, Vector2 axis1, Vector2 axis2, float radian1, float radian2)
        {
            Center = center;
            Axis1 = axis1;
            Axis2 = axis2;
            Radian1 = radian1;
            Radian2 = radian2;
        }
    }
}