using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UmotaWebApp.Server.Data.Migrations
{
    public partial class FirstInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sis_ambar",
                columns: table => new
                {
                    logref = table.Column<int>(type: "int", nullable: false),
                    firma_no = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    isyeriref = table.Column<int>(type: "int", nullable: false),
                    kodu = table.Column<short>(type: "smallint", nullable: false),
                    adi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_firma",
                columns: table => new
                {
                    firma_no = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    firma_adi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    logo_stok_kart = table.Column<bool>(type: "bit", nullable: true),
                    logo_cari_kart = table.Column<bool>(type: "bit", nullable: true),
                    logo_hizmet_kart = table.Column<bool>(type: "bit", nullable: true),
                    logo_firma_no = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_firma_donem",
                columns: table => new
                {
                    logref = table.Column<int>(type: "int", nullable: false),
                    firma_no = table.Column<short>(type: "smallint", nullable: true),
                    yil = table.Column<short>(type: "smallint", nullable: true),
                    logo_firma = table.Column<short>(type: "smallint", nullable: true),
                    logo_donem = table.Column<short>(type: "smallint", nullable: true),
                    ondeger = table.Column<byte>(type: "tinyint", nullable: true),
                    aciklama = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_firma_donem_yetki",
                columns: table => new
                {
                    logref = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    donemref = table.Column<int>(type: "int", nullable: true),
                    tur = table.Column<byte>(type: "tinyint", nullable: true),
                    kodu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_isyeri",
                columns: table => new
                {
                    logref = table.Column<int>(type: "int", nullable: false),
                    firma_no = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    kodu = table.Column<short>(type: "smallint", nullable: false),
                    adi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_kisayol",
                columns: table => new
                {
                    kullanici_kodu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    menu_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_kullanici",
                columns: table => new
                {
                    kullanici_kodu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    kullanici_adi = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    kullanici_sifre = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    kullanici_aktif = table.Column<bool>(type: "bit", nullable: false),
                    kullanici_iptal = table.Column<bool>(type: "bit", nullable: false),
                    kullanici_yetki_kodu = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: true),
                    kullanici_pcadi = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    kullanici_menu_profil = table.Column<int>(type: "int", nullable: true),
                    son_giris_tarihi = table.Column<DateTime>(type: "datetime", nullable: true),
                    mail_host = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    mail_adres = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    mail_kullanici = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    mail_sifre = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    mail_imza = table.Column<string>(type: "text", nullable: true),
                    logo_username = table.Column<string>(type: "varchar(21)", unicode: false, maxLength: 21, nullable: true),
                    logo_password = table.Column<string>(type: "varchar(32)", unicode: false, maxLength: 32, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_kullanici_haklari",
                columns: table => new
                {
                    kullanici_kodu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    menu_id = table.Column<int>(type: "int", nullable: false),
                    hak_tipi = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_kullanici_yetki_kodlari",
                columns: table => new
                {
                    kullanici_kodu = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    yetki_kodu = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_menu_profil",
                columns: table => new
                {
                    profil_id = table.Column<int>(type: "int", nullable: false),
                    profil_adi = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_menu_profil_haklari",
                columns: table => new
                {
                    profil_id = table.Column<int>(type: "int", nullable: false),
                    menu_id = table.Column<int>(type: "int", nullable: false),
                    hak_tipi = table.Column<string>(type: "char(3)", unicode: false, fixedLength: true, maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_menuler",
                columns: table => new
                {
                    menu_id = table.Column<int>(type: "int", nullable: false),
                    parent_id = table.Column<int>(type: "int", nullable: false),
                    menu_modul = table.Column<short>(type: "smallint", nullable: false),
                    menu_secenek = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    menu_tanimi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    menu_dfm = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    menu_sira = table.Column<short>(type: "smallint", nullable: true),
                    menu_girismi = table.Column<bool>(type: "bit", nullable: true),
                    menu_param = table.Column<short>(type: "smallint", nullable: true),
                    menu_acarken_guncelle = table.Column<bool>(type: "bit", nullable: true),
                    image_index = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_refno",
                columns: table => new
                {
                    tablename = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    increment = table.Column<int>(type: "int", nullable: false),
                    lastrefno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_sabitler",
                columns: table => new
                {
                    tip = table.Column<short>(type: "smallint", nullable: false),
                    tanimi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    izin = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_sabitler_detay",
                columns: table => new
                {
                    sabit_detay_id = table.Column<int>(type: "int", nullable: false),
                    tip = table.Column<short>(type: "smallint", nullable: false),
                    kodu = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    ikodu = table.Column<int>(type: "int", nullable: true),
                    adi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    yabanci_adi = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    siralama = table.Column<short>(type: "smallint", nullable: false),
                    ozel_kod1 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ozel_kod2 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ozel_kod3 = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    ozel_kod4 = table.Column<int>(type: "int", nullable: true),
                    ozel_kod5 = table.Column<int>(type: "int", nullable: true),
                    ozel_kod6 = table.Column<int>(type: "int", nullable: true),
                    ozel_kod7 = table.Column<double>(type: "float", nullable: true),
                    ozel_kod8 = table.Column<double>(type: "float", nullable: true),
                    ozel_kod9 = table.Column<double>(type: "float", nullable: true),
                    ozel_kod10 = table.Column<DateTime>(type: "datetime", nullable: true),
                    ozel_kod11 = table.Column<DateTime>(type: "datetime", nullable: true),
                    ozel_kod12 = table.Column<DateTime>(type: "datetime", nullable: true),
                    izin = table.Column<byte>(type: "tinyint", nullable: true),
                    renk1 = table.Column<int>(type: "int", nullable: true),
                    renk2 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "sis_yetki_kodlari",
                columns: table => new
                {
                    yetki_kodu = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: false),
                    yetki_adi = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sis_ambar");

            migrationBuilder.DropTable(
                name: "sis_firma");

            migrationBuilder.DropTable(
                name: "sis_firma_donem");

            migrationBuilder.DropTable(
                name: "sis_firma_donem_yetki");

            migrationBuilder.DropTable(
                name: "sis_isyeri");

            migrationBuilder.DropTable(
                name: "sis_kisayol");

            migrationBuilder.DropTable(
                name: "sis_kullanici");

            migrationBuilder.DropTable(
                name: "sis_kullanici_haklari");

            migrationBuilder.DropTable(
                name: "sis_kullanici_yetki_kodlari");

            migrationBuilder.DropTable(
                name: "sis_menu_profil");

            migrationBuilder.DropTable(
                name: "sis_menu_profil_haklari");

            migrationBuilder.DropTable(
                name: "sis_menuler");

            migrationBuilder.DropTable(
                name: "sis_refno");

            migrationBuilder.DropTable(
                name: "sis_sabitler");

            migrationBuilder.DropTable(
                name: "sis_sabitler_detay");

            migrationBuilder.DropTable(
                name: "sis_yetki_kodlari");
        }
    }
}
