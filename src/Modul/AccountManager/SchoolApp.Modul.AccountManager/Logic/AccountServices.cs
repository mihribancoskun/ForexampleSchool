using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolApp.Infrastructure;

namespace SchoolApp.Modul.AccountManager
{
    public class AccountServices : IAccountServices
    {
        private EfDbContext _context;

        public AccountServices()
        {
            _context = new EfDbContext();
        }
        public ResultModel<UserViewModel> UserCheck(string userName, string password)
        {

            var query = from user in _context.User.Where(c => c.UserName == userName && c.Password == password)
                        from sc in _context.UserSchool.Where(c => c.UserId == user.Id)
                        from s in _context.School.Where(c => c.Id == sc.SchoolId)
                        select new 
                        {
                            userId = user.Id,
                            user.Name,
                            user.Surname,
                            user.Email,
                            schoolId = s.Id,
                            schoolTitle = s.Title
                        };

            var queryGroupfirst = query.ToList()?.GroupBy(c => c.userId).FirstOrDefault();

            var result = queryGroupfirst != null ? new UserViewModel
            {
                Id = queryGroupfirst.Key,
                Name = queryGroupfirst.AsEnumerable()?.FirstOrDefault()?.Name + " " + queryGroupfirst.AsEnumerable()?.FirstOrDefault()?.Surname,
                Email = queryGroupfirst.AsEnumerable()?.FirstOrDefault()?.Email,
                Schools = queryGroupfirst.AsEnumerable()?.Select(c => new SchoolViewModel
                {
                    Id = c.schoolId,
                    Title = c.schoolTitle,

                }).ToList()
            }:null;


            return result == null
                ? new ResultModel<UserViewModel>
                {
                    Result = ResultModelType.Error
                }
                : new ResultModel<UserViewModel>
                {
                    Result = ResultModelType.Success,
                    Data = result,
                };

        }

        public ResultModel<UserViewModel> GetUser(int key)
        {
            throw new NotImplementedException();
        }

        public ResultModel UpdateUser(UserViewModel user)
        {
            throw new NotImplementedException();
        }
    }
}
