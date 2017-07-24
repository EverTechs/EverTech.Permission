using System;

namespace EverTech.Permission.Molecules
{
	public class UserRegionMolecule
	{
        public int Id { get; set; }
        public int UserId { get; set; }
        public int RegionId { get; set; }
        public DateTime AddTime { get; set; }
        public DateTime EditTime { get; set; }
        public bool Enable { get; set; }

    }
}