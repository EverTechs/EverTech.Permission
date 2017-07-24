using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverTech.Permission.Molecules
{
    public class TreeDataMolecule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameStr
        {
            get
            {
                var type = Type == 10 ? "【菜单】 " : (Type == 20 ? "【按钮】 " : "【自定义】 ");
                return type + Name;
            }
        }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public int Type { get; set; }
        public List<TreeDataMolecule> Children { get; set; }
        public List<int> UserPermissions { get; set; }

    }
}
