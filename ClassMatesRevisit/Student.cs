using System;
namespace ClassMatesRevisit
{
    class Student
    {
        //Properties
        public string Name { get; set; }
        public string HomeTown { get; set; }
        public string FavoriteFood { get; set; }


        //Constructor for List
        public Student(string Name, string Hometown, string FavoriteFood)
        {
            this.Name = Name;
            this.HomeTown = Hometown;
            this.FavoriteFood = FavoriteFood;
        }
        //For new student
        public Student()
        {
        }
    }
}
