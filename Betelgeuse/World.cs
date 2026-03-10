namespace Epicycles;

public class World
{
    readonly List<Body> bodies = [];

    public void Add(Body body)
        => bodies.Add(body);
    
    public void Tick(float dt)
    {
        Parallel.ForEach(bodies,
            (body, token) => body.ComputeForce(dt)
        );
        
        Parallel.ForEach(bodies,
            (body, token) => body.Tick(dt)
        );
    }
}