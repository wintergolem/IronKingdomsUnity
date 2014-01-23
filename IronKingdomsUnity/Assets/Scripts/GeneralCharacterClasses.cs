using UnityEngine;
using System.Collections;
enum Level {Hero, Veteran, Epic};
class Stat
{
	Level level;
	int value;
	int heroMax;
	int vetMax;
	int epicMax;
	public void Set(int a_value, int a_hero, int a_vet, int a_epic, Level a_level)
	{
		value = a_value;
		heroMax = a_hero;
		vetMax = a_vet;
		epicMax = a_epic;
	}
	bool Increase(int amount)
	{
		if(value + amount > heroMax)
		{
			return false;
		}
		value += amount;
		return true;
	}
	bool Increase()
	{
		int amount = 1;
		if(value + amount > heroMax)
		{
			return false;
		}
		value += amount;
		return true;
	}
	public static int operator + (Stat s, Stat a)
	{
		int re = s.value + a.value;
		return re;
	}
	public static int operator + (Stat s, int a)
	{
		int re = s.value + a;
		return re;
	}
	public static int operator + (int s, Stat a)
	{
		int re = s + a.value;
		return re;
	}
	public static bool operator >= (float f, Stat s)
	{
		return f >= s.value;
	}
	public static bool operator <= (float f, Stat s)
	{
		return f <= s.value;
	}
}

class Stats
{
	public Stat PHY,SPD,STR,AGL,PRW,POI,INT,ARC,PER;

	int DEF(int Equip, int other)
	{
		int def = SPD + AGL + PER + Equip + other;
		return def;
	}
	int ARM(int shield, int other)
	{
		int arm = PHY + shield + other;
		return arm;
	}
	int INIT(int Equip, int Additional)
	{
		int init = SPD + PRW + PER + Equip + Additional;
		return init;
	}
	int COM(int command, int ability)
	{
		int com = INT + command + ability;
		return com;
	}
	public void Init()
	{
		PHY = new Stat();
		SPD = new Stat();
		STR = new Stat();
		AGL = new Stat();
		PRW = new Stat();
		POI = new Stat();
		INT = new Stat();
		ARC = new Stat();
		PER = new Stat();
	}
	public void Human()
	{
		PHY.Set (5,7,8,8, Level.Hero);
		SPD.Set (6,7,7,7, Level.Hero);
		STR.Set (4,7,7,8, Level.Hero);
		AGL.Set	(3,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (4,5,6,7, Level.Hero);
		INT.Set (3,5,6,7, Level.Hero);
		ARC.Set (0,4,6,8, Level.Hero);
		PER.Set (3,5,6,7, Level.Hero);
	}
	void Dwarf()
	{
		PHY.Set (6,7,7,8, Level.Hero);
		SPD.Set (4,5,6,6, Level.Hero);
		STR.Set (5,6,7,8, Level.Hero);
		AGL.Set	(3,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (3,4,5,6, Level.Hero);
		INT.Set (4,5,6,7, Level.Hero);
		ARC.Set (0,4,6,7, Level.Hero);
		PER.Set (3,4,6,7, Level.Hero);
	}
	void Gobber()
	{
		PHY.Set (4,6,7,7, Level.Hero);
		SPD.Set (6,7,7,7, Level.Hero);
		STR.Set (3,4,5,6, Level.Hero);
		AGL.Set	(4,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (3,4,5,6, Level.Hero);
		INT.Set (3,4,5,6, Level.Hero);
		ARC.Set (0,0,0,0, Level.Hero);
		PER.Set (3,4,4,5, Level.Hero);
	}
	void Iosan()
	{
		PHY.Set (5,7,7,7, Level.Hero);
		SPD.Set (6,7,7,7, Level.Hero);
		STR.Set (4,5,6,7, Level.Hero);
		AGL.Set	(3,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (4,5,6,7, Level.Hero);
		INT.Set (4,6,6,7, Level.Hero);
		ARC.Set (0,4,6,8, Level.Hero);
		PER.Set (3,5,6,7, Level.Hero);
	}
	void Nyss()
	{
		PHY.Set (5,7,7,8, Level.Hero);
		SPD.Set (6,7,7,7, Level.Hero);
		STR.Set (4,6,7,8, Level.Hero);
		AGL.Set	(4,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (4,5,6,7, Level.Hero);
		INT.Set (3,5,6,6, Level.Hero);
		ARC.Set (0,4,6,7, Level.Hero);
		PER.Set (3,5,6,6, Level.Hero);
	}
	void Ogrun()
	{
		PHY.Set (6,7,8,9, Level.Hero);
		SPD.Set (5,6,6,6, Level.Hero);
		STR.Set (6,8,9,10, Level.Hero);
		AGL.Set	(3,5,5,6, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (3,4,5,6, Level.Hero);
		INT.Set (3,4,5,6, Level.Hero);
		ARC.Set (0,0,0,0, Level.Hero);
		PER.Set (2,4,5,6, Level.Hero);
	}
	void Trollkin()
	{
		PHY.Set (6,8,9,10, Level.Hero);
		SPD.Set (5,6,6,6, Level.Hero);
		STR.Set (5,7,8,9, Level.Hero);
		AGL.Set	(3,5,6,7, Level.Hero);
		PRW.Set (4,5,6,7, Level.Hero);
		POI.Set (2,4,5,6, Level.Hero);
		INT.Set (3,4,5,6, Level.Hero);
		ARC.Set (0,4,6,7, Level.Hero);
		PER.Set (3,4,5,6, Level.Hero);
	}
}

class Featpoints
{
	int amount;
	public void Gain()
	{
		if(amount >=3)return;
		amount += 1;
	}
	public bool Spend()
	{
		if(amount > 0)
		{
			amount--;
			return true;
		}
		return false;
	}
	void Reset()
	{
		amount = 3;
	}
}

static class DieRoll
{
	static int total;
	public static int d3(int amountOfDice)
	{
		total =0;
		for(int i = 0; i < amountOfDice; i++)
		{
			total += Random.Range(0,4);
		}
		return total;
	}
	public static int d6(int amountOfDice)
	{
		total =0;
		for(int i = 0; i < amountOfDice; i++)
		{
			total += Random.Range(0,7);
		}
		return total;
	}
}

class WeaponClass
{
	public float RNG;
	public int RATMAT;
	public int POW;
	public bool melee;

	public void Init(float a_rng, int a_at, int a_pow, bool a_melee)
	{
		RNG = a_rng;
		RATMAT = a_at;
		POW = a_pow;
		melee = a_melee;
	}
}