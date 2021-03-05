using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Polar
{
    public float distance;
    public float angle;
    public Polar(float _distance, float _angle)
    {
        distance = _distance;
        angle = _angle;
    }
    public static Polar Vector2ToPolar(Vector2 vector)
    {
        Polar p = new Polar();
        p.distance = Mathf.Sqrt(vector.x * vector.x + vector.y * vector.y);
        p.angle = Mathf.Atan(vector.y / vector.x);
        return p;
    }
    public static Vector2 PolarToVector2(Polar polar)
    {
        Vector2 v = new Vector2();
        v.x = polar.distance * Mathf.Cos(polar.angle);
        v.y = polar.distance * Mathf.Sin(polar.angle);
        return v;
    }
}
