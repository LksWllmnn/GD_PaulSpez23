using UnityEngine;

public class WaterPlant : Riddle
{
    public override event CallSolved CS;
    [SerializeField] Plant m_Plant;

    private void Start()
    {
        m_Plant.cW += Solved;
    }

    public override void Solved()
    {
        CS();
    }
}
