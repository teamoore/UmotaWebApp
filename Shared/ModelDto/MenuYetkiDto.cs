using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UmotaWebApp.Shared.ModelDto
{
    public class MenuYetkiDto
    {
        private bool _view = true;
        public bool View
        {
            get
            {
                if (IsAdmin) return true;
                return _view;
            }
            set
            {
                _view = value;
            }
        }

        private bool _insert = false;
        public bool Insert {
            get
            {
                if (IsAdmin) return true;
                return _insert;
            }
            set
            {
                _insert = value;
            }
        }

        private bool _update = false;
        public bool Update {
            get
            {
                if (IsAdmin) return true;
                return _update;
            }
            set
            {
                _update = value;
            }
        }

        private bool _delete = false;
        public bool Delete {
            get
            {
                if (IsAdmin) return true;
                return _delete;
            }
            set
            {
                _delete = value;
            }
        }
        public bool IsAdmin { get; set; }
    }
}
