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

    private Rigidbody physics;
    private int Lives = 3;
    private int WizLives = 3;


    public void Awake()
    {
        physics = gameObject.GetComponent<Rigidbody>();
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
            Lives = Lives - 1;
        }
        if (collision.gameObject.tag == "Feather")
        {
            Lives = Lives + 1;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Sword")
        {
            Wizzy.TakeDamage(20);
            Destroy(collision.gameObject);
        }
        
    }

    private void SwitchToNormalSprite()
    {
        CorgiSpriteRenderer.sprite = NormalSprite;
    }
}
