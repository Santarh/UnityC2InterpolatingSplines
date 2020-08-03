using Unity.Mathematics;
using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public class CircleInterpolationProvider : ICircleCurveInterpolationProvider
    {
        /// <summary>
        /// Get curve info from 3 points.
        /// index-1, index, index+1
        /// </summary>
        public CircleCurvePiece Interpolate(Vector2 point0, Vector2 point1, Vector2 point2)
        {
            var ci = point1; // i
            var cj = point0; // i - 1
            var ck = point2; // i + 1

            var vec1 = ci - cj; // P_i - P_{i-1}
            var mid1 = cj + vec1 / 2f;
            var dir1 = new Vector2(-vec1.y, vec1.x); // Tangent
            var vec2 = ck - ci; // P_{i+1} - P_i
            var mid2 = ci + vec2 / 2f;
            var dir2 = new Vector2(-vec2.y, vec2.x); // Tangent
            var det = dir1.x * dir2.y - dir1.y * dir2.x;
            if (math.abs(det) < 0.001f)
            {
                
            }
            var s = (dir2.y * (mid2.x - mid1.x) + dir2.x * (mid1.y - mid2.y)) / det; // radius scale
            var center = mid1 + s * dir1;
            var axis1 = ci - center;
            var axis2 = new Vector2(-axis1.y, axis1.x);
            var len2 = axis1.x * axis1.x + axis1.y * axis1.y;
            var toPt2 = ck - center;
            var limit2 = math.atan2(Vector2.Dot(axis2, toPt2), Vector2.Dot(axis1, toPt2));
            var toPt1 = cj - center;
            var limit1 = math.atan2(Vector2.Dot(axis2, toPt1), Vector2.Dot(axis1, toPt1));
            if ( limit1 * limit2 > 0 )
            {
                if (math.abs(limit1) < math.abs(limit2))
                {
                    limit2 += limit2 > 0 ? -2 * math.PI : 2 * math.PI;
                }
                if (math.abs(limit1) > math.abs(limit2))
                {
                    limit1 += limit1 > 0 ? -2 * math.PI : 2 * math.PI;
                }
            }

            return new CircleCurvePiece(center, axis1, axis2, limit1, limit2);
        }
    }
}