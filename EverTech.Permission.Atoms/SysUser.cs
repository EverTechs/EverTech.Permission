using System;
using Orm.Son.Mapper;

namespace EverTech.Permission.Atoms
{
    public class SysUser
    {
        [Description("编号")]
        public int Id { set; get; }

        /// <summary>
        /// 用户名
        /// </summary>
        [Description("账号")]
        public string Account { set; get; }

        /// <summary>
        /// 密码
        /// </summary>
        [Description("密码")]
        public string Pwd { set; get; }

        /// <summary>
        /// 手机号
        /// </summary>
        [Description("手机号")]
        public string PhoneNumber { set; get; }

        /// <summary>
        /// 邮箱
        /// </summary>
        [Description("邮箱")]
        public string Email { set; get; }

        /// <summary>
        /// 是否是超级管理员
        /// </summary>
        [Description("是否是超级管理员")]
        public bool IsSuper { set; get; }

        /// <summary>
        /// 添加时间
        /// </summary>
        [Description("添加时间")]
        public DateTime AddTime { set; get; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [Description("是否启用")]
        public bool Enable { set; get; }

    }
}