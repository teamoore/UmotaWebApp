using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UmotaWebApp.Server.Data.Contexts;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class UmotaMasterDbContext : DbContext
    {
        public UmotaMasterDbContext()
        {
        }

        public UmotaMasterDbContext(DbContextOptions<UmotaMasterDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SisAmbar> SisAmbars { get; set; }
        public virtual DbSet<SisFirma> SisFirmas { get; set; }
        public virtual DbSet<SisFirmaDonem> SisFirmaDonems { get; set; }
        public virtual DbSet<SisFirmaDonemYetki> SisFirmaDonemYetkis { get; set; }
        public virtual DbSet<SisIsyeri> SisIsyeris { get; set; }
        public virtual DbSet<SisKisayol> SisKisayols { get; set; }
        public virtual DbSet<SisKullanici> SisKullanicis { get; set; }
        public virtual DbSet<SisKullaniciHaklari> SisKullaniciHaklaris { get; set; }
        public virtual DbSet<SisKullaniciYetkiKodlari> SisKullaniciYetkiKodlaris { get; set; }
        public virtual DbSet<SisMenuProfil> SisMenuProfils { get; set; }
        public virtual DbSet<SisMenuProfilHaklari> SisMenuProfilHaklaris { get; set; }
        public virtual DbSet<SisMenuler> SisMenulers { get; set; }
        public virtual DbSet<SisRefno> SisRefnos { get; set; }
        public virtual DbSet<SisSabitler> SisSabitlers { get; set; }
        public virtual DbSet<SisSabitlerDetay> SisSabitlerDetays { get; set; }
        public virtual DbSet<SisYetkiKodlari> SisYetkiKodlaris { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=UmotaUnoPazar;user=sa; password=Net0pian+-+;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<SisAmbar>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_ambar");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.FirmaNo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("firma_no");

                entity.Property(e => e.Isyeriref).HasColumnName("isyeriref");

                entity.Property(e => e.Kodu).HasColumnName("kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");
            });

            modelBuilder.Entity<SisFirma>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_firma");

                entity.Property(e => e.FirmaAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("firma_adi");

                entity.Property(e => e.FirmaNo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("firma_no");

                entity.Property(e => e.LogoCariKart).HasColumnName("logo_cari_kart");

                entity.Property(e => e.LogoFirmaNo)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("logo_firma_no");

                entity.Property(e => e.LogoHizmetKart).HasColumnName("logo_hizmet_kart");

                entity.Property(e => e.LogoStokKart).HasColumnName("logo_stok_kart");

            });

            modelBuilder.Entity<SisFirmaDonem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_firma_donem");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.FirmaNo).HasColumnName("firma_no");

                entity.Property(e => e.LogoDonem).HasColumnName("logo_donem");

                entity.Property(e => e.LogoFirma).HasColumnName("logo_firma");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Ondeger).HasColumnName("ondeger");

                entity.Property(e => e.Yil).HasColumnName("yil");
            });

            modelBuilder.Entity<SisFirmaDonemYetki>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_firma_donem_yetki");

                entity.Property(e => e.Donemref).HasColumnName("donemref");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Logref)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logref");

                entity.Property(e => e.Tur).HasColumnName("tur");
            });

            modelBuilder.Entity<SisIsyeri>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_isyeri");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.FirmaNo)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("firma_no");

                entity.Property(e => e.Kodu).HasColumnName("kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");
            });

            modelBuilder.Entity<SisKisayol>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_kisayol");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");
            });

            modelBuilder.Entity<SisKullanici>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_kullanici");

                entity.Property(e => e.KullaniciAdi)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_adi");

                entity.Property(e => e.KullaniciAktif).HasColumnName("kullanici_aktif");

                entity.Property(e => e.KullaniciIptal).HasColumnName("kullanici_iptal");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.KullaniciMenuProfil).HasColumnName("kullanici_menu_profil");

                entity.Property(e => e.KullaniciPcadi)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_pcadi");

                entity.Property(e => e.KullaniciSifre)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_sifre");

                entity.Property(e => e.KullaniciYetkiKodu)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_yetki_kodu");

                entity.Property(e => e.LogoPassword)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("logo_password");

                entity.Property(e => e.LogoUsername)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("logo_username");

                entity.Property(e => e.MailAdres)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mail_adres");

                entity.Property(e => e.MailHost)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mail_host");

                entity.Property(e => e.MailImza)
                    .HasColumnType("text")
                    .HasColumnName("mail_imza");

                entity.Property(e => e.MailKullanici)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mail_kullanici");

                entity.Property(e => e.MailSifre)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mail_sifre");

                entity.Property(e => e.SonGirisTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("son_giris_tarihi");
            });

            modelBuilder.Entity<SisKullaniciHaklari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_kullanici_haklari");

                entity.Property(e => e.HakTipi)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("hak_tipi")
                    .IsFixedLength(true);

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");
            });

            modelBuilder.Entity<SisKullaniciYetkiKodlari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_kullanici_yetki_kodlari");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.YetkiKodu)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("yetki_kodu");
            });

            modelBuilder.Entity<SisMenuProfil>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_menu_profil");

                entity.Property(e => e.ProfilAdi)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("profil_adi");

                entity.Property(e => e.ProfilId).HasColumnName("profil_id");
            });

            modelBuilder.Entity<SisMenuProfilHaklari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_menu_profil_haklari");

                entity.Property(e => e.HakTipi)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("hak_tipi")
                    .IsFixedLength(true);

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.ProfilId).HasColumnName("profil_id");
            });

            modelBuilder.Entity<SisMenuler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_menuler");

                entity.Property(e => e.ImageIndex).HasColumnName("image_index");

                entity.Property(e => e.MenuAcarkenGuncelle).HasColumnName("menu_acarken_guncelle");

                entity.Property(e => e.MenuDfm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_dfm");

                entity.Property(e => e.MenuGirismi).HasColumnName("menu_girismi");

                entity.Property(e => e.MenuId).HasColumnName("menu_id");

                entity.Property(e => e.MenuModul).HasColumnName("menu_modul");

                entity.Property(e => e.MenuParam).HasColumnName("menu_param");

                entity.Property(e => e.MenuSecenek)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("menu_secenek");

                entity.Property(e => e.MenuSira).HasColumnName("menu_sira");

                entity.Property(e => e.MenuTanimi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("menu_tanimi");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");
            });

            modelBuilder.Entity<SisRefno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_refno");

                entity.Property(e => e.Increment).HasColumnName("increment");

                entity.Property(e => e.Lastrefno).HasColumnName("lastrefno");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tablename");
            });

            modelBuilder.Entity<SisSabitler>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_sabitler");

                entity.Property(e => e.Izin).HasColumnName("izin");

                entity.Property(e => e.Tanimi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tanimi");

                entity.Property(e => e.Tip).HasColumnName("tip");
            });

            modelBuilder.Entity<SisSabitlerDetay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_sabitler_detay");

                entity.Property(e => e.Adi)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Ikodu).HasColumnName("ikodu");

                entity.Property(e => e.Izin).HasColumnName("izin");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.OzelKod1)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozel_kod1");

                entity.Property(e => e.OzelKod10)
                    .HasColumnType("datetime")
                    .HasColumnName("ozel_kod10");

                entity.Property(e => e.OzelKod11)
                    .HasColumnType("datetime")
                    .HasColumnName("ozel_kod11");

                entity.Property(e => e.OzelKod12)
                    .HasColumnType("datetime")
                    .HasColumnName("ozel_kod12");

                entity.Property(e => e.OzelKod2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozel_kod2");

                entity.Property(e => e.OzelKod3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozel_kod3");

                entity.Property(e => e.OzelKod4).HasColumnName("ozel_kod4");

                entity.Property(e => e.OzelKod5).HasColumnName("ozel_kod5");

                entity.Property(e => e.OzelKod6).HasColumnName("ozel_kod6");

                entity.Property(e => e.OzelKod7).HasColumnName("ozel_kod7");

                entity.Property(e => e.OzelKod8).HasColumnName("ozel_kod8");

                entity.Property(e => e.OzelKod9).HasColumnName("ozel_kod9");

                entity.Property(e => e.Renk1).HasColumnName("renk1");

                entity.Property(e => e.Renk2).HasColumnName("renk2");

                entity.Property(e => e.SabitDetayId).HasColumnName("sabit_detay_id");

                entity.Property(e => e.Siralama).HasColumnName("siralama");

                entity.Property(e => e.Tip).HasColumnName("tip");

                entity.Property(e => e.YabanciAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("yabanci_adi");
            });

            modelBuilder.Entity<SisYetkiKodlari>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("sis_yetki_kodlari");

                entity.Property(e => e.YetkiAdi)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("yetki_adi");

                entity.Property(e => e.YetkiKodu)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("yetki_kodu");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
