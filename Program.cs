using System;
using System.Collections.Generic;

// kelas karyawan dengan properti nama dan gaji
class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"Karyawan {Nama} sedang bekerja");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama: {Nama}, Gaji: {Gaji}");    
    }
}

// kelas tetap yang mewarisi kelas karyawan, dengan properti tambahan tunjangan serta method HitungGajiTotal
class Tetap : Karyawan
{
    public double Tunjangan { get; set; }
    
    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"Karyawan tetap {Nama} sedang bekerja");
    }
}

// kelas kontrak yang mewarisi kelas karyawan, dengan properti tambahan durasi serta method cekKontrak
class Kontrak : Karyawan
{
    public int Durasi { get; set; }

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"Karyawan kontrak {Nama} memiliki durasi kontrak {Durasi} bulan");
    }
    public override void Kerja()
    {
        Console.WriteLine($"Karyawan kontrak {Nama} sedang bekerja");
    }
}

// kelas manager yang mewarisi kelas tetap, dengan method tambahan Memimpin
class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }
    public void Memimpin()
    {
        Console.WriteLine($"Manager {Nama} sedang memimpin");
    }
    public override void Kerja()
    {
        Console.WriteLine($"Manager {Nama} sedang bekerja");
    }
    
}

// kelas staff yang mewarisi kelas tetap, dengan method tambahan KerjakanTugas
class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }
    public void KerjakanTugas()
    {
        Console.WriteLine($"Staff {Nama} sedang melakukan live streaming");
    }
    
    public override void Kerja()
    {
        Console.WriteLine($"Staff {Nama} bekerja sebagai streamer");
    }
}

// kelas magang yang mewarisi kelas kontrak, dengan method tambahan Belajar
class Magang : Karyawan
{
    public int Durasi { get; set; }
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }
    public void Belajar()
    {
        Console.WriteLine($"Magang {Nama} sedang belajar jadi streamer");
    }
    public override void Kerja()
    {
        Console.WriteLine($"Magang {Nama} belajar live streaming sambil bekerja");
    }
}

// kelas freelancer yang mewarisi kelas kontrak, dengan method tambahan AmbilProyek
class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }
    public void AmbilProyek()
    {
        Console.WriteLine($"Freelancer {Nama} sedang mengedit video clipper");
    }
    public override void Kerja()
    {
        Console.WriteLine($"Freelancer {Nama} bekerja sebagai clipper");
    }
}

// kelas perusahaan
class Perusahaan
{
    private List<Karyawan> daftar = new List<Karyawan>();
    public void TambahKaryawan(Karyawan Karyawan)
    {
        daftar.Add(Karyawan);
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("=== Daftar Karyawan ===");
        foreach (var karyawan in daftar)
        {
            karyawan.InfoKaryawan();
            karyawan.Kerja();
            Console.WriteLine();
        }
    }
}

// Main program
class Program
{
    static void Main(string[] args)
    {
        // buat objek perusahaan
        Perusahaan perusahaan = new Perusahaan();
        // buat objek karyawan
        Manager manager = new Manager("Ayla", 10000000, 2000000);
        Staff staff = new Staff("Karyn", 5000000, 1000000);
        Magang magang = new Magang("Andro", 2000000, 6);
        Freelancer freelancer = new Freelancer("Karynisme", 3000000, 3);

        // tambahkan karyawan ke perusahaan
        perusahaan.TambahKaryawan(manager);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(freelancer);

        // tampilkan semua data
        perusahaan.DaftarKaryawan();

        // demonstrasi polymorphism
        Karyawan k1 = new Staff("Karyn", 4000000, 8000000);
        k1.Kerja(); // memanggil method Kerja() dari kelas Staff    

        Console.WriteLine();

        // panggil method khusus
        manager.Memimpin();
        staff.KerjakanTugas();
        magang.Belajar();
        freelancer.AmbilProyek();
    }
}