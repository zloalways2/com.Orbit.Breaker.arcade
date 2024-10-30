using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

namespace UI
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private TapObject tapObject;
        [SerializeField] private float Speed;
        [SerializeField] private float SpeedRandom;

        [SerializeField] private float Borders;
        [SerializeField] private RocketGameWindow _rocketGameWindow;

        private bool isEnabled = false;

        
        private float timer;
        
        
        
        private void Update()
        {
            if (isEnabled)
            {
                if (timer <= 0)
                {
                    var tapObj = Instantiate(tapObject, transform);
                    tapObj.transform.position += new Vector3(Random.Range(-Borders, Borders), 0, 0);
                    tapObj.Speed = Speed + Random.Range(-SpeedRandom, SpeedRandom);
                    tapObj.OnClick = _rocketGameWindow.TapObjectTouched;
                    tapObj.SetId(Random.Range(0, 6));
                    timer = Random.Range(1f, 2f);
                }

                timer -= Time.deltaTime;
            }
        }

        public void StartLevel()
        {
           
            isEnabled = true;
            gameObject.SetActive(true);
        }
        private void OnDisable()
        {
            isEnabled = false;
        }
        
    }
}