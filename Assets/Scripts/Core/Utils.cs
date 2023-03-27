using UnityEngine;

public class Utils
{
    public static void DrawBox(Vector2 center, Vector2 size, Color color)
    {
        Rectangle rectangle = new Rectangle(center, size);
        Debug.DrawLine(rectangle.TL, rectangle.TR, color);
        Debug.DrawLine(rectangle.BL, rectangle.BR, color);
        Debug.DrawLine(rectangle.TL, rectangle.BL, color);
        Debug.DrawLine(rectangle.TR, rectangle.BR, color);
    }
    
    /// <summary>
    /// Calculates the intersection of two given lines
    /// </summary>
    /// <param name="intersection">returned intersection</param>
    /// <param name="linePoint1">start location of the line 1</param>
    /// <param name="lineDirection1">direction of line 1</param>
    /// <param name="linePoint2">start location of the line 2</param>
    /// <param name="lineDirection2">direction of line2</param>
    /// <returns>true: lines intersect, false: lines do not intersect</returns>
    public static bool VectorIntersection(ref Vector3 intersection,
        Vector3 linePoint1, Vector3 lineDirection1,
        Vector3 linePoint2, Vector3 lineDirection2)
    {
 
        Vector3 lineVec3 = linePoint2 - linePoint1;
        Vector3 crossVec1and2 = Vector3.Cross(lineDirection1, lineDirection2);
        Vector3 crossVec3and2 = Vector3.Cross(lineVec3, lineDirection2);
        float planarFactor = Vector3.Dot(lineVec3, crossVec1and2);
 
        //is coplanar, and not parallel
        if (Mathf.Abs(planarFactor) < 0.0001f
            && crossVec1and2.sqrMagnitude > 0.0001f)
        {
            float s = Vector3.Dot(crossVec3and2, crossVec1and2) / crossVec1and2.sqrMagnitude;
            intersection = linePoint1 + (lineDirection1 * s);
            return true;
        }
        else
        {
            intersection = Vector3.zero;
            return false;
        }
    }
}