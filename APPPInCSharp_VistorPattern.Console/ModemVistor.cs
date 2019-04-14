namespace APPPInCSharp_VistorPattern
{
    public interface ModemVistor
    {
        void Visit(HayesModem modem);

        void Visit(ZoomModem modem);

        void Visit(ErnieModem modem);
    }
}