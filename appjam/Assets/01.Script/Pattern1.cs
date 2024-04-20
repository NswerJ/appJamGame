using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern1 : MonoBehaviour
{
    [SerializeField]
    float speed = 2;
    
    GameObject target;

    Vector3 mainCamera;
    Vector3 vec;

    public GameObject Effect;

    float width;
    float height;
    private void Start()
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Camera.main.aspect;

        target = GameObject.Find("target");
        mainCamera = GameObject.Find("Main Camera").gameObject.transform.position;

        setPosition();

    }
    private void Update()
    {
        vec = (target.transform.position - transform.position).normalized;
        transform.position += vec * speed * Time.deltaTime * 2;
    }
    private void setPosition()
    {

        target = GameObject.Find("target");

        int xpos = Random.Range(0, 2);
        int ypos = Random.Range(0, 2);

        if(xpos == 0) { xpos = 1; }
        else { xpos = -1; }
        if(ypos == 0) { ypos = 1; }
        else { ypos = -1; }

        transform.position = new Vector3(target.transform.position.x + ((width / 2) * -xpos) + xpos, target.transform.position.y + ((height / 2) * -ypos) + ypos, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("target"))
        {
            dieEffectShow(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            dieEffectShow(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
    public void dieEffectShow(GameObject obj)
    {
        GameObject effct = Instantiate(Effect, obj.transform.position, Quaternion.identity);
        Destroy(effct, 1.5f);
    }
}
