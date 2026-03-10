namespace Betelgeuse.Simulations;

public class MixedSimulation : Simulation
{
    public override void Tick(List<Body> bodies, float dt)
        => MixedTick(bodies, dt);
}