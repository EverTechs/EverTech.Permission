using System;
using Orm.Son.Mapper;

namespace EverTech.Permission.Atoms
{
	public class Role
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? AddTime { get; set; }
        public DateTime? AddUser { get; set; }
        public DateTime? EditTime { get; set; }
        public int? EditUser { get; set; }
        public bool? Enable { get; set; }
    }
}