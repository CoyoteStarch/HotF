namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class IronIngot : VRTK_InteractableObject
    {

        private GameObject ingot;
        private Color targetColor = Color.yellow;
        private Color initialColor;

        // Use this for initialization
        void Start()
        {
            ingot = GameObject.Find("ingot").gameObject;
            initialColor = ingot.GetComponent<MeshRenderer>().material.color;
        }

        // Update is called once per frame
        protected override void Update()
        {
            base.Update();
            //changeColor();
        }

        private void changeColor()
        {
            if(inForge())
            {

                Color currentColor = Color.Lerp(initialColor, targetColor, Mathf.PingPong(Time.time, 1));
                ingot.GetComponent<MeshRenderer>().material.color = currentColor;

                if(currentColor == targetColor)
                {
                    var lastColor = initialColor;
                    initialColor = targetColor;
                    targetColor = lastColor;
                }
            }

        }

        /*
        void onCollisionEnter(Collider other)
        {
            Debug.Log("Object Entered Trigger");
            if (other.gameObject.tag.Equals("forge") == true)
            //if (other.transform.gameObject.name == "forgeSpot")
            {
                changeColor();

            }

        }

        void onCollisionStay(Collider other)
        {
            Debug.Log("Object still in Trigger");
            if (other.gameObject.tag.Equals("forge") == true)
            //if (other.transform.gameObject.name == "forgeSpot")
            {
                changeColor();

            }

        }
        */


        public override void StartTouching(GameObject currentTouchingObject)
        {
            base.StartTouching(currentTouchingObject);
            Debug.Log("Object Touching");
            changeColor();

            if (currentTouchingObject.gameObject.tag.Equals("forge") == true)
            {
                Debug.Log("Touching Forge");
            }
        }

        private bool inForge()
        {

            return true;
        }

    }
}