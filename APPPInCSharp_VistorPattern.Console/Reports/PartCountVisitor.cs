using System.Collections;

namespace APPPInCSharp_VistorPattern
{
    public class PartCountVisitor : PartVisitor
    {
        private int pieceCount = 0;
        private Hashtable pieceMap = new Hashtable();

        /// <summary>
        /// 不論物料是否重複，每Visit一次+1
        /// </summary>
        public int PieceCount => pieceCount;

        /// <summary>
        /// 物料種類的數量
        /// </summary>
        public int PartNumberCount => pieceMap.Count;

        public void Visit(Assembly a)
        {
        }

        public void Visit(PiecePart pp)
        {
            pieceCount++;
            string partNumber = pp.PartNumber;
            int partNumberCount = 0;
            if (pieceMap.ContainsKey(partNumber))
            {
                partNumberCount = (int)pieceMap[partNumber];
            }

            partNumberCount++;
            pieceMap[partNumber] = partNumberCount;
        }

        /// <summary>
        /// 取得特定物料的數量
        /// </summary>
        /// <param name="partNumber"></param>
        /// <returns></returns>
        public int GetCountForPart(string partNumber)
        {
            int partNumberCount = 0;
            if (pieceMap.ContainsKey(partNumber))
            {
                partNumberCount = (int)pieceMap[partNumber];
            }
            return partNumberCount;
        }
    }
}