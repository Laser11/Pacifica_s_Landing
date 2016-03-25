using UnityEngine;
using System.Collections;



public class Enemy
{

    private int health;
    private int attack;
    private int movement;
    private Vector3 position;
    private GameObject enemyObject;// = GameObject.CreatePrimitive(PrimitiveType.Cube);//(GameObject)Resources.Load("/Objects/Prefabs/Players.prefab");
    private int maxHealth;

    public Enemy(int maxHealth, Vector3 position)
    {

        setPosition(position);
        setMaxHealth(maxHealth);
        setHealth(maxHealth);
        //GameObject.Instantiate(enemyObject,position, Quaternion.identity);

    }

    public Enemy(Enemy copy)
    {
        if (copy != null)
        {
            setPosition(copy.getPosition());
            setMaxHealth(copy.getMaxHealth());
            setHealth(copy.getMaxHealth());
            //enemyObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            //GameObject.Instantiate(enemyObject, position, Quaternion.identity);
        }
    }
    public int getHealth()
    {
        return this.health;
    }

    public int getMaxHealth()
    {
        return this.maxHealth;
    }

    public void setHealth(int health)
    {
        this.health = health;
    }

    public void setMaxHealth(int maxHealth)
    {
        this.maxHealth = maxHealth;
    }

    public Vector3 getPosition()
    {
        return this.position;
    }

    public void setPosition(Vector3 position)
    {
        this.position = position;
        //GameObject.Instantiate(enemyObject, position, Quaternion.identity);
    }

    public GameObject getEnemyObject()
    {
        return this.enemyObject;
    }

    public void destroyEnemyObject()
    {
        //GameObject.DestroyImmediate(enemyObject);
    }

    public void setEnemyObject(GameObject enemyObject)
    {
        this.enemyObject = enemyObject;

    }

}
