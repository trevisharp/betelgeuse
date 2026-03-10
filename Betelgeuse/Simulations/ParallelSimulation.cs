namespace Betelgeuse.Simulations;

public class ParallelSimulation : Simulation
{
    public override void Tick(List<Body> bodies, float dt)
        => ParallelTick(bodies, dt);
}