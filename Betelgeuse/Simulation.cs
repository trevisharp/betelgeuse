using Betelgeuse.Simulations;

namespace Betelgeuse;

public abstract class Simulation
{
    public static readonly Simulation Sequential = new SequentialSimulation();
    public static readonly Simulation Parallel = new ParallelSimulation();
    public static readonly Simulation Mixed = new MixedSimulation();
    public static readonly Simulation Adaptative = new AdaptativeSimulation();
    public static Simulation Limited(float maxDeltaTime, Simulation baseSimul)
        => new LimitedSimulation(maxDeltaTime, baseSimul);
    public static Simulation Best(float maxDeltaTime)
        => Limited(maxDeltaTime, Adaptative);

    public abstract void Tick(List<Body> bodies, float dt);

    protected static void SequentialTick(List<Body> bodies, float dt)
    {
        foreach (var body in bodies)
            body.ComputeForce(dt);
        
        foreach (var body in bodies)
            body.Tick(dt);
    }

    protected static void MixedTick(List<Body> bodies, float dt)
    {
        System.Threading.Tasks.Parallel.ForEach(bodies,
            (body, token) => body.ComputeForce(dt)
        );
        
        foreach (var body in bodies)
            body.Tick(dt);
    }

    protected static void ParallelTick(List<Body> bodies, float dt)
    {
        System.Threading.Tasks.Parallel.ForEach(bodies,
            (body, token) => body.ComputeForce(dt)
        );

        System.Threading.Tasks.Parallel.ForEach(bodies,
            (body, token) => body.Tick(dt)
        );
    }
}