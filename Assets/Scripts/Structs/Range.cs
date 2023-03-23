public struct Range
{
    public int min;
    public int max;

    public Range(int min, int max)
    {
        this.min = min;
        this.max = max;
    }

    public bool Contains(int value)
    {
        return value >= min && value <= max;
    }
}

