using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICastleDestroy
{
    void OnChangeScore(int Score);
}
public class CastleDestroy : MonoBehaviour
{

    public static CastleDestroy Instance;
    [SerializeField] private Sprite First;
    [SerializeField] private Sprite Second;
    private int Counter = 1;

    public List<ICastleDestroy> iDestroySubscription = new List<ICastleDestroy>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        Counter++;
        if (Counter == 3)
        {
            this.GetComponent<SpriteRenderer>().sprite = First;
        }
        else if (Counter == 6)
        {
            this.GetComponent<SpriteRenderer>().sprite = Second;
        }
        else if (Counter >= 10)
        {
            iDestroySubscription.ForEach(x => x.OnChangeScore(1000));
            Debug.Log("DestryCastle");
            gameObject.SetActive(false);
        }
    }
}
