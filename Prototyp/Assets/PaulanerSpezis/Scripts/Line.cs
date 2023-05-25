using System.Collections.Generic;
using UnityEngine;

public class Line
{
    private List<Mob> _objects;
    private List<UsedState> _spaces;
    private float _width;
    private float _zPos;
    private float _xPos;

    public Line(float width, float zPos, int spaceAmount, float xPos)
    {
        _width = width;
        _zPos = zPos;
        _xPos = xPos;
        _objects = new List<Mob>();
        _spaces = new List<UsedState>();
        for(int i = 0; i < width * spaceAmount; i++) {
            UsedState usedState = new UsedState();
            usedState = UsedState.Free;
            _spaces.Add(usedState);
        }
        Debug.Log(_zPos);
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

    public float Width
    {
        get { return _width; }
        set { _width = value; }
    }

    public float ZPos
    {
        get { return _zPos; }
        set { _zPos = value; }
    }

    private void FillSpaces(int start, int end)
    {
        for(int i = 0; i < _spaces.Count; i++)
        {
            if (i >= start && i <= end) _spaces[start] = UsedState.Used;
        }
    }

    private void FreeSpaces(int start, int end)
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
        Vector3 mobSize = mob.gameObject.transform.localScale;
        Vector3 mobPos = mob.gameObject.transform.localPosition;
        int UsedSpaces = (int)mobSize.x * Spaces.Count + 2;
        int startSpace = -1;
        FreeSpaces(startSpace, startSpace + UsedSpaces-1);
        _objects.Remove(mob);
    }
}
