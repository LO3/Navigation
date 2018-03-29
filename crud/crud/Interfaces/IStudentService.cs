using System;
using System.Collections.Generic;
using crud.Models;

namespace crud.Interfaces
{
    public interface IStudentService
    {
        void Add(Student student);
        void Show(string name);
        void ShowAll();
        void GetByName(string name);
        List<Student> GetAll();
        void Delete(Student student);
        void Update(Student student);
    }
}
