using System.Collections;
using TMPro;
using UnityEngine;

public class CheckForGameCapability : Riddle
{
    [SerializeField] StoryGimics m_StroyGimics;
    [SerializeField] TextMeshPro m_ScreenText;
    [SerializeField] AudioSource m_AudioSource;
    bool _isSolved = false;
    bool _pizza = false;
    bool _energy = false;
    bool _radish = false;

    public override event CallSolved CS;

    private void Start()
    {
        StartCoroutine(MachineMonologue());
    }

    public override void Solved()
    {
        CS();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(!_isSolved)
        {
            if(CheckIfCorrect(other.name))
            {
                m_ScreenText.text = "1/2";
                if(other.name == "Pizza_Slice") _pizza=true;
                if (other.name == "MofsterEnergy") _energy = true;
                //play Audio
            }

            if(other.name == "Radish")
            {
                Debug.Log("ugh, radish!");
            }

            if(_energy && _pizza && !_radish)
            {
                m_ScreenText.text = "2/2";
                Solved();
            }
        }
    }

    public bool CheckIfCorrect(string name)
    {
        switch (name)
        {
            case "Pizza_Slice": return true;
            case "MofsterEnergy": return true;
            default: return false;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!_isSolved)
        {
            if (other.name == "Complete XR Origin Set Up")
            {
                m_ScreenText.text = "Proof to me that you are a real Gamer!";
            }
        }
    }

    protected IEnumerator MachineMonologue()
    {
        yield return new WaitForSeconds(1f);
        m_AudioSource.Play();
    }
}
