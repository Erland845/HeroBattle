namespace HeroBattle
{
    internal class Program
    {
        private static Random rand = new Random();
        static void Main(string[] args)
        {
            Gamecharacter Boss = new Gamecharacter("Boss", 400, 10);
            Gamecharacter Hero = new Gamecharacter("Hero", 100, 40, 20);
            Boss.PrintCharacter();
            Hero.PrintCharacter();

            bool haveHealth = false;

            if (Boss.Health > 0 || Hero.Health > 0) 
            {
                haveHealth = true;


                while (haveHealth)
                {
                    if (Hero.Stamina == 0)
                    {
                        Hero.Recharge();
                        Console.WriteLine("Hero is recharging");
                    }
                    if (Boss.Stamina == 0)
                    {
                        Boss.Recharge();
                        Console.WriteLine("Boss is recharging");
                    }
                    Fight(Boss, Hero);

                    Boss.PrintCharacter();
                    Hero.PrintCharacter();

                    if (Hero.Stamina > 0)
                    {
                        Hero.EndRecharge();
                    }
                    if (Boss.Stamina > 0)
                    {
                        Boss.EndRecharge();
                    }

                    if (Boss.Health < 1 || Hero.Health < 1)
                    {
                        haveHealth = false;
                        Console.WriteLine("\nWar is over");
                        PrintSurvivor(Boss, Hero);
                    }

                }

            }

        }
        static void Fight(Gamecharacter Boss, Gamecharacter Hero)
        {
            var randomfighter = rand.Next(1, 3);
            if (randomfighter == 1)
            {
                Console.WriteLine("Boss attacks Hero");
                Hero.Health -= Boss.Strength;
                Boss.Stamina -= 10;
            }
            else if (randomfighter == 2)
            {
                Console.WriteLine("Hero attacks boss");
                Boss.Health -= Hero.Strength;
                Hero.Stamina -= 10;
            }
        }
        static void PrintSurvivor(Gamecharacter boss, Gamecharacter hero)
        {
            if (boss.Health > 0)
            {
                Console.WriteLine("The Boss has defeated the hero and won the battle");
                boss.PrintCharacter();
            }
            else if (hero.Health > 0)
            {
                Console.WriteLine("The Hero has defeated the boss and won the battle");
                hero.PrintCharacter();
            }
        }

    }
}

