public struct GroundCheckData
{
    public bool isgrounded;
    public float checkerRadius;
    public float checkerDistance;
    
    public GroundCheckData(bool isground, float radius, float distancetoCheck)
    {
        isgrounded = isground;
        checkerRadius = radius;
        checkerDistance = distancetoCheck;
    }
}