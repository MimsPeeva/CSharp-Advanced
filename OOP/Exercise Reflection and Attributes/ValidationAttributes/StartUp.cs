﻿using System;
using ValidationAttributes.Model;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            //var person = new Person
            // (
            //     null,
            //     -1
            // );
            var person = new Person
                (
                "Gosho",
                35
                );
            bool isValidEntity = Validator.IsValid(person);

            Console.WriteLine(isValidEntity);
        }
    }
}
