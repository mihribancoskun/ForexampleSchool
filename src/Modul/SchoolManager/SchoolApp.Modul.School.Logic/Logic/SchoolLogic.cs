using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SchoolApp.Modul.School.Provider;
using SchoolApp.Modul.School.Provider;

namespace SchoolApp.Modul.School.Logic
{

    public class SchoolLogic : ISchoolServices
    {
        public EfDbContext _Context { get; set; }

        public SchoolLogic()
        {
            _Context = new EfDbContext();
        }
        public List<SchoolViewModel> GetSchool()
        {
            var _data = _Context.School.ToList();

            return _data != null ? _data.Select(c => new SchoolViewModel
            {
                Id = c.Id,
                Title = c.Title
            }).ToList() : null;
        }

        public SchoolViewModel GetSchool(int id)
        {
            var _data = _Context.School.Find(id);
            return new SchoolViewModel
            {
                Id = _data.Id,
                Title = _data.Title,

            };
        }

        public List<MemberViewModel> GetMember(int schoolId)
        {
            var _data = from member in _Context.Member
                        from parent in _Context.Parent.Where(c => c.Id == member.ParentId)
                        from parentSchool in _Context.ParentSchool.Where(c => c.ParentId == parent.Id && c.SchoolId == schoolId)
                        select new MemberViewModel
                        {
                            Name = member.Name,
                            Surname = member.Surname,
                            ParentName = parent.Name + " " + parent.Surname,
                            SchoolNo = member.SchoolNo,
                            ParentId = parent.Id,
                            Id = member.Id

                        };
            return _data.ToList();
        }

        public MemberViewModel GetMember(int schoolId, int id)
        {
            var _data = from member in _Context.Member.Where(c => c.Id == id)
                        from parent in _Context.Parent.Where(c => c.Id == member.ParentId)
                        from parentSchool in _Context.ParentSchool.Where(c => c.ParentId == parent.Id && c.SchoolId == schoolId)
                        select new MemberViewModel
                        {
                            Name = member.Name,
                            Surname = member.Surname,
                            ParentName = parent.Name + " " + parent.Surname,
                            SchoolNo = member.SchoolNo,
                            ParentId = parent.Id,
                            Id = member.Id

                        };
            return _data.FirstOrDefault();
        }

        public List<ParentViewModel> GetParent(int schoolId)
        {
            var _data = from parent in _Context.Parent
                        from parentSchool in _Context.ParentSchool.Where(c => c.ParentId == parent.Id && c.SchoolId == schoolId)
                        select new ParentViewModel
                        {
                            Id = parent.Id,
                            Name = parent.Name,
                            Surname = parent.Surname
                        };

            return _data.ToList();
        }                   

        public bool MemberUpdate(MemberViewModel member)
        {
            var _data = _Context.Member.Find(member.Id);

            _data.Name = member.Name;
            _data.Surname = member.Surname;
            _data.SchoolNo = member.SchoolNo;
            _data.ParentId = member.ParentId;
            return _Context.SaveChanges() > 0;
        }

        public bool MemberDelete(int key)
        {
            var _data = _Context.Member.Find(key);
            _Context.Member.Remove(_data);
            return _Context.SaveChanges() > 0;
        }

        public bool MemberAdd(MemberViewModel member)
        {
            var _data = new Member
            {
                Name = member.Name,
                ParentId = member.ParentId,
                SchoolNo = member.SchoolNo,
                Surname = member.SchoolNo,
            };
            _Context.Member.Add(_data);
            return _Context.SaveChanges() > 0;

        }

        public bool ParentUpdate(ParentViewModel parent)
        {
            var _data = _Context.Parent.Find(parent.Id);
            _data.Name = parent.Name;
            _data.Surname = parent.Surname;
            return _Context.SaveChanges() > 0;

        }

        public bool ParentDelete(int key)
        {
            var _data = _Context.Parent.Find(key);
            _Context.Remove(_data);
            return _Context.SaveChanges() > 0;
        }

        public bool ParentAdd(ParentViewModel parent)
        {
            var _data = new Parent
            {
                Name = parent.Name,
                Surname = parent.Surname,
            };
            _Context.Parent.Add(_data);
            _Context.SaveChanges();
            _Context.ParentSchool.Add(new ParentSchool
            {
                ParentId = _data.Id,
                SchoolId = parent.SchoolId
            });

            return _Context.SaveChanges() > 0;

        }
    }
}
