using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpEnemy : MonoBehaviour
{
    public Swordsman sm;
    [SerializeField] private Sprite first;
    [SerializeField] private Sprite second;
    [SerializeField] private Sprite third;
    [SerializeField] private Sprite fourth;
    [SerializeField] private Sprite fifth;
    private void Update()
    {
        if (sm.count == 1)
            this.GetComponent<SpriteRenderer>().sprite = first;
        if (sm.count == 3)
            this.GetComponent<SpriteRenderer>().sprite = second;
        if (sm.count == 5)
            this.GetComponent<SpriteRenderer>().sprite = third;
        if (sm.count == 7)
            this.GetComponent<SpriteRenderer>().sprite = fourth;
        if (sm.count == 10)
            this.GetComponent<SpriteRenderer>().sprite = fifth;
    }
}
