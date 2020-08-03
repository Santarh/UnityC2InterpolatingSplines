using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public sealed class CircleCurveEvaluator
    {
        public List<Vector2> Evaluate(Curve curve, ICircleCurveInterpolationProvider interpolationProvider)
        {
            if (curve.Points.Count < 3) return new List<Vector2>();
            
            var startIndex = curve.EndType == CurveEndType.Hide ? 0 : 1;

            var evaluatedPoints = new List<Vector2>();
            CircleCurvePiece previousPiece = null;
            for (var i = 0; i < curve.Points.Count - 2; ++i)
            {
                var piece = interpolationProvider.Interpolate(curve.Points[i], curve.Points[i + 1], curve.Points[i + 2]);
                var currentPiece = piece;

                if (previousPiece != null && currentPiece != null)
                {
                    for (var j = 0; j < 128; ++j)
                    {
                        evaluatedPoints.Add(EvaluateCurve(previousPiece, currentPiece, j / 127f));
                    }
                }

                previousPiece = piece;
            }

            return evaluatedPoints;
        }

        private Vector2 EvaluateCurve(CircleCurvePiece piece1, CircleCurvePiece piece2, float t)
        {
            var p1 = EvaluatePiece(piece1, t, isFirstPiece: true);
            var p2 = EvaluatePiece(piece2, t, isFirstPiece: false);

            var weight = math.pow(math.sin(math.PI * 0.5f * t), 2);

            return Vector2.Lerp(p1, p2, weight);
        }

        private Vector2 EvaluatePiece(CircleCurvePiece piece, float t, bool isFirstPiece)
        {
            var limits = isFirstPiece ? new Vector2(0, piece.Radian2) : new Vector2(piece.Radian1, 0);
            var tt = limits.x + t * (limits.y - limits.x);
            return piece.Center + piece.Axis1 * math.cos(tt) + piece.Axis2 * math.sin(tt);
        }
    }
}