using System;
namespace UmotaWebApp.Shared.ModelDto
{
    public class SisMenuDto
    {
        public int MenuId { get; set; }
        public int ParentId { get; set; }
        public string MenuTanimi { get; set; }
        public string MenuDfm { get; set; }
        public short? MenuSira { get; set; }

    }
}
