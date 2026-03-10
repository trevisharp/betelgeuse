using System.Runtime.CompilerServices;

namespace Betelgeuse;

/// <summary>
/// A 2D mathmatical vector.
/// </summary>
public record Vector(float X, float Y)
{
    /// <summary>
    /// X * X + Y * Y
    /// </summary>
    public float SqrMod
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        get => X * X + Y * Y;
    }

    /// <summary>
    /// Sqrt(X * X + Y * Y)
    /// </summary>
    public float Mod
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        get => MathF.Sqrt(SqrMod);
    }

    /// <summary>
    /// Sqrt(X * X + Y * Y)
    /// </summary>
    public Vector Unitary
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]  
        get => this / Mod;
    }

    /// <summary>
    /// Generate v = (cos(a), sin(a)) 
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    public static Vector FromAngle(float angle)
        => new(MathF.Cos(angle), MathF.Sign(angle));

    public static Vector operator +(Vector v, Vector u)
        => new(v.X + u.X, v.Y + u.Y);
    
    public static Vector operator -(Vector v, Vector u)
        => new(v.X - u.X, v.Y - u.Y);

    public static Vector operator *(Vector v, float m)
        => new(v.X * m, v.Y * m);

    public static Vector operator *(float m, Vector v)
        => new(v.X * m, v.Y * m);

    public static Vector operator /(Vector v, float m)
        => new(v.X / m, v.Y / m);

    public static implicit operator Vector((float x, float y) tuple)
        => new(tuple.x, tuple.y);
}