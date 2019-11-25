using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODTrainingService.Models;
using MODTrainingService.Context;

namespace MODTrainingService.Repository
{
    public class TrainingRepo :ITrainingRepo
    {
        private readonly TrainingContext _context;
        public TrainingRepo(TrainingContext context)
        {
            _context = context;
        }

        public void AddTraining(Training item)
        {
            _context.Trainings.Add(item);
            _context.SaveChanges();

        }

        public void DeleteTraining(int id)
        {
            var item = _context.Trainings.Find(id);
            _context.Trainings.Remove(item);
            _context.SaveChanges();
        }

        public List<Training> GetAllTraining()
        {
            return _context.Trainings.ToList();
        }

        public Training GetTrainingById(int Id)
        {
            return _context.Trainings.Find(Id);
        }

        public List<Training> GetTrainingByMentorId(int Id)
        {
            return _context.Trainings.Where(i => i.Mentor_Id == Id).ToList();
        }

        public List<Training> GetTrainingByUserId(int Id)
        {
            return  _context.Trainings.Where(i => i.User_Id == Id).ToList();
        }

        public void UpdateTraining(Training item)
        {
            _context.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
