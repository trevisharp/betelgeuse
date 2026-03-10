namespace Betelgeuse;

/// <summary>
/// The world simulation.
/// </summary>
public class World
{
    public Simulation Simulation { get; set; } = Simulation.Best(0.04f);

    readonly List<Body> bodies = [];

    public void Add(Body body)
        => bodies.Add(body);
    
    public void Tick(float dt)
        => Simulation.Tick(bodies, dt);
}