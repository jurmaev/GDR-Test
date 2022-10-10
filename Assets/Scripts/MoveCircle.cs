using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCircle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private TextMeshProUGUI coinsText;
    private int coinsCount;
    private Vector3 target;
    private Vector3 currentTarget;
    private Queue<Vector3> positions;
    private bool gameOver;
    private bool isDead;

    public bool IsDead => isDead;

    public int CoinsCount => coinsCount;

    void Start()
    {
        positions = new Queue<Vector3>();
        target = transform.position;
        currentTarget = transform.position;
        coinsText.text = "Coins: " + coinsCount;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
            positions.Enqueue(target);
        }

        if (transform.position == currentTarget && positions.Count != 0)
            currentTarget = positions.Dequeue();

        transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Spike"))
        {
            isDead = true;
            gameObject.SetActive(false);
        }
        else if (col.gameObject.CompareTag("Coin"))
        {
            coinsCount++;
            coinsText.text = "Coins: " + coinsCount;
            col.gameObject.SetActive(false);
        }
    }

    public void GameOver()
    {
        gameOver = true;
    }
}