// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace Projekat.Migrations
{
    [DbContext(typeof(SalonContext))]
    partial class SalonContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.Property<int>("IDKlijenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojTelefona")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IDKlijenta");

                    b.ToTable("Klijent");
                });

            modelBuilder.Entity("Models.Kozmeticar", b =>
                {
                    b.Property<int>("IDKozmeticara")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int?>("SaloniID")
                        .HasColumnType("int");

                    b.Property<string>("Struka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UslugeIDUsluge")
                        .HasColumnType("int");

                    b.HasKey("IDKozmeticara");

                    b.HasIndex("SaloniID");

                    b.HasIndex("UslugeIDUsluge");

                    b.ToTable("Kozmeticar");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("MaxBrojTermina")
                        .HasMaxLength(20)
                        .HasColumnType("int");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("RadnoVremeDo")
                        .HasColumnType("int");

                    b.Property<int>("RadnoVremeOd")
                        .HasColumnType("int");

                    b.Property<int>("Telefon")
                        .HasMaxLength(9)
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Salon");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.Property<int>("IDTermina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrojTermina")
                        .HasColumnType("int");

                    b.Property<int?>("KlijentIDKlijenta")
                        .HasColumnType("int");

                    b.Property<int?>("KozmeticarIDKozmeticara")
                        .HasColumnType("int");

                    b.Property<int?>("SaloniID")
                        .HasColumnType("int");

                    b.Property<bool>("Slobodan")
                        .HasColumnType("bit");

                    b.Property<int>("Vreme")
                        .HasColumnType("int");

                    b.HasKey("IDTermina");

                    b.HasIndex("KlijentIDKlijenta");

                    b.HasIndex("KozmeticarIDKozmeticara");

                    b.HasIndex("SaloniID");

                    b.ToTable("TerminiKlijenata");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Property<int>("IDUsluge")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cena")
                        .HasColumnType("int");

                    b.Property<string>("VrstaUsluge")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IDUsluge");

                    b.ToTable("Usluga");
                });

            modelBuilder.Entity("Models.Kozmeticar", b =>
                {
                    b.HasOne("Models.Salon", "Saloni")
                        .WithMany("Kozmeticari")
                        .HasForeignKey("SaloniID");

                    b.HasOne("Models.Usluga", "Usluge")
                        .WithMany("Kozmeticari")
                        .HasForeignKey("UslugeIDUsluge");

                    b.Navigation("Saloni");

                    b.Navigation("Usluge");
                });

            modelBuilder.Entity("Models.Termin", b =>
                {
                    b.HasOne("Models.Klijent", "Klijent")
                        .WithMany("KlijentKozmeticar")
                        .HasForeignKey("KlijentIDKlijenta");

                    b.HasOne("Models.Kozmeticar", "Kozmeticar")
                        .WithMany("KozmeticarKlijent")
                        .HasForeignKey("KozmeticarIDKozmeticara");

                    b.HasOne("Models.Salon", "Saloni")
                        .WithMany("Termini")
                        .HasForeignKey("SaloniID");

                    b.Navigation("Klijent");

                    b.Navigation("Kozmeticar");

                    b.Navigation("Saloni");
                });

            modelBuilder.Entity("Models.Klijent", b =>
                {
                    b.Navigation("KlijentKozmeticar");
                });

            modelBuilder.Entity("Models.Kozmeticar", b =>
                {
                    b.Navigation("KozmeticarKlijent");
                });

            modelBuilder.Entity("Models.Salon", b =>
                {
                    b.Navigation("Kozmeticari");

                    b.Navigation("Termini");
                });

            modelBuilder.Entity("Models.Usluga", b =>
                {
                    b.Navigation("Kozmeticari");
                });
#pragma warning restore 612, 618
        }
    }
}
