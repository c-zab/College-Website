using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public interface IStudentRepository {
        IQueryable<Student> Students { get; }
        
        Student GetById(int id);

        void SaveStudent(Student student);
    }
}
