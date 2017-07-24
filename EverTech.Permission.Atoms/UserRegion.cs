using System;
using Orm.Son.Mapper;

namespace EverTech.Permission.Atoms
{
	public class UserRegion
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RegionId { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }
    }
}