using Mirror;
using Mirror.Examples.Tanks;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class WaterObjectsManager : NetworkBehaviour
{ 
    [InspectorLabel("Changes the speed of the mobs how fast they appear and disapear (slowest)")]
    [SerializeField][Range(0f, 10f)]private float _changeSpeedMin;
    [InspectorLabel("Changes the speed of the mobs how fast they appear and disapear (fastest)")]
    [SerializeField][Range(0f, 20f)]private float _changeSpeedMax;
    [SerializeField] private int _numberOfLines;
    private List<Line> _lines = new List<Line>();
    private int AmountSpaces = 16;
    
    [Header("Objects, which should be placed on the Water")]
    [SerializeField] private List<GameObject> _stones;
    [SerializeField] private List<GameObject> _goodMobs;
    [SerializeField] private List<GameObject> _badMobs;

    private float lineLength;
    private float minGapSize;
    private float currentTime;

    private int lastTime = 0;


    private void Start()
    {
        BoxCollider boxCollider = this.GetComponent<BoxCollider>();
        Vector3 boxColPos = boxCollider.center + this.transform.position;
        float lineWidth = boxCollider.size.x;
        float lineHeight = boxCollider.size.z / _numberOfLines;
        currentTime = 0f;

        for (int i = 0; i < _numberOfLines; i++)
        {
            _lines.Add(new Line(lineWidth, boxColPos.z - (boxCollider.size.z / 2) + lineHeight * i + lineHeight / 2, AmountSpaces, boxColPos.x));
        }
    }

    private void Update()
    {

        if (!isServer) return;
        if (lastTime<(int)Time.timeSinceLevelLoad)
        {
            for(int i = 0; i < _lines.Count; i++)
            {
                UpdateLine(_lines[i]);
            }
            lastTime = (int)Time.timeSinceLevelLoad;
        }
    }

    [Server]
    public void UpdateLine(Line line)
    {

        GameObject go = GetRandomMob(line);
        float size = go.transform.localScale.x;
        float position = -(line.Width - (size / 2)) / 2 + (float)Random.value * (line.Width-(size/2));
        go.transform.position = new Vector3(position, 0, line.ZPos);
        NetworkServer.Spawn(go);
        float waitingTime = (float)Random.Range(_changeSpeedMin, _changeSpeedMax);

        bool isPositionClear = true;
        foreach (Mob mob in line.Objects)
        {
            if (Math.Abs(position - mob.transform.position.x) < mob.transform.localScale.x + minGapSize)
            {
                isPositionClear = false;
                break;
            }
        }

        if (isPositionClear)
        {
            go.GetComponent<Mob>().Waiting = (int)Math.Round(waitingTime);
            line.Objects.Add(go.GetComponent<Mob>());
        } else
        {
            Destroy(go);
            NetworkServer.Destroy(go);
        }
        

        for (int i = 0; i <= 0; i++)
        {
            line.Objects[i].CountDown();

            if (line.Objects[i].Waiting <= 0)
            {
                line.Objects[i].DiveDown();
                
                Destroy(line.Objects[i].gameObject);
                line.Objects.RemoveAt(i);
            }
        }
    }

    [Server]
    public GameObject GetRandomMob(Line line)
    {
        float moodDecider = Mathf.Round(Random.value);
        if (moodDecider == 0) 
        {
            float mobDecider = Mathf.Round(Random.Range(0, _badMobs.Count));
            GameObject go = Instantiate(_badMobs[(int)mobDecider], new Vector3(0, 0, line.ZPos), new Quaternion());
            return go;
        } else
        {
            float mobDecider = Mathf.Round(Random.Range(0, _goodMobs.Count));
            GameObject go = Instantiate(_goodMobs[(int)mobDecider], new Vector3(0, 0, line.ZPos), new Quaternion());
            return go;
        }
    }

    [Server]
    public void RemoveMob(Mob mob)
    {
        
        _lines[mob.Line].RemoveMob(mob);
        Destroy(mob.gameObject);
        NetworkServer.Destroy(mob.gameObject);
    }

    public void PlaceStones()
    {
    }
}
