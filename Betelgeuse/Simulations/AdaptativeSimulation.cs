namespace Betelgeuse.Simulations;

public class AdaptativeSimulation : Simulation
{
    int tickCount = 0;
    int maxSeqBodyCount = 10;
    int minParalBodyCount = 100_000;

    public override void Tick(List<Body> bodies, float dt)
    {
        if (TryUpdateStrategy(bodies, dt))
            return;
        
        if (bodies.Count < maxSeqBodyCount)
            SequentialTick(bodies, dt);
        else if (bodies.Count > minParalBodyCount)
            ParallelTick(bodies, dt);
        else MixedTick(bodies, dt);
    }

    bool TryUpdateStrategy(List<Body> bodies, float dt)
    {
        tickCount++;
        if (tickCount % 20 != 0)
            return false;
        
        if (bodies.Count < maxSeqBodyCount || bodies.Count > minParalBodyCount)
            return false;
        
        if (int.Abs(bodies.Count / maxSeqBodyCount) < int.Abs(bodies.Count - minParalBodyCount))
            TestMinLimit(bodies, dt);
        else TestMaxLimit(bodies, dt);

        return true;
    }

    void TestMinLimit(List<Body> bodies, float dt)
    {   
        var start = DateTime.UtcNow;
        SequentialTick(bodies, dt / 2);
        var seqTime = DateTime.UtcNow - start;

        start = DateTime.UtcNow;
        MixedTick(bodies, dt / 2);
        var mixedTime = DateTime.UtcNow - start;

        if (mixedTime < seqTime)
            return;
        
        maxSeqBodyCount = 11 * bodies.Count / 10;
    }

    void TestMaxLimit(List<Body> bodies, float dt)
    {
        var start = DateTime.UtcNow;
        ParallelTick(bodies, dt / 2);
        var parTime = DateTime.UtcNow - start;

        start = DateTime.UtcNow;
        MixedTick(bodies, dt / 2);
        var mixedTime = DateTime.UtcNow - start;

        if (mixedTime < parTime)
            return;
        
        minParalBodyCount = 9 * bodies.Count / 10;
    }
}