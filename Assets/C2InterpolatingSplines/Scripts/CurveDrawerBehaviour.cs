using System;
using C2InterpolatingSplines.Core;
using UnityEngine;

namespace C2InterpolatingSplines
{
    [ExecuteInEditMode]
    public sealed class CurveDrawerBehaviour : MonoBehaviour
    {
        [SerializeField] private CurveBehaviour _curve;

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
        
        private void Update()
        {
            if (_curve == null || _curve.points == null) return;
            
            var curve = new Curve(_curve.points, CurveEndType.Hide);
            var evaluated = new CircleCurveEvaluator().Evaluate(curve, new CircleInterpolationProvider());

            for (var i = 0; i < evaluated.Count - 1; ++i)
            {
                var p0 = evaluated[i];
                var p1 = evaluated[i + 1];
                Debug.DrawLine(new Vector3(p0.x, p0.y, 0), new Vector3(p1.x, p1.y, 0));
            }
        }
    }
}