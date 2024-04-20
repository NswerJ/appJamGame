    using System.Collections;
    using System.Collections.Generic;
    using Unity.VisualScripting;
    using UnityEngine;
    public class Pattern3 : MonoBehaviour
    {
        Vector3 target;

        float width = 0;
        float height = 0;

        private void Start()
        {
            height = Camera.main.orthographicSize * 2;
            width = height * Camera.main.aspect;

            target = GameObject.Find("target").transform.position;
        }
        public void play()
        {
            StartCoroutine(pattern());
        }
        public IEnumerator pattern()
        {
            float xpos;
            float ypos;

            GameObject p1 = (GameObject)Instantiate(Resources.Load("Circle"));

            yield return new WaitForSeconds(0.05f);

            Vector2 vec = p1.transform.position;

            yield return new WaitForSeconds(3f);

            GameObject p2 = (GameObject)Instantiate(Resources.Load("Square"));

            xpos = Mathf.Clamp(vec.x, target.x - width / 2 + 1.5f, target.x + width / 2 - 1.5f);
            ypos = Mathf.Clamp(vec.y, target.y - height / 2 + 1.5f, target.y +  height / 2 - 1.5f);

            p2.transform.position = new Vector3(-xpos, -ypos, 0);
        }
    }