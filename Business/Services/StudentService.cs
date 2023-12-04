using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace Business.Services
{
    public interface IStudentService
    {
        IQueryable<StudentModel> Query();
        bool Add(StudentModel student);
        bool Update(StudentModel student);
        bool Delete(int studentId);
    }

    public class StudentService : IStudentService
    {
        private readonly Db _db;

        public StudentService(Db db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // Implementing IStudentService methods

        public IQueryable<StudentModel> Query()
        {
            return _db.Students.Include(s => s.Grade)
                .OrderByDescending(s => s.CumulativeGPA).ThenBy(s => s.Name).ThenBy(s => s.Surname)
                .Select(s => new StudentModel()
                {
                    GradeId = s.GradeId,
                    GradeOutput = s.Grade.Year,
                    StudentId = s.StudentId,
                    Name = s.Name,
                    Surname = s.Surname,
                    Rank = s.Rank,
                    CumulativeGPA = s.CumulativeGPA,
                });
        }

        public bool Add(StudentModel model)
        {
            if (_db.Students.Any(s => s.Name.ToUpper() == model.Name.ToUpper().Trim()) &&
                _db.Students.Any(s => s.Surname.ToUpper() == model.Surname.ToUpper().Trim()))
                return false;
            Student entity = new Student()
            {
                GradeId = model.GradeId,
                Name = model.Name.Trim(),
                Surname = model.Surname.Trim(),
                Rank = model.Rank,
                CumulativeGPA = model.CumulativeGPA,
            };
            _db.Students.Add(entity);
            _db.SaveChanges();
            return true;
        }

        public bool Update(StudentModel student)
        {
            try
            {
                var existingStudent = _db.Students.FirstOrDefault(s => s.StudentId == student.StudentId);
                if (existingStudent != null)
                {
                    // Update properties based on the provided StudentModel
                    existingStudent.Name = student.Name;
                    existingStudent.Surname = student.Surname;
                    existingStudent.Rank = student.Rank;
                    existingStudent.CumulativeGPA = student.CumulativeGPA;
                    existingStudent.GradeId = student.GradeId;

                    return true;
                }
                else
                {
                    // Student not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }

        public bool Delete(int studentId)
        {
            try
            {
                var studentToRemove = _db.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (studentToRemove != null)
                {
                    _db.Students.Remove(studentToRemove);
                    return true;
                }
                else
                {
                    // Student not found
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }
    }

}
