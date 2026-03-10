namespace Epicycles;

public record Vector(float X, float Y)
{
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