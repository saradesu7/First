using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Generate : MonoBehaviour, ICastleDestroy
{
    public float m_Score = 500;
   //Text score;
    [SerializeField] private GameObject Character;
    //[SerializeField] private GameObject Enemy1;
    [SerializeField] private Button button;

    private void Start()
    {
        CastleDestroy.Instance.iDestroySubscription.Add(this);
       // score = GetComponent<Text>();
        //Debug.Log(score);
    }

    private void OnDestroy()
    {
        CastleDestroy.Instance.iDestroySubscription.Remove(this);
    }

    public void OnChangeScore(int Score)
    {
        Debug.Log("Score>" + Score);
        m_Score = Score;
        button.interactable = true;
    }

    public void OnClickGenerateButton()
    {
        if (m_Score < 500)
        {
            button.interactable = false;
        }
        else if (m_Score >= 500)
        {
            button.interactable = true;
            Instantiate(Character, null);
            m_Score -= 500;
        }
    }

   public void FixedUpdate()
    {
       // score.text = "m_Score" + m_Score;
        //Invoke("CreateEnemy", 5.0f);
    }

    /*  public void CreateEmemy()
     {
         Instantiate(Enemy1, null);
     }*/
}
