using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LittleFIghter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weapon Sword = new Weapon();
            Sword.attack = 10;
            Sword.DefenseLow = 10;

            Weapon Magic = new Weapon();
            Magic.attack = 5;
            Magic.DefenseLow = 50;

            Enemy Ghost = new Enemy();
            int eDefense = Ghost.Defense = 80;
            int eHealth = Ghost.Health = 30;
            int eAttack = Ghost.Attack = 7;

            Enemy Bones = new Enemy();
            Bones.Defense = 600;
            Bones.Health = 15;
            Bones.Attack = 15;

            int health = 200;
            int defense = 40;

            bool gameIsOn = true;

            int attackButton;
            int enemyCount = 0;

            Random random = new Random();

            while (gameIsOn)
            {
                Console.WriteLine($"Player's Health: {health}");
                Console.WriteLine($"Количество побежденных врагов: {enemyCount}");
                Console.WriteLine($"Enemy's Health: {eHealth}");

                Console.WriteLine("Для атаки магией введите 1, Для атаки мечом введите 2");

                attackButton = Convert.ToInt32(Console.ReadLine());

                switch (attackButton)
                {
                    case 1:
                        eHealth = eHealth - Magic.attack * (eDefense - Magic.DefenseLow) / 100;
                        break;
                    case 2:
                        eHealth = eHealth - Sword.attack * (eDefense - Sword.DefenseLow) / 100;
                        break;
                    default:
                        Console.WriteLine("Неправильный ввод");
                        Console.ReadKey();
                        break;
                }

                int b = random.Next(1, 3);

                if (eHealth <= 0)
                {
                    switch (b)
                    {
                        case 1:
                            eDefense = Ghost.Defense;
                            eHealth = Ghost.Health;
                            eAttack = Ghost.Attack;
                            break;
                        case 2:
                            eDefense = Bones.Defense;
                            eHealth = Bones.Health;
                            eAttack = Bones.Attack;
                            break;
                    }
                    enemyCount++;



                }
                else
                {
                    health = health - Ghost.Attack * defense / 100;
                }

                Console.Clear();
            }
        }
    }

    public class Weapon
    {
        public int attack;
        public int DefenseLow;
    }

    public class Enemy
    {
        public int Health;
        public int Defense;
        public int Attack;
    }
}
