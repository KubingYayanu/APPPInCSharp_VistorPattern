namespace APPPInCSharp_VistorPattern
{
    /// <summary>
    /// 物料報表
    /// </summary>
    public interface PartVisitor
    {
        void Visit(PiecePart pp);

        void Visit(Assembly a);
    }
}