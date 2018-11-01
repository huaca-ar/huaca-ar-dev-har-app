// MY CODE

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mapbox.Examples
{
	public class CharacterMovement : MonoBehaviour
	{
		public Material[] Materials;
		public Transform Target;
		public Animator CharacterAnimator;
		public float Speed;
		AstronautMouseController _controller;
		void Start()
		{
			// _controller = GetComponent<AstronautMouseController>();
		}

		void Update()
		{
           
			
			// if (_controller.enabled)// Because the mouse control script interferes with this script
			// {
			// 	return;
			// }

             if(Target.position == this.transform.position)
            {
                CharacterAnimator.SetBool("IsWalking", false);
                return;
            }
            myCamControl();
            StartCoroutine(LookAtNextPos());

			foreach (var item in Materials)
			{
				item.SetVector("_CharacterPosition", transform.position);
			}

			var distance = Vector3.Distance(transform.position, Target.position);
			if (distance > 0.1f)
			{
				transform.LookAt(Target.position); // girar el player hacia el punto objetivo (target)
				transform.Translate(Vector3.forward * Speed);

                CharacterAnimator.SetBool("IsWalking", true);
                
           
			}
			else
			{
				CharacterAnimator.SetBool("IsWalking", false);
			}
		}


        [Header("CameraSettings")]
        [SerializeField]
        Camera cam;
        Vector3 previousPos = Vector3.zero;
        Vector3 deltaPos = Vector3.zero;

        void myCamControl()
        {
            deltaPos = Target.position - previousPos;
            deltaPos.y = 0;
            cam.transform.position = Vector3.Lerp(cam.transform.position, cam.transform.position + deltaPos, Time.time);
            previousPos = Target.position;
        }

        IEnumerator LookAtNextPos()
        {
            Quaternion neededRotation = Quaternion.LookRotation(Target.position - this.transform.position);
            Quaternion thisRotation = this.transform.localRotation;

            float t = 0;
            while (t < 1.0f)
            {
                t += Time.deltaTime / 0.25f;
                var rotationValue = Quaternion.Slerp(thisRotation, neededRotation, t);
                this.transform.rotation = Quaternion.Euler(0, rotationValue.eulerAngles.y, 0);
                yield return null;
            }
        }
    }
}