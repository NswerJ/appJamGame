using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pattern2 : MonoBehaviour
{
    [SerializeField]
    GameObject laser;
    GameObject target;

    Vector3 vec;

    float length;

    private void Start()
    {
        target = GameObject.Find("target");

        set();

        vec = (target.transform.position - transform.position).normalized;

        StartCoroutine(Laser());
    }
    private void Update()
    {
        Debug.DrawRay(this.transform.position + Vector3.up, Vector3.forward * 10, Color.red);

        RaycastHit2D hitInfo = Physics2D.Raycast(this.transform.position, this.transform.forward);
        length = (this.gameObject.transform.position - hitInfo.transform.position).sqrMagnitude;

        if (hitInfo.transform.gameObject.CompareTag("Player"))
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x, length, laser.transform.localScale.z);
        }
        else
        {
            laser.transform.localScale = new Vector3(laser.transform.localScale.x, length, laser.transform.localScale.z);
        }
    }
    private void set()
    {
        transform.rotation = Quaternion.Euler(0, 180, -(Mathf.Atan2(vec.y, vec.x) * Mathf.Rad2Deg));

        //position

        this.gameObject.transform.SetParent(target.transform);
    }
    private IEnumerator Laser()
    {
        yield return new WaitForSeconds(1);
        laser.SetActive(true);
        yield return new WaitForSeconds(5f);
        laser.SetActive(false);
        Destroy(this.gameObject);
    }
}
