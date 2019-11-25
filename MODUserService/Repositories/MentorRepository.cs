using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODUserService.Models;
using MODUserService.Context;

namespace MODUserService.Repositories
{
    public class MentorRepository : IMentorRepository
    {
        private readonly UserContext _context;
        public MentorRepository(UserContext context)
        {
            _context = context;
        }
        public void AddMentor(Mentor item)
        {
            _context.Mentors.Add(item);
            _context.SaveChanges();
        }

        public void BlockMentor(int id)
        {
            var item = _context.Mentors.Find(id);
            item.Mentor_Active = !(item.Mentor_Active);
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteMentor(int id)
        {
            var item = _context.Mentors.Find(id);
            _context.Mentors.Remove(item);
            _context.SaveChanges();
        }

        public List<Mentor> GetAllMentors()
        {
            return _context.Mentors.ToList();
        }

        public Mentor GetMentorById (int Id)
        {
            return _context.Mentors.Find(Id);
        }

     
        public void UpdateMentorPassword(string Mentoremail, string Mentorpassword)
        {
            var item = _context.Mentors.SingleOrDefault(i => i.Mentor_EmailId == Mentoremail);
            item.Mentor_Password = Mentorpassword;

            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
