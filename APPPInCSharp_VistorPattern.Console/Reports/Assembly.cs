using System.Collections.Generic;

namespace APPPInCSharp_VistorPattern
{
    public class Assembly : Part
    {
        private List<Part> parts = new List<Part>();
        private string partNumber;
        private string description;

        public Assembly(string partNumber, string description)
        {
            this.partNumber = partNumber;
            this.description = description;
        }

        public Assembly()
        {
        }

        public string Description => description;

        public string PartNumber => partNumber;

        public IList<Part> Parts => parts;

        public void Accept(PartVisitor v)
        {
            v.Visit(this);
            foreach (var part in parts)
            {
                part.Accept(v);
            }
        }

        public void Add(Part part)
        {
            parts.Add(part);
        }
    }
}