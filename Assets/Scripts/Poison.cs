using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public BoxCollider2D gridarea;
    public ScoreController sc1;
    public ScoreController sc2;

    private void Start()
    {
        StartCoroutine(chnagePos());
    }

    public void RandomizedPos()
    {
        Bounds bounds = this.gridarea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);
    }

    IEnumerator chnagePos()
    {
        RandomizedPos();
        yield return new WaitForSeconds(5f);

        StartCoroutine(chnagePos());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1")
        {
            DeductScore1();
            RandomizedPos();
        }
        if (other.tag == "Player2")
        {
            DeductScore2();
            RandomizedPos();
        }
    }
    public void DeductScore1()
    {
        sc1.IncreaseScore(-10);
    }
    public void DeductScore2()
    {
        sc2.IncreaseScore(-10);
    }
}

    
