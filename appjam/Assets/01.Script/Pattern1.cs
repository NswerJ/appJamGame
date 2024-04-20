using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern1 : MonoBehaviour
{
    GameObject target;

    Vector3 mainCamera;
    Vector3 vec;

    public GameObject Effect;

    [SerializeField]
    float speed = 2;
    float width;
    float height;
    private void Start()
    {
        height = Camera.main.orthographicSize * 2;
        width = height * Camera.main.aspect;

        target = GameObject.Find("target");
        mainCamera = GameObject.Find("Main Camera").gameObject.transform.position;

        setPosition();

        vec = (target.transform.position - transform.position).normalized;
    }
    private void Update()
    {
        transform.position += vec * speed * Time.deltaTime;
    }
    private void setPosition()
    {
        int xpos = Random.Range(-1, 2);
        int ypos = Random.Range(-1, 2);

        transform.position = new Vector3(mainCamera.x + width + xpos, mainCamera.y + height + ypos, 0);
    }
    private void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("target"))
        {
            //
            dieEffectShow(collision.gameObject);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.CompareTag("Player"))
        {
            //
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
