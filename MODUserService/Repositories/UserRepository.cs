using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODUserService.Context;
using MODUserService.Models;

namespace MODUserService.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public void AddUser(User item)
        {
            _context.Users.Add(item);
            _context.SaveChanges();
        }

        public void BlockUser(int id)
        {
            var item = _context.Users.Find(id);
            item.User_Active = !(item.User_Active);
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var item = _context.Users.Find(id);
            _context.Users.Remove(item);
            _context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public List<Mentor> GetMentorSearch(string skill, string fromTimeslot, string toTimeslot)
        {
            
            return (from obj in _context.Mentors
                    where obj.Mentor_PrimarySkill == skill &&
                          obj.Mentor_FromTimeSlot == fromTimeslot &&
                            obj.Mentor_ToTimeSlot == toTimeslot
                    select obj).ToList();

        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }

        public void UpdateUserPassword(string Useremail, string Userpassword)
        {
            var item = _context.Users.SingleOrDefault(i=>i.User_Email==Useremail);
            item.User_Password = Userpassword;

            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

       

    }
}
