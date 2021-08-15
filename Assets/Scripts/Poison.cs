using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poison : MonoBehaviour
{
    public BoxCollider2D gridarea;
    public ScoreController scoreController;

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
        if (other.tag == "Player")
        {
            RandomizedPos();
        }
    }
    public void PickUpKey()
    {
        scoreController.IncreaseScore(-10);
    }
}

    //    public BoxCollider2D gridarea;

    //    private void Start()
    //    {
    //        Randomposfood();
    //    }
    //    private void Randomposfood()

    //    {
    //        Bounds bounds = this.gridarea.bounds;
    //        float x = Random.Range(bounds.min.x, bounds.max.x);
    //        float y = Random.Range(bounds.min.y, bounds.max.y);

    //        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

    //        x = Mathf.Round(x);
    //        y = Mathf.Round(y);

    //        this.transform.position = new Vector2(x, y);
    //    }

    //    private void OnTriggerEnter2D(Collider2D other)
    //    {
    //        if (other.tag == "Player")
    //        {
    //            PickUpKey();
    //            Randomposfood();
    //        }
    //    }


