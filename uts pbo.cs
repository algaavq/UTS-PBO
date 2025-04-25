// soal tipe b
using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public int ID { get; set; }
    public string Judul { get; set; }
    public string Penulis { get; set; }
    public int TahunTerbit { get; set; }
    public string Status { get; set; }

    public Book(int id, string judul, string penulis, int tahunTerbit, string status)
    {
        ID = id;
        Judul = judul;
        Penulis = penulis;
        TahunTerbit = tahunTerbit;
        Status = "Tersedia";
    }
    public override string ToString()
    {
        return $"ID: {ID}, Judul {Judul}, Penulis {Penulis}, TahunTerbit {TahunTerbit}, Status {Status}";
    }
}

public class Perpustakaan
{
    public string NamaPerpustakaan { get; set; }
    public string AlamatPerpustakaan { get; set; }
    private List<Book> koleksiBuku = new List<Book>();

    public Perpustakaan(string namaPerpustakaan, string alamatPerpustakaan )
    {
        NamaPerpustakaan = namaPerpustakaan;
        AlamatPerpustakaan = alamatPerpustakaan;
    }

    public void TambahBuku(Book buku)
    {
        if(koleksiBuku.Any(b => b.ID == buku.ID))
        {
            Console.WriteLine("Error: buku dengan id yang sama sudah ada");
            return;
        }
        koleksiBuku.Add(buku);
        Console.WriteLine("Buku berhasil di" +
            "tambahkan");
    }
    
    public void TampilkanSemuaBuku()
    {
        if (koleksiBuku.Count == 0)
        {
            Console.WriteLine("tidak ada buku dalam perpustakaan");
            return;
        }
        Console.WriteLine("Daftar Semua Buku");
        foreach (var buku in koleksiBuku)
        {
            Console.WriteLine(buku);
        }
    }
    public Book CariBuku(int id)
    {
        Book buku = koleksiBuku.FirstOrDefault(b => b.ID == id);
        return buku;
    }

    public List<Book> CariBukuByJudul ( string judul)
    {
        List<Book> bukuList = koleksiBuku.Where(b => b.Judul.ToLower().Contains(judul.ToLower())).ToList();
        return bukuList;
    }
    public void UpdateBuku(int id,string judul,string penulis,int tahunTerbit)
    {
        Book buku = CariBuku(id);
        if (buku != null)
        {
            buku.Judul = judul;
            buku.Penulis = penulis;
            buku.TahunTerbit = tahunTerbit;
            Console.WriteLine("informasi buku berhasil diperbarui");
        }
        else
        {
            Console.WriteLine("buku tidak dapat ditemukan");
        }
    }
    public void HapusBuku(int id)
    {
        Book buku = CariBuku(id);
        if ( buku !=null)
        {
            koleksiBuku.Remove(buku);
            Console.WriteLine("buku berhasil dihapus");
        }
        else
        {
            Console.WriteLine("buku tidak dapat ditemukan");
        }
    }
    public void PinjamkanBuku(int id)
    {
        Book buku = CariBuku(id);
        if (buku !=null)
        {
            if (buku.Status == "Tersedia")
            {
                buku.Status = "Dipinjam";
                Console.WriteLine("buku telah berhasil dipinjam");
            }
            else
            {
                Console.WriteLine("buku sedang tidak tersedia");
            }
        }
        else
        {
            Console.WriteLine("buku tidak ditemukan");
        }
    }

    public void KembalikanBuku(int id)
    {
        Book buku = CariBuku(id);
        if (buku != null)
        {
            if (buku.Status == "dipinjam")
            {
                buku.Status = "tersedia";
                Console.WriteLine("buku berhasil dikembalikan");
            }
            else
            {
                Console.WriteLine("buku tidak sedang dipinjam");
            }
        }
        else
        {
            Console.WriteLine("buku tidak ditemukan");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Perpustakaan perpustakaan = new Perpustakaan("perpustakaan mengsedih", "jl. sama yang lain no 3");
            while(true)
            {
                Console.WriteLine("\n--- Menu Perpustakaan ---");
                Console.WriteLine($"Nama Perpustakaan: {perpustakaan.NamaPerpustakaan}");
                Console.WriteLine($"Alamat Perpustakaan: {perpustakaan.AlamatPerpustakaan}");
                Console.WriteLine("1. Tambah Buku");
                Console.WriteLine("2. Tampilkan Semua Buku");
                Console.WriteLine("3. Cari Buku by ID");
                Console.WriteLine("4. Cari Buku by Judul");
                Console.WriteLine("5. Update Buku");
                Console.WriteLine("6. Hapus Buku");
                Console.WriteLine("7. Pinjamkan Buku");
                Console.WriteLine("8. Kembalikan Buku");
                Console.WriteLine("0. keluar");
                Console.WriteLine("Pilih Menu: ");

                string Input = Console.ReadLine();
                int Pilihan;
                if (!int.TryParse(Input,out Pilihan))
                {
                    Console.WriteLine("input tidak valid,tolong masukkan angkat");
                    continue;
                }
            }
            switch("pilihan")
            {
                case "1" :
                    Console.Write("Masukkan ID Buku: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("masukkan Judul Buku: ");
                    string judul = Console.ReadLine();
                    Console.Write("masukkan Penulis Buku: ");
                    string penulis = Console.ReadLine();
                    Console.Write("masukkn tahun terbit buku: ");
                    int tahunTerbit = int.Parse(Console.ReadLine());

                    Book bukuBaru = new Book(id, judul, penulis, tahunTerbit);
                    perpustakaan.TambahBuku(bukuBaru);
                    break;
                case 2:
                    perpustakaan.TampilkanSemuaBuku();
                    break;
                case 3:
                    Console.Write("masukkan ID buku yang dicari: ");
                    int idCari = int.Parse(Console.ReadLine());
                    Book bukuCari = perpustakaan.CariBuku(idCari);
                    if (bukuCari != null)
                    {
                        Console.WriteLine("buku ditemukan: " + bukuCari);
                    }
                    else
                    {
                        Console.WriteLine("buku tidak ditemukan");
                    }
                    break;
                case 4:
                    Console.Write("masukkan Judul buku yang dicari: ");
                    string judulCari = Console.ReadLine();
                    List<Book> bukuCariList = perpustakaan.CariBukuByJudul(judulCari);
                    if (bukuCariList.Count>0)
                    {
                        Console.WriteLine("buku ditemukan");
                        foreach (var buku in bukuCariList) {
                            Console.WriteLine(buku);
                        }
                    }
                    else
                    {
                        Console.WriteLine("buku tidak ditemukan")
                    }
                    break;
                case 5:
                    Console.Write("masukkan ID buku yang akan diupdate");
                    int idUpdate = Console.ReadLine();
                    Console.Write("masukkan judul buku baru");
                    string judulUpdate = Console.ReadLine();
                    Console.Write("masukkan penulis buku baru");
                    string penulisUpdate = Console.ReadLine);
                    Console.Write("masukkan tahun terbit buku baru");
                    int tahunTerbitUpdate = int.Parse(Console.ReadLine());
                    perpustakaan.UpdateBuku(idUpdate, judulUpdate, penulisUpdate, tahunTerbitUpdate);
                    break;
            }
        }
    }
}