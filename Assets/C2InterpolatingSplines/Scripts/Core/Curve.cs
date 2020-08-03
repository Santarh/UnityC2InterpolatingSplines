using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public sealed class Curve
    {
        private readonly List<Vector2> _points = new List<Vector2>();

        public IReadOnlyList<Vector2> Points => _points;
        public CurveEndType EndType { get; private set; }

        public Curve(IEnumerable<Vector2> points, CurveEndType endType)
        {
            foreach (var point in points)
            {
                _points.Add(point);
            }
            EndType = endType;
        }

        public void AddPoint(Vector2 point)
        {
            _points.Add(point);
        }

        public static Curve Circle()
        {
            var division = 4;
            return new Curve(Enumerable.Range(0, division).Select(x =>
            {
                var theta = math.radians(360f * x / division);
                return new Vector2(math.cos(theta), math.sin(theta));
            }), CurveEndType.Hide);
        }
    }

    public enum CurveEndType
    {
        Hide = 0,
        Show = 1,
        Loop = 2,
    }
}
