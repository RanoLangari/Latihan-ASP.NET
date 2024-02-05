using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Services.Description;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class BarangController : Controller
    {
        public static List<BarangModel> listBarang = new List<BarangModel>();

        public ActionResult Index()
        {
            return Json(new {Message = "Success"}, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult getBarang()
        {
            for (int i = 0; i < 10; i++)
            {
                BarangModel newBarang = new BarangModel();
                newBarang.KodeBarang = "K-" + i;
                newBarang.NamaBarang = "Barang" + i;
                newBarang.KategoriBarang = "Kat" + 1;
                newBarang.hargaBarang = 5000 * i;
                
                listBarang.Add(newBarang);
            }

            return Json(new
            {
                Message = "Berhasil Mendapatkan Data Barang",
                data = listBarang
            },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult tambahBarang(BarangModel barang)
        {
            listBarang.Add(barang);
            return Json(new { message = "Barang berhasil ditambahkan" });
        }

        [HttpPost]
        public ActionResult editBarang(BarangModel barang)
        {
            if (!listBarang.Any(x => x.KodeBarang == barang.KodeBarang))
            {
                return Json(new { message = "Kode Barang tidak Ditemukan" });
            }

            BarangModel editBarang = listBarang.Where(x => x.KodeBarang == barang.KodeBarang).FirstOrDefault();
            editBarang.NamaBarang = barang.NamaBarang;
            editBarang.KategoriBarang = barang.KategoriBarang;
            editBarang.hargaBarang = barang.hargaBarang;

            return Json(new { Message = "barang Berhasil Diubah" });
        }

        [HttpPost]
        public ActionResult hapusBarang(BarangModel barang)
        {
            if (!listBarang.Any(x => x.KodeBarang == barang.KodeBarang ))
            {
                return Json(new { Message = "Kode Barang Tidak Ditemukan" });
            }

            BarangModel hapusBarang = listBarang.Where(x => x.KodeBarang == barang.KodeBarang).FirstOrDefault();
            listBarang.Remove(hapusBarang);
            return Json(new {Message = "Barang Berhasil Dihapus"}, JsonRequestBehavior.AllowGet);


        }

    }
}