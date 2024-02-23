public interface IBehaviorNode
{
    public IBehaviorNode NextNod { get; }
    public void Awake();
    public bool Condition();
    public void Action();
}