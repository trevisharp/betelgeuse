namespace Epicycles;

/// <summary>
/// A abstract physical 2D body.
/// </summary>
public abstract class Body
{
    readonly List<Force> forces = [];

    public float Mass { get; private set; } = 1f;
    public Vector Position { get; private set; } = (0, 0);
    public Vector Speed { get; private set; } = (0, 0);
    public Vector Force { get; private set; } = (0, 0);

    public void Attatch(Force force)
        => forces.Add(force);

    public void Deattatch(Force force)
        => forces.Remove(force);
    
    public void ComputeForce(float dt)
    {
        Force = (0, 0);
        foreach (var force in forces)
            Force += force.Apply(this, dt);
    }

    public void Tick(float dt)
    {
        OnTick(dt);

        Speed += Force / Mass * dt;
        Position += Speed * dt;
    }

    public virtual void OnTick(float dt) { }
}