using System.Collections.Generic;
using UnityEngine;
using static Enums;

public class GameManager : MonoBehaviour
{
    //Listas
    private List<Fighter> listFighters = new List<Fighter>();
    private List<Fighter> deathFighters = new List<Fighter>();

    //Arrays
    private string[] nameFighters = {"Scorpion","Kano","Sonya","Jhonny Cage","Sub-Zero"};
    private string[] categoryFighters = { "Ninja", "Mercenario", "Teniente", "Actor", "Ninja"};

    void Start()
    {
        //Inicializamos
        InitFighters(nameFighters, categoryFighters);
        Debug.Log(FighterWithMoreLife());
        
        //prueba para quitar 70 de vida a Scorpion
        listFighters[(int)Fighters.Scorpion].DecreaseHealth(80);

        //prueba para saber si Scorpion esta vivo
        listFighters[(int)Fighters.Scorpion].IsAlive();

        //Comprobamos si esta muerto
        CheckIsDead(listFighters[(int)Fighters.Scorpion]);
    }

    //Pasandole el nombre y la categoria, generamos dinamicamente los gameobject de los fighter,
    //asociandole a cada uno su respectivo nombre y vida y añadiendole el script Fighter.
    private void InitFighters(string[] names, string[] category) {

		for (int i = 0; i < 5; i++)
		{
            GameObject newFighter = new GameObject();
            newFighter.AddComponent<Fighter>();

            Fighter objFighter = newFighter.GetComponent<Fighter>();
            listFighters.Add(objFighter);

            objFighter.Name = names[i];
            newFighter.name = names[i];
            objFighter.Category = category[i];
            objFighter.Health = RandomLifeFighters();

            Debug.Log($"Name: {objFighter.Name}  Category: {objFighter.Category}  Health: {objFighter.Health}");
        }
    }

    //Devuelve un valor vida entre 80 y 100
    private int RandomLifeFighters() {
        int life = Random.Range(80, 100);
        return life;
    }

    //Devuelve el luchador con más vida
    private string FighterWithMoreLife()
	{
        int mayorVida = 0;
        string fighter = "";

		for (int i = 0; i < listFighters.Count; i++)
		{
            if (listFighters[i].Health > mayorVida)
                mayorVida = listFighters[i].Health;

            if(listFighters[i].Health == mayorVida)
                fighter = ($"Personaje {listFighters[i].Name}  con más vida: {listFighters[i].Health}");
        }

        return fighter;
	}

    //Comprueba mediante IsAlive si el fighter esta vivo o no,
    //y lo añade a la lista death en caso de estar muerto.
    private void CheckIsDead(Fighter fighterDead)
	{
        bool isAlive = fighterDead.IsAlive();

        if (isAlive == false) deathFighters.Add(fighterDead);

        Debug.Log($"Personaje {fighterDead.Name}  esta vivo: {isAlive}");
    }
}
