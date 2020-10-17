using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CarMove : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

    private Image backgroundImg;
    public Image joyStickImg;
    private Vector3 inputVector;

    // Car Controll Script
    public CarController carControll;


    private void Awake()
    {
        backgroundImg = GetComponent<Image>();
    }

    public virtual void OnDrag(PointerEventData ped)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(backgroundImg.rectTransform, ped.position, ped.pressEventCamera, out pos))
        {

            pos.x = (pos.x / backgroundImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / backgroundImg.rectTransform.sizeDelta.y);

            inputVector = new Vector3(pos.x * 2 + 1, pos.y * 2 - 1, pos.y * 2 - 1);
            inputVector = (inputVector.magnitude > 1.0f) ? inputVector.normalized : inputVector;



            // Moving JoyStick Image
            joyStickImg.rectTransform.anchoredPosition = new Vector3(0, inputVector.y * (backgroundImg.rectTransform.sizeDelta.y / 3));

            // Move Car
            carControll.motorWheelsFromMobile = inputVector.y;



        }






    }

    public virtual void OnPointerDown(PointerEventData ped)
    {
        OnDrag(ped);
    }

    public virtual void OnPointerUp(PointerEventData ped)
    {
        inputVector = Vector2.zero;
        joyStickImg.rectTransform.anchoredPosition = Vector3.zero;

        // Stop Wheels Click
        carControll.motorWheelsFromMobile = 0f;



    }


    // Return Values Used To Move Character

    public float horizontal()
    {

        if (inputVector.x != 0)
        {
            return inputVector.x;
        }
        else
        {
            return Input.GetAxis("Horizontal");
        }

    }

    public float vertical()
    {

        if (inputVector.z != 0)
        {
            return inputVector.z;
        }
        else
        {
            return Input.GetAxis("Vertical");
        }

    }



}
