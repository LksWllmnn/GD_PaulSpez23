using UnityEngine;

public delegate void CallSolved();

public abstract class Riddle: MonoBehaviour
{
    public abstract event CallSolved CS;
    public abstract void Solved();
}
