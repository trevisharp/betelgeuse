namespace Epicycles;

public abstract class Force
{
    public abstract Vector Apply(Body body, float dt);

    public static Force From(Func<Body, float, Vector> force)
        => new LambdaForce(force);

    public class LambdaForce(Func<Body, float, Vector> force) : Force
    {
        public override Vector Apply(Body body, float dt)
            => force(body, dt);
    }
}