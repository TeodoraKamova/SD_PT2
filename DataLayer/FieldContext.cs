using BusinessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
   public class FieldContext : IDB<Field, int>
    {
        private AppDbContext _context;
        public FieldContext(AppDbContext context)
        {
            this._context = context;
        }

        public void Create(Field item)
        {
            try
            {
                _context.Fields.Add(item);
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
                _context.Fields.Remove(Read(key));
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Field Read(int key, bool noTracking = false, bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Field> query = _context.Fields;

                if (noTracking)
                {
                    query = query.AsNoTrackingWithIdentityResolution();
                }

                if (useNavigationProperties)
                {
                    query = query.Include(f => f.Users);
                }

                return query.SingleOrDefault(f => f.Id == key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<Field> ReadAll(bool useNavigationProperties = false)
        {
            try
            {
                IQueryable<Field> query = _context.Fields;


                if (useNavigationProperties)
                {
                    query = query.Include(f => f.Users);
                }

                return query.ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Update(Field item, bool useNavigationProperties = false)
        {
            try
            {
                Field fieldFrom = Read(item.Id,useNavigationProperties);

                if (useNavigationProperties)
                {

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

                    fieldFrom.Users = users;
                }

                _context.Entry(fieldFrom).CurrentValues.SetValues(item);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
