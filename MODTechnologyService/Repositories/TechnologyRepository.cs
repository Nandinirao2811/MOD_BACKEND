using MODTechnologyService.Context;
using MODTechnologyService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MODTechnologyService.Repositories
{
    public class TechnologyRepository : ITechnologyRepository
    {
        private readonly TechnologyContext _context;

        public TechnologyRepository(TechnologyContext context)
        {
            _context = context;
        }

        public void AddTechnology(Technology item)
        {
            _context.Technologys.Add(item);
            _context.SaveChanges();
        }
        
        public void DeleteTechnology(int id)
        {
            var item = _context.Technologys.Find(id);
            _context.Technologys.Remove(item);
            _context.SaveChanges();
        }

        public List<Technology> GetAllTechnology()
        {
            return _context.Technologys.ToList();
        }

        public void UpdateTechnology(Technology item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
