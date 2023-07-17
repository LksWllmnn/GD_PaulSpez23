using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftNumbers : Riddle
{
    public override event CallSolved CS;

    [SerializeField] List<int> m_CorrectNumbers;
    [SerializeField] TMPro.TextMeshPro m_TextMeshPro;
    
    List<int> m_Numbers = new List<int>(4);
    int pos = 0;
    bool _isCorrect = false;

    public override void Solved()
    {
        CS();
    }

    public void AddNumber(int number)
    {
        Debug.Log(m_Numbers.Count);
        if(pos < 4)
        {
            m_Numbers.Add(number);
            pos++;
            m_TextMeshPro.text = "";
            for(int i = 0; i < 4; i++)
            {
                if(i < pos) m_TextMeshPro.text += m_Numbers[i];
                else m_TextMeshPro.text += "0";
            }
            if(pos == 4)
            {
                CheckNumbers();
            }
        } else
        {
            CheckNumbers();
        }
    }

    public void RemoveAllNumbers()
    {
        m_TextMeshPro.text = "0000"; 
        m_Numbers.Clear();
    }

    public void CheckNumbers()
    {
        for(int i = 0;  i < m_Numbers.Count; i++)
        {
            if (m_Numbers[i] != m_CorrectNumbers[i]) { _isCorrect = false; break; }
            _isCorrect = true;
        }
        if(_isCorrect)
        {
            Solved();
        } else
        {
            RemoveAllNumbers();
        }
    }
}
