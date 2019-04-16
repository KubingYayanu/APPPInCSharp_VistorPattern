namespace APPPInCSharp_VistorPattern
{
    public class UnixModemConfigurator : ModemVistor
    {
        public void Visit(ErnieModem modem)
        {
            modem.InternalPattern = "C is too slow";
        }

        public void Visit(ZoomModem modem)
        {
            modem.ConfigurationValue = 42;
        }

        public void Visit(HayesModem modem)
        {
            modem.ConfigurationString = "&s1=4&D=3";
        }
    }
}