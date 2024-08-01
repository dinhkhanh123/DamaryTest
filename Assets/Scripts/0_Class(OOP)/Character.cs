using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public Vector2 _position{ get; private set; }
    public int _hp { get; private set; }
    public int _mp { get; private set; }
    public int _level { get; private set; }
    public int _power { get; private set; }

    public Character(Vector2 position, int hp, int mp, int power)
    {
        _position = position;
        _hp = hp;
        _mp = mp;
        _power = power;
        _level = 1;
    }

    public void Jump(Vector2 jumpVector)
    {
        _position += jumpVector;
    }

    public void Attack(Character x)
    {
        if (x == null)
        {
            return;
        }

        x.GetHit(_power);

        _mp -= 2;
        if (_mp < 0) _mp = 0;

    }

    public void GetHit(int damage)
    {
        _hp -= damage;
        if (_hp < 0)
        {
            _hp = 0;
        }
    }

    public void LevelUp()
    {
        _level++;
        _hp += 20;
        _mp += 10;
        _power += 5;
    }
}
