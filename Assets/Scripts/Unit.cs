using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
    private bool Triggered;
    public int HP;
    public int Damage;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!Triggered)
        {
            gameObject.GetComponent<Transform>().Translate(Vector3.forward * Time.deltaTime * 10);
        }
	}
    void OnTriggerEnter(Collider other)
    {
        if (!other.isTrigger)
        {
            Triggered = true;
            StartCoroutine(Attack(other.GetComponent<Unit>()));
        }
    }
    IEnumerator Attack(Unit Enemy)
    {
        while (Enemy.HP > 0)
        {
            Enemy.HP-=this.Damage;
            //Debug.Log(EnemyHP.HP);
            yield return new WaitForSeconds(1);
        }
        Enemy.Dead();
        Triggered = false;
        yield return null;
    }
    void Dead()
    {
        Destroy(gameObject);
    }
}
