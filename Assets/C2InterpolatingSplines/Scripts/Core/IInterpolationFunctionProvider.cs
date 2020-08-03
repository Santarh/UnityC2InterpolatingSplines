using UnityEngine;

namespace C2InterpolatingSplines.Core
{
    public interface IInterpolationFunctionProvider
    {
        SplinePiece Interpolate(Vector2 point0, Vector2 point1, Vector2 point2);
    }
}