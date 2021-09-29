/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    public GameObject Beam;
    public float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GameObject newBeam = Instantiate(beam, transform.position, transform.rotation);
            newBeam.transform.SetParent(gameObject.transform);
            newBeam.transform.localPosition = new Vector3(0.7f, -0.3f);
            float dir = 0f;
            if (PlayerMove.faceRight)
            {
                dir = 1f;
            }
            else
            {
                newBeam.GetComponent<SpriteRenderer>().flipX = true;
                dir = -1f;
    
            }

            newBeam.GetComponent<Rigidbody2D>.velocity = new Vector(dir * shootSpeed, 0f);
        }
}*/
