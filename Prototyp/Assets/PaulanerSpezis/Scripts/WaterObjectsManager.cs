using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WaterObjectsManager : MonoBehaviour
{
    private static WaterObjectsManager instance;
    private static object lockObject = new object();
    private List<GameObject> _placedObjects;
    
    [InspectorLabel("Changes the speed of the mobs how fast they appear and disapear (slowest)")]
    [SerializeField][Range(0f, 10f)]private float _changeSpeedMin;
    [InspectorLabel("Changes the speed of the mobs how fast they appear and disapear (fastest)")]
    [SerializeField][Range(0f, 20f)]private float _changeSpeedMax;
    [SerializeField] private int _numberOfLines;
    private List<Line> _lines = new List<Line>();
    public int AmountSpaces = 16;
    
    [Header("Objects, which should be placed on the Water")]
    [SerializeField] private List<GameObject> _stones;
    [SerializeField] private List<GameObject> _goodMobs;
    [SerializeField] private List<GameObject> _badMobs;
    

    private void Start()
    {
        _changeSpeedMin = 0.0f;
        _changeSpeedMax = 0.0f;
        _placedObjects = new List<GameObject>();
        _stones = new List<GameObject>();
        _goodMobs = new List<GameObject>();
        _badMobs = new List<GameObject>();

        BoxCollider boxCollider = this.GetComponent<BoxCollider>();
        Vector3 boxColPos = boxCollider.center + this.transform.position;
        float lineWidth = boxCollider.size.x;
        float lineHeight = boxCollider.size.z / _numberOfLines;


        for (int i = 0; i < _numberOfLines; i++)
        {
            _lines.Add(new Line(lineWidth, boxColPos.z - (boxCollider.size.z / 2) + lineHeight * i + lineHeight / 2, AmountSpaces, boxColPos.x));
        }
    }

    public float ChangeSpeedMin
    {
        get { return _changeSpeedMin; }
        set { _changeSpeedMin = value; }
    }

    public float ChangeSpeedMax
    {
        get { return _changeSpeedMax; }
        set { _changeSpeedMax = value; }
    }

    public List<GameObject> PlacedObjects
    {
        get { return _placedObjects; }
    }

    public List<GameObject> Stones
    {
        get { return _stones; }
    }

    public List<GameObject> GoodMobs
    {
        get { return _goodMobs; }
    }

    public List<GameObject> BadMobs
    {
        get { return _badMobs; }
    }

    public void PlaceNewMob()
    {
        GameObject go = Instantiate(GetRandomMob());
    }

    public GameObject GetRandomMob()
    {
        float moodDecider = Mathf.Round(Random.value);
        if (moodDecider == 0) 
        {
            float mobDecider = Mathf.Round(Random.Range(0, _badMobs.Count));
            return _badMobs[(int)mobDecider];
        } else
        {
            float mobDecider = Mathf.Round(Random.Range(0, _goodMobs.Count));
            return _goodMobs[(int)mobDecider];
        }
    }

    public void RemoveMob(Mob mob)
    {
        _lines[mob.Line].RemoveMob(mob);
        Destroy(mob.gameObject);
    }

    public void PlaceStones()
    {
    }
}
