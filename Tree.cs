public class Node
{
    public Othello state { get; set }
    public List<Node> Children { get; set; } = new();
    public bool Expanded { get; set; } = false;
    private static Min = NegativeInfinity();
    private static Max = PositiveInfinity();

    public float AlphaBeta(Node node, bool maximize, int depth)
    {

    }

    public float AlphaBeta(Node node, float alpha, float beta, bool maximize, int depth)
    {
        if (depth == 0 || this.Children.Count < 1)
            return eval(this);
        
        float value;
        if (maximize)
        {
            value = Min;
            foreach(Node child in Children)
            {
                value = 
            }
        }
    }

    private float eval()
    {
        // TODO
        if (State.GameEnded())
            return YouPlays ? float.PositiveInfinity : float.NegativeInfinity;
        
        return Random.Shared.NextSingle();
    }

    public void Expand(Node node, Max maximize, int deep)
            => return MiniMaxAlphaBeta(Node node, Max maximize, int deep)





}