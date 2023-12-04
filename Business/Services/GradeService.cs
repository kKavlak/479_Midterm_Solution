using Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Contexts;

namespace Business.Services
{
    public interface IGradeService
    {
        IQueryable<GradeModel> Query();
    }

    public class GradeService : IGradeService
    {
        private readonly Db _db;

        public GradeService(Db db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
        }

        // Implementing IGradeService methods

        public IQueryable<GradeModel> Query()
        {
            return _db.Grades.OrderBy(a => a.Year).Select(a => new GradeModel()
            {
                GradeId = a.GradeId,
                Year = a.Year
            });
        }
    }
}
