using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDamary.OOP_Class_
{
    public class Vector
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public void UpdateVector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public class X
    {
        public int hp { get; private set; }
        public int damage { get; private set; }

        public X(int hp, int damage)
        {
            this.hp = hp;
            this.damage = damage;   
        }

        public void TakeDamage(int dagame)
        {
            hp -= dagame;
        }
    }

    public class Charactor
    {
        public Vector _position { get; private set; }
        public int _hp { get; private set; }
        public int _mp { get; private set; }
        public int _level { get; private set; }
        public int _power { get; private set; }

        public Charactor(Vector position, int hp, int mp, int level, int power)
        {
            _position = position;
            _hp = hp;
            _mp = mp;
            _level = level;
            _power = power;
        }


        public void Jump()
        {
            if (_position != null)
            {
                _position.UpdateVector(_position.X, _position.Y + 10);
            }
        }

        public void Attack(X target)
        {
            if (target != null && _mp > 0)
            {
                target.TakeDamage(_power);
                _mp -= 2;
            }
        }

        public void GetHit(int dagame)
        {
            if (_hp > 0)
            {
                _hp -= dagame;
                if (_hp < 0)
                {
                    _hp = 0;
                }
            }             
        }

        public void LevelUp(int hp,int mp,int power)
        {
            _level += 1;
            _hp += hp;
            _mp += mp;
            _power += power;
        }
    }
}



