using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftNumbers : Riddle
{
    public override event CallSolved CS;

    [SerializeField] AudioSource m_AudioSourceSolved;
    [SerializeField] AudioSource m_AudioMonologue;

    [SerializeField] List<int> m_CorrectNumbers;
    [SerializeField] TMPro.TextMeshPro m_TextMeshPro;
    
    List<int> m_Numbers = new List<int>(4);
    int pos = 0;
    bool _isCorrect = false;

    [SerializeField] List<LiftAudio> m_LiftNumbers = new List<LiftAudio>(4);
    float _timeBetweenAudios = 1.0f;
    float _timeBetweenSequenzes = 2.0f;
    float _timeToStartAfterMonologue;

    private void Start()
    {
        for(int i = 0; i < m_LiftNumbers.Count;i++)
        {
            m_LiftNumbers[i].dP += PlayedAudio;
            m_LiftNumbers[i].Position = i;
            m_LiftNumbers[i].Count = m_CorrectNumbers[i];
        }
        _timeToStartAfterMonologue = m_AudioMonologue.clip.length + 1f;
        StartCoroutine(TaskMonologue());
        StartCoroutine(StartTask());
    }

    public override void Solved()
    {
        CS();
        m_AudioSourceSolved.Play();

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
                yield return new WaitForSeconds(_timeBetweenAudios);
                m_LiftNumbers[number + 1].playAudio();
                
                break;
            case 1:
                yield return new WaitForSeconds(_timeBetweenAudios);
                m_LiftNumbers[number + 1].playAudio();
                
                break;
            case 2:
                yield return new WaitForSeconds(_timeBetweenAudios);
                m_LiftNumbers[number + 1].playAudio();
                
                break;
            case 3:
                yield return new WaitForSeconds(_timeBetweenSequenzes);
                m_LiftNumbers[0].playAudio();
                
                break;
        }
    }

    private IEnumerator TaskMonologue()
    {
        yield return new WaitForSeconds(1f);
        m_AudioMonologue.Play();
    }

    private IEnumerator StartTask()
    {
        yield return new WaitForSeconds(_timeToStartAfterMonologue+1);
        StartPlayingAudio();
    }
}
