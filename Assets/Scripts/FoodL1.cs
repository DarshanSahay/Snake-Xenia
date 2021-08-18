using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodL1 : MonoBehaviour
{

    public BoxCollider2D gridarea;
    public ScoreController sc1;
    private void Start()
    {
        Randomposfood();
    }
    private void Randomposfood()

    {
        Bounds bounds = this.gridarea.bounds;
        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0.0f);

        x = Mathf.Round(x);
        y = Mathf.Round(y);

        this.transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FoodPickedS1();
            Randomposfood();
        }
    }
    public void FoodPickedS1()
    {
        sc1.IncreaseScore(10);
    }
}
