using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corgi : MonoBehaviour
{
    public SpriteRenderer CorgiSpriteRenderer;
    public SpriteTools SpriteTools;
    public Sprite NormalSprite;
    public Sprite DrunkenSprite;
    public Text ScoreText;

    private bool isDrunk = false;
    private bool isPlastered = false;
    private int randomMoveCount = GameParameters.TimesToMoveInSameRandomDirection;
    private int lastRandomDirection = 0;
    private int score = 0;

    public void Start()
    {
        ScoreText.text = "0";
    }

    public void Update()
    {
        if (isPlastered)
            MoveRandomly();
    }

    public void Move(Vector2 direction)
    {
        Vector2 amountToMove = CalculateAmountToMove(direction);
        FaceCorrectDirection(amountToMove.x);
        CorgiSpriteRenderer.transform.Translate(amountToMove);
        KeepOnScreen();
    }

    public void MoveWithKeyboard(Vector2 direction)
    {
        if (IsOkToMove())
        {
            Move(direction);
        }
    }

    private bool IsOkToMove()
    {
        if (isPlastered)
            return false;
        return true;
    }

    private void MoveRandomly()
    {
        if (randomMoveCount == 0)
        {
            randomMoveCount = GameParameters.TimesToMoveInSameRandomDirection;
            lastRandomDirection = Random.Range(0, 4);
        }
            
        switch (lastRandomDirection)
        {
            case 0:
                Move(new Vector2(1, 0));
                break;
            case 1:
                Move(new Vector2(-1, 0));
                break;
            case 2:
                Move(new Vector2(0, 1));
                break;
            case 3:
                Move(new Vector2(0, -1));
                break;
        }
        randomMoveCount = randomMoveCount - 1;
    }

    private void FaceCorrectDirection(float directionX)
    {
        if (directionX > 0)
            CorgiSpriteRenderer.flipX = false;
        else if (directionX <0)
            CorgiSpriteRenderer.flipX = true;
    }

    private void KeepOnScreen()
    {
        CorgiSpriteRenderer.transform.position = SpriteTools.ConstrainToScreen(CorgiSpriteRenderer);
    }

    private Vector2 CalculateAmountToMove(Vector2 direction)
    {
        float amountX = GameParameters.CorgiMoveDistance * direction.x;
        float amountY = GameParameters.CorgiMoveDistance * direction.y;

        return ApplyDrunkenness(new Vector2(amountX, amountY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Beer")
        {
            getDrunk();
        }
        if (collision.gameObject.tag == "Bone")
        {
            score += 1;
            ScoreText.text = score.ToString();
        }
        if (collision.gameObject.tag == "Moonshine")
        {
            getPlastered();
            
        }
        if (collision.gameObject.tag == "Pill")
        {
            SoberUp();
        }
        Destroy(collision.gameObject);
    }

    private void getPlastered()
    {
        isPlastered = true;
        Inebriate();
    }
    
    private void getDrunk()
    {
        isDrunk = true;
        Inebriate();
    }

    private void Inebriate()
    {
        SwitchToDrunkenSprite();
        StartCoroutine(WaitToSoberUp());
    }

    private Vector2 ApplyDrunkenness(Vector2 amountToMove)
    {
        if (isDrunk)
        {
            amountToMove.x = amountToMove.x * -1 * GameParameters.DrunkenMovementMultiplier;
            amountToMove.y = amountToMove.y * -1 * GameParameters.DrunkenMovementMultiplier;
        }
        return amountToMove;
    }

    IEnumerator WaitToSoberUp()
    {
        yield return new WaitForSeconds(GameParameters.SecondsToSoberUp);
        SoberUp();
    }

    private void SoberUp()
    {
        isDrunk = false;
        isPlastered = false;
        SwitchToNormalSprite();
    }

    private void SwitchToDrunkenSprite()
    {
        CorgiSpriteRenderer.sprite = DrunkenSprite;
    }
    private void SwitchToNormalSprite()
    {
        CorgiSpriteRenderer.sprite = NormalSprite;
    }
}
