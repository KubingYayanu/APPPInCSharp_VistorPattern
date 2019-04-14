namespace APPPInCSharp_VistorPattern
{
    public interface Modem
    {
        void Dial(string pno);

        void Hangup();

        void Send(char c);

        char Receive();

        void Accept(ModemVistor vistor);
    }
}