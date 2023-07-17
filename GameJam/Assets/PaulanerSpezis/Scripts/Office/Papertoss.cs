
public class Papertoss : Riddle
{
    public override event CallSolved CS;

    public override void Solved()
    {
        CS();
    }
}
