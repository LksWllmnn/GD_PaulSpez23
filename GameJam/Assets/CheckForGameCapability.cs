using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckForGameCapability : MonoBehaviour
{
    [SerializeField] StoryGimics m_StroyGimics;
    [SerializeField] GameObject CubeRiddle;
    [SerializeField] TextMeshPro m_ScreenText;
    bool _isSolved = false;
    bool _pizza = false;
    bool _energy = false;
    bool _radish = false;

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
                CubeRiddle.SetActive(true);
                m_ScreenText.text = "Uh, nice one!";
            } else if (!_energy || !_pizza)
            {
                m_ScreenText.text = "sth is missing!";
            }
            else if (_radish)
            {
                m_ScreenText.text = "take...it...out!";
            }

            /*if (other.name == "XR Origin")
            {
                if (m_StroyGimics.GrabbedEnergy && m_StroyGimics.GrabbedPizza)
                {
                    CubeRiddle.SetActive(true);
                    m_ScreenText.text = "Uh, nice one!";
                }
                else if (m_StroyGimics.GrabbedRadish)
                {
                    m_ScreenText.text = "ugh.. Radish!! Fuck of you chicken shit!!";
                }
                else if (!m_StroyGimics.GrabbedRadish&& !m_StroyGimics.GrabbedEnergy&& !m_StroyGimics.GrabbedPizza)
                {
                    m_ScreenText.text = "Hi...Bring me sth that proofs you are a true Gamer dude!";
                } else
                {
                    m_ScreenText.text = "Nice try, but not quiet there yet...";
                }
            }
            else if (other.name == "Pizza_Slice")
            {
                m_ScreenText.text = "What is that? ...Hmm Pizza";
            }
            else if (other.name == "MofsterEnergy")
            {
                m_ScreenText.text = "What is that? ...Hmm Energy...nice";
            }
            else if (other.name == "Radish")
            {
                m_ScreenText.text = "ugh...Radish";
            }*/
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
