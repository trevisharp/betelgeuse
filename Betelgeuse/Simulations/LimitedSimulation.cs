namespace Betelgeuse.Simulations;

public class LimitedSimulation(float maxDelta, Simulation baseSimul) : Simulation
{
    public override void Tick(List<Body> bodies, float dt)
    {
        while (dt > maxDelta)
        {
            dt -= maxDelta;
            baseSimul.Tick(bodies, maxDelta);
        }

        if (dt > 0)
            baseSimul.Tick(bodies, dt);
    }
}