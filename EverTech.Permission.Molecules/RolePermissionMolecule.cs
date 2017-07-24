using System;
using System.Collections.Generic;

namespace EverTech.Permission.Molecules
{
	public class RolePermissionMolecule
	{
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }

        public List<int> RoleIds { get; set; }
        public List<int> PermissionIds { get; set; }

        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }

    }
}