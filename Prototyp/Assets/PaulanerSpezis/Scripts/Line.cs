using System.Collections.Generic;

public class Line
{
    private List<Mob> _objects;
    private List<UsedState> _spaces;
    private int _width;
    private int _zPos;

    public Line(int width, int zPos, int SpaceSize)
    {
        _width = width;
        _zPos = zPos;
        _objects = new List<Mob>();
        _spaces = new List<UsedState>();
        for(int i = 0; i < width * SpaceSize; i++) {
            UsedState usedState = new UsedState();
            usedState = UsedState.Free;
            _spaces.Add(usedState);
        }
    }

    public List<Mob> Objects
    {
        get { return _objects; }
        set { _objects = value; }
    }

    public List<UsedState> Spaces
    {
        get { return _spaces; }
        set { _spaces = value; }
    }

    public int Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public int ZPos
    {
        get { return _zPos; }
        set { _zPos = value; }
    }

    public void FillSpaces(int start, int end)
    {
        for(int i = 0; i < _spaces.Count; i++)
        {
            if (i >= start && i <= end) _spaces[start] = UsedState.Used;
        }
    }

    public void FreeSpaces(int start, int end)
    {
        for (int i = 0; i < _spaces.Count; i++)
        {
            if (i >= start && i <= end) _spaces[start] = UsedState.Free;
        }
    }

    public void AddMob(Mob mob)
    {
        _objects.Add(mob);
    }

    public void RemoveMob(Mob mob)
    {
        _objects.Remove(mob);
    }
}
