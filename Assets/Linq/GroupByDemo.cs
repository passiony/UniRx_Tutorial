using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GroupByDemo : MonoBehaviour
{
    class Pet
    {
        public string Name { get; set; }
        public double Age { get; set; }
    }

    private void Start()
    {
        GroupByEx4();
    }

    public static void GroupByEx4()
    {
        // Create a list of pets.
        List<Pet> petsList =
            new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                new Pet { Name="Boots", Age=4.9 },
                new Pet { Name="Whiskers", Age=1.5 },
                new Pet { Name="Daisy", Age=4.3 } };

        // Group Pet.Age values by the Math.Floor of the age.
        // Then project an anonymous type from each group
        // that consists of the key, the count of the group's
        // elements, and the minimum and maximum age in the group.
        var query = petsList.GroupBy(
            pet => Math.Floor(pet.Age),
            pet => pet.Age,
            (baseAge, ages) => new
            {
                Key = baseAge,
                Count = ages.Count(),
                Min = ages.Min(),
                Max = ages.Max()
            });

        // Iterate over each anonymous type.
        foreach (var result in query)
        {
            Debug.Log("\nAge group: " + result.Key);
            Debug.Log("Number of pets in this age group: " + result.Count);
            Debug.Log("Minimum age: " + result.Min);
            Debug.Log("Maximum age: " + result.Max);
        }

        /*  This code produces the following output:
    
            Age group: 8
            Number of pets in this age group: 1
            Minimum age: 8.3
            Maximum age: 8.3
    
            Age group: 4
            Number of pets in this age group: 2
            Minimum age: 4.3
            Maximum age: 4.9
    
            Age group: 1
            Number of pets in this age group: 1
            Minimum age: 1.5
            Maximum age: 1.5
        */
    }
    
    public static void GroupByEx3()
    {
        // Create a list of pets.
        List<Pet> petsList =
            new List<Pet>{ new Pet { Name="Barley", Age=8.3 },
                new Pet { Name="Boots", Age=4.9 },
                new Pet { Name="Whiskers", Age=1.5 },
                new Pet { Name="Daisy", Age=4.3 } };

        // Group Pet objects by the Math.Floor of their age.
        // Then project an anonymous type from each group
        // that consists of the key, the count of the group's
        // elements, and the minimum and maximum age in the group.
        var query = petsList.GroupBy(
            pet => Math.Floor(pet.Age),
            (age, pets) => new
            {
                Key = age,
                Count = pets.Count(),
                Min = pets.Min(pet => pet.Age),
                Max = pets.Max(pet => pet.Age)
            });

        // Iterate over each anonymous type.
        foreach (var result in query)
        {
            Console.WriteLine("\nAge group: " + result.Key);
            Console.WriteLine("Number of pets in this age group: " + result.Count);
            Console.WriteLine("Minimum age: " + result.Min);
            Console.WriteLine("Maximum age: " + result.Max);
        }

        /*  This code produces the following output:
    
            Age group: 8
            Number of pets in this age group: 1
            Minimum age: 8.3
            Maximum age: 8.3
    
            Age group: 4
            Number of pets in this age group: 2
            Minimum age: 4.3
            Maximum age: 4.9
    
            Age group: 1
            Number of pets in this age group: 1
            Minimum age: 1.5
            Maximum age: 1.5
        */
    }
}
