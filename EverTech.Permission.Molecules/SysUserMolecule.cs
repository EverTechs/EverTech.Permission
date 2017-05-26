using System;

namespace EverTech.Permission.Molecules
{
	public class SysUserMolecule
	{
        /// <summary>
        /// 编号
        /// </summary>
        public int Id { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string Account { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Pwd { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string PhoneNumber { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { set; get; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        public bool IsSuper { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        public DateTime AddTime { set; get; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool Enable { set; get; }
    }
}