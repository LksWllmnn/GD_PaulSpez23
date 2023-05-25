using System.Collections;
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
    [Header("Objects, which should be placed on the Water")]
    [SerializeField]
    private List<GameObject> _stones;
    [SerializeField]
    private List<GameObject> _goodMobs;
    [SerializeField]
    private List<GameObject> _badMobs;

    private WaterObjectsManager()
    {
        _changeSpeedMin = 0.0f;
        _changeSpeedMax = 0.0f;
        _placedObjects = new List<GameObject>();
        _stones = new List<GameObject>();
        _goodMobs = new List<GameObject>();
        _badMobs = new List<GameObject>();
    }

    public static WaterObjectsManager Instance
    {
        get
        {
            lock (lockObject)
            {
                if (instance == null)
                {
                    instance = new WaterObjectsManager();
                }
                return instance;
            }
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
    }

    public void RemoveMob()
    {
    }

    public void PlaceStones()
    {
    }
}
