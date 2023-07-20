using TMPro;
using UnityEngine;

public class CheckForGameCapability : Riddle
{
    [SerializeField] StoryGimics m_StroyGimics;
    [SerializeField] TextMeshPro m_ScreenText;
    string _lastEntered;
    string _progress;
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
            if(other.name == "Pizza_Slice")
            {
                _pizza = true;
                m_ScreenText.text = "What is that? ...Hmm Pizza";
            } else if(other.name == "Radish")
            {
                _radish = true;
                m_ScreenText.text = "ugh.. Radish!! Fuck of you chicken shit!! Take it out!";
            } else if(other.name == "MofsterEnergy")
            {
                _energy = true;
                m_ScreenText.text = "What is that? ...Hmm Energy...nice";
            }

            if(_energy && _pizza && !_radish)
            {
                m_ScreenText.text = "Uh, nice one!";
                Solved();
            } else if (!_energy || !_pizza)
            {
                m_ScreenText.text = "sth is missing!";
            }
            else if (_radish)
            {
                m_ScreenText.text = "take...it...out!";
            }
            m_ScreenText.text = _lastEntered + "" + _progress;
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
