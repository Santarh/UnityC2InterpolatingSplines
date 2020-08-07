using System;
using C2InterpolatingSplines.Core;
using UnityEngine;

namespace C2InterpolatingSplines
{
    public sealed class CurveDebugDrawerBehaviour : MonoBehaviour
    {
        [SerializeField] private CurveBehaviour _curve;
        [SerializeField] private bool _drawControlLine = false;
        [SerializeField] private bool _drawCurve = false;

        private void Reset()
        {
            _curve = GetComponent<CurveBehaviour>();
        }
        
        private void Start()
        {
            if (_curve == null)
            {
                Reset();
            }
        }

        private void OnDrawGizmos()
        {
            if (_curve == null || _curve.ControlPoints == null) return;

            var points = _curve.ControlPoints;

            if (_drawControlLine)
            {
                for (var i = 0; i < points.Count - 1; ++i)
                {
                    var p0 = points[i];
                    var p1 = points[i + 1];
                    Gizmos.color = Color.gray;
                    Gizmos.DrawLine(new Vector3(p0.x, p0.y, 0), new Vector3(p1.x, p1.y, 0));
                }
            }

            if (_drawCurve)
            {
                var evaluated = _curve.GetEvaluatedPoints();
                for (var i = 0; i < evaluated.Count - 1; ++i)
                {
                    var p0 = evaluated[i];
                    var p1 = evaluated[i + 1];
                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(new Vector3(p0.x, p0.y, 0), new Vector3(p1.x, p1.y, 0));
                }
            }

            for (var i = 0; i < points.Count; ++i)
            {
                var p0 = points[i];
                Gizmos.color = Color.black;
                Gizmos.DrawCube(new Vector3(p0.x, p0.y, 0), Vector3.one * 0.05f);
            }
        }
    }
}