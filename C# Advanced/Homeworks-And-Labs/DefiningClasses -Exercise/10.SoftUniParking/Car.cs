using System;

namespace SoftUniParking
{
    public class Car
    {
        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        //•	Make: string
        //•	Model: string
        //•	HorsePower: int
        //•	RegistrationNumber: string

        public string Make { get; set; }

        public string Model { get; set; }

        public int HorsePower { get; set; }

        public string RegistrationNumber { get; set; }

        public override string ToString()
        {
            //"Make: {make}"
            //"Model: {model}"
            //"HorsePower: {horse power}"
            //"RegistrationNumber: {registration number}"

            StringBuilder result = new StringBuilder();

            result
                .AppendLine($"Make: {Make}")
                .AppendLine($"Model: {Model}")
                .AppendLine($"HorsePower: {HorsePower}")
                .AppendLine($"RegistrationNumber: {RegistrationNumber}");

            return result.ToString().TrimEnd();
        }
    }
}
