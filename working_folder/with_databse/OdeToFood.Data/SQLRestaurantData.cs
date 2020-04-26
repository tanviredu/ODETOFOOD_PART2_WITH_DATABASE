using Microsoft.EntityFrameworkCore;
using OdeToFood.Core;
using System.Collections.Generic;
using System.Linq;
namespace OdeToFood.Data
{
    public class SQLRestaurantData : IRestaurantData
    {


        private readonly OdeToFoodDbContext db;

        public SQLRestaurantData(OdeToFoodDbContext db)
        {
            // init the db
            this.db = db;
        }

        // first we init out db  instance
        // in the constructor



        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
                
                }

        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null) {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            // update
            var entity = db.Restaurants.Attach(updatedRestaurant);

            // send the modifyed information
            entity.State = EntityState.Modified;
            return updatedRestaurant;


            // done now change the startup script to in memory to database
        }
    }
}
