using System;
using crud.Interfaces;
using crud.Services;

namespace crud
{
    public class Crud
    {
        IStudentService _studentService;
        public Crud()
        {
            _studentService = new StudentService();
            ShowCrud();
        }

        public void ShowCrud()
        {
            //TODO
        }
    }
}
