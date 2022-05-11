using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DataLayer
{
    public class InterestContext : IDB<Interest,int>
    {
        private AppDbContext _context;
        public InterestContext(AppDbContext context)
        {
            this._context = context;
        }

        public void Create(Interest item)
        {
            try
            {
                _context.Interests.Add(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(int key)
        {
            try
            {
                _context.Interests.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Interest Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(i => i.Users).Include(i=> i.Field);
                }

                return query.SingleOrDefault(i => i.Id == key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Interest> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Interest> query = _context.Interests;


                if (useNavigationProperties)
                {
                    query = query.Include(i => i.Users).Include(i => i.Field);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Interest item, bool useNavigationProperties = false)
        {
            try
            {
                Interest intersetFromDB = Read(item.Id, useNavigationProperties);

                if (useNavigationProperties)
                {
                    intersetFromDB.Field = item.Field;

                    List<User> users = new List<User>();

                    foreach (User user in item.Users)
                    {
                        User userFromDB = _context.Users.Find(user.Id);

                        if (userFromDB != null)
                        {
                            users.Add(userFromDB);
                        }
                        else
                        {
                            users.Add(user);
                        }
                    }

                    intersetFromDB.Users = users;
                }

                _context.Entry(intersetFromDB).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
