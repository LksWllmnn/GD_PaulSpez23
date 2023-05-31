public class Session
{
    private static Session instance;
    private int points;

    private Session()
    {
        points = 0;
    }

    public static Session Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new Session();
            }
            return instance;
        }
    }

    public int Points
    {
        get { return points; }
        set { points = value; }
    }

    public void ReloadSession()
    {
        points = 0;
    }
}
