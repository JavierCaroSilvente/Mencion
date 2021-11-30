using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour
{
    //variables Fighter
    string name;
    string category;
    int health;

    //constructor
    public Fighter(string name, string category, int health) {

        this.name = name;
        this.category = category;
        this.health = health;
    }

    //GETTERS Y SETTERS
    public string Name
    {
        get => name;
        set => name = value;
    }

    public string Category
    {
        get => category;
        set => category = value;
    }
    
    public int Health
    {
        get => health;
        set => health = value;
    }

    //Quita la cantidad de vida pasada por parametro al fighter.
    public void DecreaseHealth(int decrease) {

        this.health -= decrease;
        Debug.Log($"{this.name} a perdido un total de {decrease} de vida, ahora su vida es {this.health}");
    }

    //Comprueba si el fighter esta vivo , return de true o false segun si esta vivo o no.
    public bool IsAlive()
	{
        //funcion lambda con operador ternario que devuelve true si es mayor de 0 la vida y false si es menor.
        bool isAlive() => this.health >= 0 ? true : false;

        return isAlive();
	}

}
