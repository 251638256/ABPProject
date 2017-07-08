using MultiPageProject.Authorization.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultiPageProject.Web.Models.Account {
    public class EditRolesEditViewModel {
        public long ID { get; set; }
        public string UserName { get; set; }
        public List<RoleChecked> RoleStatus { get; set; }
    }

    public class RoleChecked {
        public Role Role { get; set; }

        private bool _checked;
        public bool Checked { get { return _checked; }
            set {
                CheckedValue = "";
                if (value) {
                    CheckedValue = "checked";
                }
                _checked = value;
            }
        }
        public string CheckedValue { get; set; }
    }
}