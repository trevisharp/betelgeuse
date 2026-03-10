namespace Betelgeuse.Simulations;

public class DefaultSimulation : Simulation
{
    public override void Tick(List<Body> bodies, float dt)
        => SequentialTick(bodies, dt);
}