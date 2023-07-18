using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class LiftNumbers : Riddle
{
    public override event CallSolved CS;

    [SerializeField] List<int> m_CorrectNumbers;
    [SerializeField] TMPro.TextMeshPro m_TextMeshPro;
    
    List<int> m_Numbers = new List<int>(4);
    int pos = 0;
    bool _isCorrect = false;

    [SerializeField] List<LiftAudio> m_LiftNumbers = new List<LiftAudio>(4);
    float _timeBetweenAudios = 1.0f;

    private void Start()
    {
        for(int i = 0; i < m_LiftNumbers.Count;i++)
        {
            m_LiftNumbers[i].dP += PlayedAudio;
            m_LiftNumbers[i].Position = i;
            m_LiftNumbers[i].Count = m_CorrectNumbers[i];
        }

        StartPlayingAudio();
    }

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
        pos = 0;
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

    void StartPlayingAudio()
    {
        m_LiftNumbers[0].playAudio();
    }
    
    void PlayedAudio(int number)
    {
        StartCoroutine(Execute(number));
    }

    private IEnumerator Execute(int number)
    {
        switch (number)
        {
            case 0:
                m_LiftNumbers[number + 1].playAudio();
                yield return new WaitForSeconds(_timeBetweenAudios);
                break;
            case 1:
                m_LiftNumbers[number + 1].playAudio();
                yield return new WaitForSeconds(_timeBetweenAudios);
                break;
            case 2:
                m_LiftNumbers[number + 1].playAudio();
                yield return new WaitForSeconds(_timeBetweenAudios);
                break;
            case 3:
                m_LiftNumbers[0].playAudio();
                yield return new WaitForSeconds(_timeBetweenAudios);
                break;
        }
    }
}
