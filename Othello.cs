public class Othello
{
    byte whiteCount;
    byte blackCount;
    bool whitePlays;
    public byte WhitePoints;
    public byte BlackPoints;
    private ulong whiteInfo;
    private ulong blackInfo;
    private ulong u = 1;

    public Othello(bool whitePlays)
    {
        this.whitePlays = whitePlays;
    }


    // /// <summary>
    // /// Obtém a última jogada
    // /// </summary>
    // public (int board, int position) GetLast()
    //     => (lastBoard, lastPosition);

    /// <summary>
    /// Joga em uma posição em um tabuleiro
    /// </summary>
    public void Play(int board, int posit)
    {
        // todo
    }

    /// <summary>
    /// Testa e retorna verdadeiro se você pode jogar em um tabuleiro
    /// </summary>
    public bool CanPlay(ulong pos)
    {
        var whiteMove = whiteInfo | pos;
        var blackMove = blackInfo | pos;

        if (whiteMove == whiteInfo || blackMove == blackInfo)
            return false;

        int[] rowOffsets = { -1, 1, 0, 0, -1, -1, 1, 1 }
        int[] colOffsets = { 0, 0, -1, 1, -1, 1, -1, 1 };
        var enemyInfo = this.whitePlays ? blackInfo : whiteInfo;

        for (int i = 0; i < 8; i++)
        {
            if (hasAdjacentEnemy(enemyInfo, pos, rowOffsets[i], colOffsets[i]))
                return true;
        }

        return false;
    }

    private bool hasAdjacentEnemy(ulong playerInfo, ulong pos, int rowOffset, int colOffset)
    {
        ulong adjacentPos = pos << (8 * rowOffset) << colOffset;

        return (adjacentPos & playerInfo) != 0;
    }

    /// <summary>
    /// Retorna verdadeiro se o jogo acabou
    /// </summary>
    public bool GameEnded()
    {
        for (int i = 0; i < boards; i++)
        {
            if (CanPlay(i))
                return false;
        }
        return true;
    }

    /// <summary>
    /// </summary>
    public Othello Clone()
    {
        Othello clone = new Othello(whitePlays);
        clone.blackCount = this.blackCount;
        clone.blackInfo = this.blackInfo;
        clone.BlackPoints = this.BlackPoints;
        clone.whiteCount = this.whiteCount;
        clone.whiteInfo = this.whiteInfo;
        clone.WhitePoints = this.WhitePoints;

        return clone;
    }

    /// <summary>
    /// Obtém próximas jogadas válidas
    /// </summary>
    public IEnumerable<Othello> Next()
    {
        for (int i = 0; i < 64; i++)
        {
            if (CanPlay(u << i))
            {
                var clone = this.Clone();
                clone.Play( u << i);
                yield return clone;
            }
        }
    }
}
