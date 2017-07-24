using System;
using Orm.Son.Mapper;

namespace EverTech.Permission.Atoms
{
	public class RolePermission
	{
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }

    }
}