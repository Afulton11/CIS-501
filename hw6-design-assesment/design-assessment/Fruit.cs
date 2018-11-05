using System;
namespace designassessment
{
    //The purpose of the class is to maintain the correct state of Fruit objects.

    public class Fruit
    {
        String name;
        int color;
        int shape;
        Genus genus;

        public Fruit(String name, int emp_id, Genus genus)
        {
            // Update the data member;
        }

        int UpdateShape(int salary)
        {
            // Update shape of Fruit
            // ...............
            // ........
            return 0;
        }

        void UpdateGenus(Genus genus)
        {
            // Change genus of Fruit
            // ...code goes here
            // ......
        }

        int update_Fruit_database(DatabaseHandler db)
        {
            // Update shape of Fruit in database
            // ...............
            // ........
            return 0;
        }
    }
}
