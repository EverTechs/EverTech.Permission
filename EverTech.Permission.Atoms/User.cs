using System;
using Orm.Son.Mapper;

namespace EverTech.Permission.Atoms
{
	public class User
	{
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public bool? Gender { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? AddUser { get; set; }
        public DateTime? EditTime { get; set; }
        public int? EditUser { get; set; }
        public bool? Enable { get; set; }
    }
}