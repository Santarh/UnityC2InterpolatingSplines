using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public sealed class Curve
    {
        public IReadOnlyList<Vector2> Points { get; private set; }
        public CurveEndType EndType { get; private set; }

        public Curve(IReadOnlyList<Vector2> points, CurveEndType endType)
        {
            Points = points;
            EndType = endType;
        }

        public static Curve Circle()
        {
            var division = 4;
            return new Curve(Enumerable.Range(0, division).Select(x =>
            {
                var theta = math.radians(360f * x / division);
                return new Vector2(math.cos(theta), math.sin(theta));
            }).ToList(), CurveEndType.Hide);
        }
    }
}
