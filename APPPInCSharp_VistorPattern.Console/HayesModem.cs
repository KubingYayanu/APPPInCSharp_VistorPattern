namespace APPPInCSharp_VistorPattern
{
    public class HayesModem : Modem
    {
        public string ConfigurationString { get; set; }

        public void Accept(ModemVistor vistor)
        {
            vistor.Visit(this);
        }

        public void Dial(string pno)
        {
        }

        public void Hangup()
        {
        }

        public char Receive() => (char)0;

        public void Send(char c)
        {
        }
    }
}