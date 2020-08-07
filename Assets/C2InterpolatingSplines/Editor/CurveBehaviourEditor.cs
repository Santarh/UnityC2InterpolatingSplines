using UnityEditor;
using UnityEngine;

namespace C2InterpolatingSplines
{
    [CustomEditor(typeof(CurveBehaviour))]
    public sealed class CurveBehaviourEditor : Editor
    {
        private void OnSceneGUI()
        {
            var self = target as CurveBehaviour;
            
            for (var i = 0; i < self._controlPoints.Count; ++i)
            {
                var p = self._controlPoints[i];
                self._controlPoints[i] = Handles.PositionHandle(new Vector3(p.x, p.y, 0), Quaternion.identity); 
            }
        }
    }
}