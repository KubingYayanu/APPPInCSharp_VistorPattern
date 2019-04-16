namespace APPPInCSharp_VistorPattern
{
    public class ExplodedCostVisitor : PartVisitor
    {
        private double cost = 0;

        public double Cost => cost;

        public void Visit(Assembly a)
        {
        }

        public void Visit(PiecePart pp)
        {
            cost += pp.Cost;
        }
    }
}