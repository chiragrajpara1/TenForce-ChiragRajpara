using System;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Test_Taste_Console_Application.Domain.DataTransferObjects.JsonObjects;

namespace Test_Taste_Console_Application.Domain.DataTransferObjects
{
    //The converter is needed for this DTO. Because of the converter, all the properties need to get the JsonProperty annotation. 
    [Newtonsoft.Json.JsonConverter(typeof(JsonPathConverter))]
    public class MoonDto
    {
        [JsonProperty("id")] public string Id { get; set; }

        //The property moon is used to set the Id property. 
        [JsonProperty("moon")]
        public string Moon
        {
            get => Id;
            set => Id = value;
        }

        //The path of the specific moon
        [JsonProperty("rel")] public string Rel { get; set; }
        public string URLId { get => Rel.Split('/').Last(); }

        //The path to the nested property is created by using a dot. 
        [JsonProperty("mass.massValue")] public float MassValue { get; set; }
        [JsonProperty("mass.massExponent")] public float MassExponent { get; set; }
        [JsonProperty("meanRadius")] public float MeanRadius { get; set; }

        [JsonProperty("gravity")]
        public double Gravity
        {
            get
            {
                //g = GM/r2

                //G is the universal gravitational constant and its value = 6.673 x 10-11 N m2 Kg-2
                double G = 6.674 * Math.Pow(10, -11);
                //Mass
                double M = MassValue * Math.Pow(10, MassExponent);
                //Radius 
                double r = MeanRadius * 1000;

                return ((G * M) / (Math.Pow(r, 2)));
            }
        }
    }
}
