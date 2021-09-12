using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CertIVSpeedrun.Testing
{
    public class Lists : MonoBehaviour
    {
        [SerializeField] private List<string> cities = new List<string>{"x","y","z"};
        
        // Start is called before the first frame update
        private void Start()
        {
            PrintCities();
            cities.Insert(1,"London");
            PrintCities();
            var currenTransform = this.transform;
        }

        private void PrintCities()
        {
            foreach(string city in cities)
            {
                print($"This city is {city}");
            }
        }
    }
}