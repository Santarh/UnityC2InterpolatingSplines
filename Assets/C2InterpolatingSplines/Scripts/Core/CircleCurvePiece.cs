using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public class CircleCurvePiece
    {
        /// <summary>
        /// 円の中心
        /// </summary>
        public Vector2 Center;
        
        /// <summary>
        /// 円の第一軸
        /// </summary>
        public Vector2 Axis1;
        
        /// <summary>
        /// 円の第二軸
        /// </summary>
        public Vector2 Axis2;

        /// <summary>
        /// P_i を 0 としたときの P_{i-1} の角度
        /// </summary>
        public readonly float Radian1;
        
        /// <summary>
        /// P_i を 0 としたときの P_{i+1} の角度
        /// </summary>
        public readonly float Radian2;

        public CircleCurvePiece(Vector2 center, Vector2 axis1, Vector2 axis2, float radian1, float radian2)
        {
            Center = center;
            Axis1 = axis1;
            Axis2 = axis2;
            Radian1 = radian1;
            Radian2 = radian2;
        }
    }
}