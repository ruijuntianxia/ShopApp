using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Npoi.Core.SS.UserModel;
using Npoi.Core.XSSF.UserModel;
using ShopApp.Common;
using ShopApp.Data;
using ShopApp.Models.DataViewModels;

namespace ShopApp.Controllers
{
    public class AddDataController : Controller
    {
        private readonly AddDataDbContext _context;

        private IHostingEnvironment hostingEnv;
       
        public AddDataController(AddDataDbContext context, IHostingEnvironment env)
        {
            _context = context;
            this.hostingEnv = env;
        }

        // GET: AddData
        public async Task<IActionResult> Index()
        {
            return View(await _context.AddDataViewModel.ToListAsync());
        }

        // GET: AddData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDataViewModel = await _context.AddDataViewModel
                .SingleOrDefaultAsync(m => m.id == id);
            if (addDataViewModel == null)
            {
                return NotFound();
            }

            return View(addDataViewModel);
        }

        // GET: AddData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,classify,brand,model,modelmum,imageurl,remark,createuser,createdate,updateuser,updatedate")] AddDataViewModel addDataViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(addDataViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addDataViewModel);
        }

        // GET: AddData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDataViewModel = await _context.AddDataViewModel.SingleOrDefaultAsync(m => m.id == id);
            if (addDataViewModel == null)
            {
                return NotFound();
            }
            return View(addDataViewModel);
        }

        // POST: AddData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,classify,brand,model,modelmum,imageurl,remark,createuser,createdate,updateuser,updatedate")] AddDataViewModel addDataViewModel)
        {
            if (id != addDataViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addDataViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddDataViewModelExists(addDataViewModel.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(addDataViewModel);
        }

        // GET: AddData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addDataViewModel = await _context.AddDataViewModel
                .SingleOrDefaultAsync(m => m.id == id);
            if (addDataViewModel == null)
            {
                return NotFound();
            }

            return View(addDataViewModel);
        }

        // POST: AddData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var addDataViewModel = await _context.AddDataViewModel.SingleOrDefaultAsync(m => m.id == id);
            _context.AddDataViewModel.Remove(addDataViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddDataViewModelExists(int id)
        {
            return _context.AddDataViewModel.Any(e => e.id == id);
        }

        public async Task<IActionResult> UploadFiles()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadFiles(IList<IFormFile> files)
        {

            long size = 0, second = 0;
            //IList<IFormFile> 内的IFormFile对象
            foreach (var file in files)
            {
                string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim();
                filename = hostingEnv.WebRootPath + $@"\{filename.Replace("\"", "")}";
                size += file.Length;
                //将excal 写入本地
                using (FileStream fs = System.IO.File.Create(filename))
                {
                    file.CopyTo(fs);
                    fs.Flush();

                }
                //创建数据容器的实例
                DataTransfer.DataTable dt = new DataTransfer.DataTable();
                using (FileStream stream = System.IO.File.Open(filename, FileMode.Open, FileAccess.Read))
                {
                    //创建 XSSFWorkbook和ISheet实例
                    XSSFWorkbook workbook = new XSSFWorkbook(stream);
                    ISheet sheet = workbook.GetSheetAt(0);
                    //获取sheet的首行
                    IRow headerRow = sheet.GetRow(0);
                    int cellCount = headerRow.LastCellNum;
                    List<DataTransfer.DataColumn> Columnlist = new List<DataTransfer.DataColumn>();
                    for (int i = headerRow.FirstCellNum; i < cellCount; i++)
                    {
                        //Column 添加ColumnName
                        Columnlist.Add(new DataTransfer.DataColumn(headerRow.GetCell(i).StringCellValue, headerRow.GetCell(i).CellType.GetType()));
                    }
                    int rowCount = sheet.LastRowNum;
                    object[] rowlist = new object[sheet.LastRowNum];
                    for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                    {
                        object[] valuelist = new object[cellCount];
                        IRow row = sheet.GetRow(i);
                        for (int j = row.FirstCellNum; j < cellCount; j++)
                        {
                            //遍历添加Column的数据
                            if (row.GetCell(j) != null)
                                valuelist.SetValue(row.GetCell(j).ToString(), j);
                        }
                        //遍历将Column的数据添加到Datarow
                        rowlist.SetValue(valuelist, i - 1);
                        dt.Rows.Add(new DataTransfer.DataRow(Columnlist, valuelist));
                    }
                    List<AddDataViewModel> list = new List<AddDataViewModel>();
                    foreach (DataTransfer.DataRow dr in dt.Rows)
                    {
                        //填充entity 这个可换成自己的表
                        AddDataViewModel moudel = new AddDataViewModel();
                        foreach (PropertyInfo prop in moudel.GetType().GetRuntimeProperties())
                        {
                            if (dr[prop.Name] != null)
                            {
                                object obj = new object();
                                if (prop.Name == "SecondLevel")
                                {
                                    obj = Convert.ToInt32(dr[prop.Name]);
                                }
                                else
                                {
                                    obj = dr[prop.Name];

                                }
                                prop.SetValue(moudel, obj);
                            }
                        }
                        //excel 中没有的栏位可以在此添加
                        //moudel.ViewSupportId = 0;
                        //moudel.ViewSupportName = "";
                        //moudel.FirstLevel = 111;
                        //moudel.Keywords = 0;
                        //moudel.IsCompany = false;
                        //moudel.IsReady = false;
                        //moudel.UnLock = true;
                        //moudel.IsCrm = false;
                        //moudel.IsOpera = false;
                        //moudel.IP = "";
                        //moudel.ImportType = "";
                        //moudel.ProtectedTimes = DateTime.Now;
                        //moudel.RegisterTime = DateTime.Now;
                        //moudel.IsCheck = 0;
                        //moudel.IsAborad = 0;
                        list.Add(moudel);
                    }
                    //创建计时器
                    Stopwatch watch = Stopwatch.StartNew();
                    //ef连接数据库
                    using (_context)
                    {
                        //批量insert
                        foreach (AddDataViewModel entity in list)
                        {
                            _context.AddDataViewModel.Add(entity);
                        }
                        _context.SaveChanges();
                    }
                    //获取处理数据所用的时间
                    second = watch.ElapsedMilliseconds;

                }
                ViewBag.Message = $"{files.Count} file(s) / { size} bytes  When used { second } uploaded successfully!";
            }
            return View();

        }
    }
}
