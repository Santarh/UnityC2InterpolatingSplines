using System.Collections.Generic;
using C2InterpolatingSplines.Core;
using UnityEngine;

namespace C2InterpolatingSplines
{
    public sealed class CurveBehaviour : MonoBehaviour
    {
        public List<Vector2> _controlPoints = new List<Vector2>();
        public CurveEndType _endType = CurveEndType.Hide;

        public IReadOnlyList<Vector2> ControlPoints => _controlPoints;

        public List<Vector2> GetEvaluatedPoints()
        {
            return new SplineEvaluator().Evaluate(new Curve(_controlPoints, _endType), new CircularInterpolationFunctionProvider());
        }
    }
}