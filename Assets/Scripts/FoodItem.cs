using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public BoxCollider2D gridarea;
    public ScoreController sc1;
    public ScoreController sc2;
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
            if (other.tag == "Player1")
            {
            FoodPickedS1();
            Randomposfood();
            }
            else if(other.tag == "Player2")
            {
            FoodPickedS2();
            Randomposfood();
            }
        }
    public void FoodPickedS1()
    {
        sc1.IncreaseScore(10);
    }
    public void FoodPickedS2()
    {
        sc2.IncreaseScore(10);
    }
}
