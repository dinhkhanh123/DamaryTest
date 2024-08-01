using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Character character;
    [SerializeField] private Vector2 startPosition;
    [SerializeField] private int hp;
    [SerializeField] private int mp;
    [SerializeField] private int power;
    private Character enemyX;

    [SerializeField] TextMeshProUGUI textHp;
    [SerializeField] TextMeshProUGUI textMp;
    [SerializeField] TextMeshProUGUI textLv;
    [SerializeField] TextMeshProUGUI textPower;

    bool isGround;

    private void Start()
    {
        character = new Character(startPosition, hp, mp, power);
        enemyX = new Character(new Vector2(0, 5f), 50, 30, 5);

        transform.position = startPosition;
        UpdateStat();

       
    }


    private void UpdateStat()
    {
        textLv.text = $"Level: {character._level}";
        textHp.text = $"HP: {character._hp}";
        textMp.text = $"MP: {character._mp}";
        textPower.text = $"Power: {character._power}";
    }
    public void Jump()
    {
        Vector2 jumpVector = new Vector2(0, 5); 
        character.Jump(jumpVector);
    }
    public void Attack()
    {
        character.Attack(enemyX);
        UpdateStat();
    }

    public void GetHit()
    {
        character.GetHit(enemyX._power);
        UpdateStat();
    }
    public void LevelUp()
    {
        character.LevelUp();
        UpdateStat();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGround = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
    }
}
