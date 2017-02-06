using System;
using Orm.Son.Core;

namespace EverTech.Permission.Storages.StorageCore
{
	public class DbCtx : SonConnection
	{
		public DbCtx() : base("connString")
		{
		}
	}
}