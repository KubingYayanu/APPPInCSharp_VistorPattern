namespace APPPInCSharp_VistorPattern
{
    /// <summary>
    /// 物料
    /// </summary>
    public interface Part
    {
        string PartNumber { get; }
        string Description { get; }

        void Accept(PartVisitor v);
    }
}