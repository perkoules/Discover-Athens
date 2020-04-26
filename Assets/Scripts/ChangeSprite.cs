using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSprite : MonoBehaviour {

	Image m_Image;
    public Sprite[] m_Sprite;

    void Start()
    {
        m_Image = GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            m_Image.sprite = m_Sprite[0];
        }
    }
}
