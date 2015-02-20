using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public struct IntVector2
{
    public int x;
    public int y;

    public IntVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public IntVector2(float x, float y)
    {
        this.x = (int)x;
        this.y = (int)y;
    }

    public IntVector2(Vector2 v) : this(v.x, v.y) { }

    #region operator overloads
    public static IntVector2 operator -(IntVector2 a)
    {
        return new IntVector2(-a.x, -a.y);
    }

    public static IntVector2 operator -(IntVector2 a, IntVector2 b)
    {
        return new IntVector2(a.x - b.x, a.y - b.y);
    }

    public static IntVector2 operator +(IntVector2 a, IntVector2 b)
    {
        return new IntVector2(a.x + b.x, a.y + b.y);
    }

    public static bool operator ==(IntVector2 a, IntVector2 b)
    {
        return (a.x == b.x && a.y == b.y);
    }

    public override bool Equals(object a)
    {
        if (a == null)
            return false;

        if (!(a is IntVector2))
            return false;

        return this.Equals((IntVector2)a);
    }

    public bool Equals(IntVector2 a)
    {
        if ((object)a == null)
            return false;

        return a.x == this.x && a.y == this.y;
    }

    public override int GetHashCode()
    {
        return this.x.GetHashCode() * 17 + this.y.GetHashCode();
    }

    public static bool operator !=(IntVector2 a, IntVector2 b)
    {
        return !(a == b);
    }

    public static Vector2 operator -(Vector2 a, IntVector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static Vector2 operator -(IntVector2 a, Vector2 b)
    {
        return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static Vector2 operator +(Vector2 a, IntVector2 b)
    {
        return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static Vector2 operator +(IntVector2 a, Vector2 b)
    {
        return (b + a);
    }

    public static bool operator ==(Vector2 a, IntVector2 b)
    {
        return (a.x == b.x && a.y == b.y);
    }

    public static bool operator ==(IntVector2 a, Vector2 b)
    {
        return (b == a);
    }

    public static bool operator !=(Vector2 a, IntVector2 b)
    {
        return !(a == b);
    }

    public static bool operator !=(IntVector2 a, Vector2 b)
    {
        return (b != a);
    }
    #endregion

    // implicit conversion to Vector2
    public static implicit operator Vector2(IntVector2 a)
    {
        return new Vector2(a.x, a.y);
    }
}
