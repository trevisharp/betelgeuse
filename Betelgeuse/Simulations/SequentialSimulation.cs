namespace Betelgeuse.Simulations;

public class SequentialSimulation : Simulation
{
    public override void Tick(List<Body> bodies, float dt)
        => SequentialTick(bodies, dt);
}