using System;

public class Gamecharacter
{
	public string Name { get; set; }
	public int Health { get; set; }
	public int Stamina { get; set; }
	public int Strength { get; set; }
	public bool IsRecharging { get; set; }
	public bool NotDead { get; set; }
	private bool HasRecharged { get; set; }
	private int originalStrength;
	private static Random rand = new Random();
    public Gamecharacter(string name, int health, int stamina, int? strength = null) 
	{
		Name = name;
		Health = health;
		Stamina = stamina;
		if (strength.HasValue)
		{
			Strength = strength.Value;
		}
		else
		{
			Strength = rand.Next(1, 31);
		}
        originalStrength = Strength;
    }
	public void PrintCharacter()
	{
		Console.WriteLine($"Name: {Name}, Health: {Health}, Stamina: {Stamina}, Strength: {Strength}"); 
	}
	public void Recharge()
	{
		if (Stamina == 0 || !HasRecharged)
		{
			IsRecharging = true;
            Strength = 0;
            Stamina += 10;
			HasRecharged = true;
		}
	}
	public void EndRecharge()
	{
		IsRecharging = false;
        Strength = originalStrength;
		HasRecharged = false;
    }

}
