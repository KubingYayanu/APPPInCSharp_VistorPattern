namespace APPPInCSharp_VistorPattern
{
    public class PiecePart : Part
    {
        private string partNumber;
        private string description;
        private double cost;

        public PiecePart(string partNumber, string description, double cost)
        {
            this.partNumber = partNumber;
            this.description = description;
            this.cost = cost;
        }

        public string Description => description;

        public string PartNumber => partNumber;

        public double Cost => cost;

        public void Accept(PartVisitor v)
        {
            v.Visit(this);
        }
    }
}