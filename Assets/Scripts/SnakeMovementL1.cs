using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider2D))]
public class SnakeMovementL1 : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<Transform> _segments = new List<Transform>();
    private float maxX, maxY, minX, minY;
    public Transform tails;
    public int initialsize = 4;
    public BoxCollider2D gridArea;
    public GameObject gameOver;

    private void Start()
    {
        ResetState();
        Bounds bounds = this.gridArea.bounds;
        maxX = bounds.max.x;
        maxY = bounds.max.y;
        minX = bounds.min.x;
        minY = bounds.min.y;
    }

    void Update()
    {
        if (this.direction.x != 0f)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                this.direction = Vector2.up;
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                this.direction = Vector2.down;
            }
        }
        // Only allow turning left or right while moving in the y-axis
        else if (this.direction.y != 0f)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                this.direction = Vector2.right;
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                this.direction = Vector2.left;
            }
        }

    }
    void ScreenWrap()
    {
        Vector3 newPosition = transform.position;

        if (newPosition.x > maxX)
        {
            newPosition.x = -newPosition.x + 1f;
        }
        else if (newPosition.x <= minX)
        {
            newPosition.x = -newPosition.x - 1f;
        }

        if (newPosition.y >= maxY)
        {
            newPosition.y = -newPosition.y + 1f;
        }
        else if (newPosition.y <= minY)
        {
            newPosition.y = -newPosition.y - 1f;
        }
        transform.position = newPosition;
    }
    private void FixedUpdate()
    {
        ScreenWrap();
        for (int i = _segments.Count - 1; i > 0; i--)
        {
            _segments[i].position = _segments[i - 1].position;
        }

        float x = Mathf.Round(this.transform.position.x) + this.direction.x;
        float y = Mathf.Round(this.transform.position.y) + this.direction.y;

        this.transform.position = new Vector2(x, y);
    }
    private void Grow()
    {
        Transform segment = Instantiate(this.tails);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);
    }
    void Reduce()
    {
        Transform segment = _segments[_segments.Count - 1].transform;
        _segments.Remove(segment);
        Destroy(segment.gameObject);
    }
    private void ResetState()
    {
        this.direction = Vector2.right;
        this.transform.position = Vector3.zero;

        for (int i = 1; 1 < _segments.Count; i++)
        {
            Destroy(_segments[i].gameObject);
        }

        _segments.Clear();
        this.transform.position = Vector3.zero;
        _segments.Add(this.transform);

        for (int i = 1; i < this.initialsize; i++)
        {
            _segments.Add(Instantiate(this.tails));
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            Grow();
        }
        else if (other.tag == "Poison")
        {
            Reduce();
        }
        else if (other.tag == "Tail")
        {
            GameOver();
        }
    }
    public void resetScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }
    public void resetScene2()      // for co-op mode....
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(2);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        gameOver.SetActive(true);
    }
}

