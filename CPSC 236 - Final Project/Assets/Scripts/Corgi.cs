using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public SpriteTools SpriteTools;
    public Sprite NormalSprite;
    public Wizzy Wizzy;

    public GameObject FloatingScorePrefab;
    public CorgiHealthBar healthBar;

    public int maxHealth = 100;
    public int currentHealth;

    private Rigidbody physics;
    private int Lives = 4;
    private float flashTime = .1f;

    public void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>(); 
    }

    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void Move(Vector2 direction)
    {
        Vector2 amountToMove = CalculateAmountToMove(direction);
        FaceCorrectDirection(amountToMove.x);
        CorgiSpriteRenderer.transform.Translate(amountToMove);
    }

    public void MoveWithKeyboard(Vector2 direction)
    {
        physics.velocity = Vector3.zero;
        physics.angularVelocity = Vector3.zero;
        Move(direction);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }

    public int GetHealth()
    {
        return Lives;
    }

    public void SetHealth(int health)
    {
        Lives = health;
    }

    public void Reset()
    {
        gameObject.SetActive(true);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Instantiate(FloatingScorePrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), Quaternion.identity);
        healthBar.SetHealth(currentHealth);
    }

    private void FaceCorrectDirection(float directionX)
    {
        if (directionX > 0)
            CorgiSpriteRenderer.flipX = false;
        else if (directionX <0)
            CorgiSpriteRenderer.flipX = true;
    }

    private Vector2 CalculateAmountToMove(Vector2 direction)
    {
        float amountX = GameParameters.CorgiMoveDistance * direction.x;
        float amountY = GameParameters.CorgiMoveDistance * direction.y;

        return new Vector2(amountX, amountY);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bomb")
        {
            TakeDamage(20);
            StartCoroutine(StartFlashing());
            Game.Instance.CheckGameOverAfterCollision();
        }
        if (collision.gameObject.tag == "Feather")
        {
            Destroy(collision.gameObject);
            StartCoroutine(SpeedUp());
            Game.Instance.CollectFeather();
        }
        if (collision.gameObject.tag == "Sword")
        {
            Wizzy.TakeDamage(20);
            Destroy(collision.gameObject);
            Game.Instance.CheckGameOverAfterCollision();
        }
        if (collision.gameObject.tag == "Poop")
        {
            TakeDamage(10);
            Game.Instance.DamageEffect(collision.gameObject);
            Destroy(collision.gameObject);
            Game.Instance.HitPoop(Lives);
            StartCoroutine(StartFlashing());
            Game.Instance.CheckGameOverAfterCollision();
        }
    }

    IEnumerator StartFlashing()
    {
        //CorgiCollider.isTrigger = true;
        for (int i = 0; i < 2; i++)
        {
            CorgiSpriteRenderer.enabled = false;
            yield return new WaitForSeconds(flashTime);
            CorgiSpriteRenderer.enabled = true;
            yield return new WaitForSeconds(flashTime);
        }
        //CorgiCollider.isTrigger = false;
    }

    IEnumerator SpeedUp()
    {
           GameParameters.CorgiMoveDistance = 0.3f;
           yield return new WaitForSeconds(10);
           GameParameters.CorgiMoveDistance = 0.1f;
    }

    private void SwitchToNormalSprite()
    {
        CorgiSpriteRenderer.sprite = NormalSprite;
    }
}
