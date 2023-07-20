using TMPro;
using UnityEngine;

public class CheckForGameCapability : Riddle
{
    [SerializeField] StoryGimics m_StroyGimics;
    [SerializeField] TextMeshPro m_ScreenText;
    bool _isSolved = false;
    bool _pizza = false;
    bool _energy = false;
    bool _radish = false;

    public override event CallSolved CS;

    public override void Solved()
    {
        CS();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!_isSolved)
        {
            if(CheckIfCorrect(other.name))
            {
                m_ScreenText.text = "1/2";
                //play Audio
            }

            if(other.name == "Radish")

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
}
