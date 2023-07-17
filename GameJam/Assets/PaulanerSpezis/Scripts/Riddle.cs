using UnityEngine;

public abstract class Riddle: MonoBehaviour
{
    public delegate void CallSolved();
    public abstract event CallSolved CS;
    public abstract void Solved();
}
