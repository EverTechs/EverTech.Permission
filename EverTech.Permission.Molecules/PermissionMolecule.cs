using System;

namespace EverTech.Permission.Molecules
{
	public class PermissionMolecule
	{
        public int Id { get; set; }
        public int PType { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string Remark { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }

    }
}