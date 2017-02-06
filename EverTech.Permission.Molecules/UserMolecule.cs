using System;

namespace EverTech.Permission.Molecules
{
	public class UserMolecule
	{
        public int Id { get; set; }
        public string Account { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public bool? Gender { get; set; }
        public DateTime? AddTime { get; set; }
        public int? AddUser { get; set; }
        public DateTime? EditTime { get; set; }
        public int? EditUser { get; set; }
        public bool? Enable { get; set; }

    }
}