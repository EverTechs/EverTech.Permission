using System;

namespace EverTech.Permission.Molecules
{
	public class RoleMolecule
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